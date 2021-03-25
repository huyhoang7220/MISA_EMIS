using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    /// <summary>
    ///Created by VXKHANH (13/3/2021)
    /// </summary>
    /// 
    ///Kết quả trả về của validate dữ liệu
    public class ServiceResult
    {
        public bool IsValid = true;
        public string Msg { get; set; }
        public object Data { get; set; }
        public MISACode Code { get; set; }
    }
}
