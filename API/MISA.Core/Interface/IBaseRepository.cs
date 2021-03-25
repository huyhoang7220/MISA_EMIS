using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MISA.Core.Interface
{
    public interface IBaseRepository
    {
        /// <summary>
        /// Created by : VXKHANH(13/3/2021)
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <typeparam name="entity"></typeparam>
        /// <returns></returns>
        IEnumerable<entity> GetAll<entity>();

        /// <summary>
        /// Lấy thông tin theo khóa chính
        /// </summary>
        /// <typeparam name="entity"></typeparam>
        /// <param name="entityId"></param>
        /// <returns></returns>
        entity GetObjectById<entity>(Guid entityId);

        /// <summary>
        /// Thêm bản ghi mới
        /// </summary>
        /// <typeparam name="entity"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        int InsertObject<entity>(entity obj);

        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        /// <typeparam name="entity"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        int UpdateObject<entity>(entity obj);


        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <typeparam name="entity"></typeparam>
        /// <param name="Id"></param>
        /// <returns></returns>
        int DeleteObject<entity>(Guid Id);

        /// <summary>
        /// Lấy ra đối tượng với tên thuộc tính và giá trị truyền tương ứng
        /// </summary>
        /// <typeparam name="Entity">Class</typeparam>
        /// <param name="obj">Đối tượng</param>
        /// <param name="propertyName">Tên thuộc tính</param>
        /// <param name="propertyValue">Giá trị của thuộc tính</param>
        /// <returns></returns>
        Entity GetEntityByProperty<Entity>(string propertyName, object propertyValue);

    }
}
