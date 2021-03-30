using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interface
{
    /// <summary>
    /// Created by: VXKHANH(25/3/2021)
    /// Service Khoản thu 
    /// </summary>
    public interface IFeeService:IBaseService
    {
        /// <summary>
        /// 
        /// Creatd by: VXKHANH
        /// Created date: 26/3/2021
        /// Lấy ra khoản thu có tên tương ứng
        /// </summary>
        /// <param name="feeName">Tên khoản thu</param>
        /// <returns>Đối tượng kết</returns>
        ServiceResult GetFeeByFeeName(string feeName);

        /// <summary>
        /// 
        /// Creatd by: VXKHANH
        /// Created date: 26/3/2021
        /// Lấy ra danh sách khoản thu đã ngừng theo dõi
        /// </summary>
        /// <returns>Đối đượng kết quả</returns>
        ServiceResult GetFeeIsStopFollow();

        /// <summary>
        /// 
        /// Creatd by: VXKHANH
        /// Created date: 26/3/2021
        /// Hàm xóa nhiều dong dữ liệu 
        /// </summary>
        /// <param name="feeIds">Danh sách khóa chính của các khoản thu cần xóa</param>
        /// <returns>Đối tượng kết quả</returns>
        ServiceResult DeleteMulti(List<Guid> feeIds);
    }
}
