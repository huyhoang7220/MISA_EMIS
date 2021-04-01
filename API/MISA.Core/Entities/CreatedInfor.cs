using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Created By VXKHANH
    /// Created Date: 24/03/2021
    /// </summary>
    public class CreatedInfor
    {
        /// <summary>
        /// Bắt buộc nhập (Không để trống)
        /// </summary>
        [AttributeUsage(AttributeTargets.Property)]
        public class Required : Attribute
        {

        }

        /// <summary>
        /// Không được trùng nhau
        /// </summary>
        [AttributeUsage(AttributeTargets.Property)]
        public class Duplicate : Attribute
        {

        }

        /// <summary>
        /// Khóa chính cho property
        /// </summary>
        [AttributeUsage(AttributeTargets.Property)]
        public class Primarykey : Attribute
        {

        }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa gần nhất 
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Trạng thái của class (Get , Post , Put , Delete)
        /// </summary>
        public StateCode State { get; set; }
    }
}
