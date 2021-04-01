using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MISA.Core.Interface
{
    /// <summary>
    /// Created by: VXKHANH
    /// Created date: 26/03/2021
    /// </summary>
    public interface IBaseRepository
    {
        /// <summary>
        /// Created by : VXKHANH(13/3/2021)
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <typeparam name="entity">Type</typeparam>
        /// <returns>Danh sách đối tượng</returns>
        IEnumerable<entity> GetAll<entity>();

        /// <summary>
        /// Creatd by: VXKHANH
        /// Created date: 26/3/2021
        /// Lấy thông tin theo khóa chính
        /// </summary>
        /// <typeparam name="entity">Đối tượng</typeparam>
        /// <param name="entityId">Khóa chính</param>
        /// <returns></returns>
        entity GetObjectById<entity>(Guid entityId);

        /// <summary>
        /// Creatd by: VXKHANH
        /// Created date: 26/3/2021
        /// Thêm bản ghi mới
        /// </summary>
        /// <typeparam name="entity">Type</typeparam>
        /// <param name="obj">Đối tượng</param>
        /// <returns></returns>
        int InsertObject<entity>(entity obj);

        /// <summary>
        /// Creatd by: VXKHANH
        /// Created date: 26/3/2021
        /// Cập nhật dữ liệu
        /// </summary>
        /// <typeparam name="entity"></typeparam>
        /// <param name="obj">Đối tượng</param>
        /// <returns></returns>
        int UpdateObject<entity>(entity obj);


        /// <summary>
        /// Creatd by: VXKHANH
        /// Created date: 26/3/2021
        /// Xóa dữ liệu
        /// </summary>
        /// <typeparam name="entity">Type</typeparam>
        /// <param name="Id">Khóa chính</param>
        /// <returns></returns>
        int DeleteObject<entity>(Guid Id);

        /// <summary>
        /// Creatd by: VXKHANH
        /// Created date: 26/3/2021
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
