using Dapper;
using MISA.Core.Interface;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MISA.Instructure.DataAccess
{
    public class BaseRepository:IBaseRepository
    {
        /// <summary>
        /// Created by : VXKHANH (21/3/2021)
        /// </summary>
        protected string connectionString = "User Id=dev;Host=47.241.69.179;Character Set=utf8; Database=MF761_VXKHANH_CukCuk; Password=12345678; Port=3306";
        protected IDbConnection dbConnection;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public BaseRepository()
        {
            dbConnection = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Lấy toàn bộ danh sách
        /// </summary>
        /// <typeparam name="entity">Class</typeparam>
        /// <returns>Danh sách</returns>
        public IEnumerable<entity> GetAll<entity>()
        {
            string typeName = typeof(entity).Name;
            string procName = $"proc_Get_{typeName}s";
            var result = dbConnection.Query<entity>(procName, commandType: CommandType.StoredProcedure);
            return result;
        }

        /// <summary>
        /// Lấy thông tin theo id
        /// </summary>
        /// <typeparam name="entity">Class</typeparam>
        /// <param name="entityId">Id của đối tượng</param>
        /// <returns>Thông tin 1 bản ghi</returns>
        public entity GetObjectById<entity>(Guid entityId)
        {
            string className = typeof(entity).Name;
            string procName = $"proc_Get_{className}ById";
            var dynamicParam = new DynamicParameters();
            dynamicParam.Add($"@{className}Id", entityId.ToString());
            var result = dbConnection.Query<entity>(procName, param: dynamicParam, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Thêm một bản ghi mới
        /// </summary>
        /// <typeparam name="entity">Class</typeparam>
        /// <param name="obj">Đối tượng thêm vào</param>
        /// <returns>Số dòng thay đổi</returns>
        public int InsertObject<entity>(entity obj)
        {
            string className = typeof(entity).Name;
            string procName = $"proc_Insert_{className}";
            var result = dbConnection.Execute(procName, obj, commandType: CommandType.StoredProcedure);
            return result;
        }

        /// <summary>
        /// Cập nhật thông tin về bản ghi mới
        /// </summary>
        /// <typeparam name="entity">Class</typeparam>
        /// <param name="obj">Đối tượng được thay đổi</param>
        /// <returns>Số dòng được thay đổi</returns>
        public int UpdateObject<entity>(entity obj)
        {
            string className = typeof(entity).Name;
            string procName = $"proc_Update_{className}";
            var result = dbConnection.Execute(procName, obj, commandType: CommandType.StoredProcedure);
            return result;
        }

        /// <summary>
        /// Xóa bản ghi thep id
        /// </summary>
        /// <typeparam name="entity">Class</typeparam>
        /// <param name="Id">Id của bản ghi</param>
        /// <returns>Số dòng bị ảnh hưởng</returns>
        public int DeleteObject<entity>(Guid Id)
        {
            string className = typeof(entity).Name;
            string procName = $"proc_Delete_{className}";
            var dynamicParam = new DynamicParameters();
            dynamicParam.Add($"{className}Id", Id.ToString());
            var result = dbConnection.Execute(procName, param: dynamicParam, commandType: CommandType.StoredProcedure);
            return result;
        }

        public Entity GetEntityByProperty<Entity>(string propertyName, object propertyValue)
        {
            var entityName = typeof(Entity).Name;
            var procName = $"proc_Get_{entityName}By{propertyName}";
            var dynamicParam = new DynamicParameters();
            dynamicParam.Add(propertyName, propertyValue);
            var entityValue = dbConnection.Query<Entity>(procName, param: dynamicParam, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return entityValue;
        }
    }
}
