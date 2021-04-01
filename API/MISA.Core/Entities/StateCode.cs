using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Creatd by: VXKHANH
    /// Created date: 27/03/2021
    /// </summary>
    public enum StateCode
    {
        /// <summary>
        /// Phương thức lấy dữ liệu (Get)
        /// </summary>
        Get = 0,
        /// <summary>
        /// Biến kiểm tra phương thức thêm (Post)
        /// </summary>
        Post = 1,
        /// <summary>
        /// Biến kiểm tra phương thức cập nhật (Put)
        /// </summary>
        Put = 2,
        /// <summary>
        /// Biến kiểm tra phương thức xóa
        /// </summary>
        Delete = 3
    }
}
