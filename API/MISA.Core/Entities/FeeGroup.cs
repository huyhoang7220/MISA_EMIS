using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Class Nhóm khoản thu
    /// Created by : VXKHANH (24/3/2021)
    /// </summary>
    public class FeeGroup:CreatedInfor
    {
        
        #region Property
        /// <summary>
        /// Khóa chính 
        /// </summary>
        [Primarykey]
        public Guid FeeGroupId { get; set; }

        /// <summary>
        /// Tên nhóm khoản thu
        /// </summary>
        [Required]
        [DisplayName("Tên nhóm khoản thu")]
        public string FeeGroupName { get; set; }

        /// <summary>
        /// Id nhóm khoản thu cha
        /// </summary>
        public Guid? ParentId { get; set; }
        #endregion
    }
}
