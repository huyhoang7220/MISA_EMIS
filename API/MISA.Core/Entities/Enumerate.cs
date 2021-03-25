using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Created by : VXKHANH (14/3/2021)
    /// Class Enum
    /// </summary>
    public enum MISACode
    {
        /// <summary>
        /// Dữ liệu không hợp lệ
        /// </summary>
        NotValid = 400,

        /// <summary>
        /// Có exception xảy ra
        /// </summary>
        Exception = 500,

        /// <summary>
        /// Thành công
        /// </summary>
        Success = 200,

        /// <summary>
        /// Thêm thành công
        /// </summary>
        Created = 201,

        /// <summary>
        /// Không có dữ liệu tương ứng
        /// </summary>
        NoContent = 204,

        /// <summary>
        /// Không có dữ liệu nào được thêm vào database
        /// </summary>
        NoRecordAdd = 2000,

        /// <summary>
        /// Dữ liệu chưa được cập nhật
        /// </summary>
        NoRecordUpdate = 2001,

        /// <summary>
        /// Không có bản ghi nào được xóa
        /// </summary>
        NoRecordDelete = 2002,

        /// <summary>
        /// Mã không được phép trùng nhau
        /// </summary>
        NotDuplicate = 401,

        /// <summary>
        /// Mã không được để trống
        /// </summary>
        CodeIsRequired = 402
    }
}
