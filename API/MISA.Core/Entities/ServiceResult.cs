using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    /// <summary>
    ///Created by VXKHANH (27/3/2021)
    /// </summary>
    /// 
    ///Kết quả trả về của validate dữ liệu
    public class ServiceResult
    {
        /// <summary>
        /// Kiểm tra trạng thái của dữ liệu
        /// True - Dữ liệu hợp lệ
        /// False - Dữ liệu không hợp lệ
        /// </summary>
        public bool IsValid = true;

        /// <summary>
        /// Câu thông báo trả về sau khi thực hiện các phương thức
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// Dữ liệu trả về 
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Mã của các trạng thái (lỗi, thành công, cảnh báo)
        /// </summary>
        public MISACode Code { get; set; }
    }
}
