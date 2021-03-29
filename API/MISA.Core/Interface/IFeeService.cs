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
        /// Lấy ra khoản thu có tên tương ứng
        /// </summary>
        /// <param name="feeName">Tên khoản thu</param>
        /// <returns></returns>
        ServiceResult GetFeeByFeeName(string feeName);

        /// <summary>
        /// Lấy ra danh sách khoản thu đã ngừng theo dõi
        /// </summary>
        /// <returns></returns>
        ServiceResult GetFeeIsStopFollow();

        /// <summary>
        /// Hàm xóa nhiều dong dữ liệu 
        /// </summary>
        /// <param name="feeIds">Danh sách khóa chính của các khoản thu cần xóa</param>
        /// <returns></returns>
        ServiceResult DeleteMulti(List<Guid> feeIds);
    }
}
