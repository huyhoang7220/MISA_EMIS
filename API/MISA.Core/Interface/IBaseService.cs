using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interface
{
    public interface IBaseService
    {
        /// <summary>
        /// Lấy toàn bộ danh sách
        /// </summary>
        /// <typeparam name="entity"></typeparam>
        /// <returns></returns>
        IEnumerable<entity> GetAll<entity>();

        /// <summary>
        /// Lấy theo khóa chính
        /// </summary>
        /// <typeparam name="entity">Type</typeparam>
        /// <param name="entityId"></param>
        /// <returns></returns>
        ServiceResult GetObjectById<entity>(Guid entityId);

        /// <summary>
        /// Thêm mới thông tin
        /// </summary>
        /// <typeparam name="entity">Type</typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        ServiceResult InsertObject<entity>(entity obj);

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <typeparam name="entity">type</typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        ServiceResult UpdateObject<entity>(entity obj);

        /// <summary>
        /// Xóa thông tin
        /// </summary>
        /// <typeparam name="entity">khóa chính</typeparam>
        /// <param name="Id"></param>
        /// <returns></returns>
        ServiceResult DeleteObject<entity>(Guid Id);
    }
}
