using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Created by: VXKHANH(26/3/2021)
    /// </summary>
    public class FeeRange:CreatedInfor
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        [Primarykey]
        public Guid FeeRangeId { get; set; }

        /// <summary>
        /// Tên phạm vi khoản thu
        /// </summary>
        [DisplayName("Tên phạm vi khoản thu")]
        public string FeeRangeName { get; set; }

        /// <summary>
        /// Khóa ngoại
        /// </summary>
        public Guid? ParentId { get; set; }
    }
}
