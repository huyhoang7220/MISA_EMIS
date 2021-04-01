using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interface
{
    /// <summary>
    /// Created by : VXKHANH
    /// Created date: 26/03/2021
    /// </summary>
    public interface IBaseService
    {
        /// <summary>
        /// Creatd by: VXKHANH
        /// Created date: 26/3/2021
        /// Lấy toàn bộ danh sách
        /// </summary>
        /// <typeparam name="entity"></typeparam>
        /// <returns></returns>
        IEnumerable<entity> GetAll<entity>();

        /// <summary>
        /// Creatd by: VXKHANH
        /// Created date: 26/3/2021
        /// Lấy theo khóa chính
        /// </summary>
        /// <typeparam name="entity">Type</typeparam>
        /// <param name="entityId"></param>
        /// <returns></returns>
        ServiceResult GetObjectById<entity>(Guid entityId);

        /// <summary>
        /// Creatd by: VXKHANH
        /// Created date: 26/3/2021
        /// Thêm mới thông tin
        /// </summary>
        /// <typeparam name="entity">Type</typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        ServiceResult InsertObject<entity>(entity obj);

        /// <summary>
        /// Creatd by: VXKHANH
        /// Created date: 26/3/2021
        /// Cập nhật thông tin
        /// </summary>
        /// <typeparam name="entity">type</typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        ServiceResult UpdateObject<entity>(entity obj);

        /// <summary>
        /// Creatd by: VXKHANH
        /// Created date: 26/3/2021
        /// Xóa thông tin
        /// </summary>
        /// <typeparam name="entity">khóa chính</typeparam>
        /// <param name="Id"></param>
        /// <returns></returns>
        ServiceResult DeleteObject<entity>(Guid Id);
    }
}
