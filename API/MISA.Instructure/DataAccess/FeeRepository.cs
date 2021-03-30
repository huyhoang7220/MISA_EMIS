using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.Instructure.DataAccess
{
    /// <summary>
    /// Created by: VXKHANH
    /// Created date: 28/03/2021
    /// </summary>
    public class FeeRepository:BaseRepository, IFeeRepository
    {
        /// <summary>
        /// Creatd by: VXKHANH
        /// Created date: 26/3/2021
        /// Lấy khoản thu theo tên khoản thu
        /// </summary>
        /// <param name="feeName">tên khoản thu</param>
        /// <returns>Đối tượng khoản thu</returns>
        public Fee GetFeeByFeeName(string feeName)
        {
            var procName = "proc_Get_FeeByFeeName";
            var fee = dbConnection.Query<Fee>(procName, new { FeeName = feeName }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return fee;
        }

        /// <summary>
        /// 
        /// Creatd by: VXKHANH
        /// Created date: 26/3/2021
        /// Lấy danh sách khoản thu đã ngừng theo dõi
        /// </summary>
        /// <returns>Danh sách khoản thu</returns>
        public IEnumerable GetFeeIsStopFollow()
        {
            var procName = "proc_Get_FeeIsStopFollow";
            var fees = dbConnection.Query<Fee>(procName, commandType: CommandType.StoredProcedure).ToList();
            return fees;
        }

    }
}
