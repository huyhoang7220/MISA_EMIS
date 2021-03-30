using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Created by: VXKHANH
    /// Created date: 26/3/2021
    /// </summary>
    public class UnitFee:CreatedInfor
    {
        #region Property
        /// <summary>
        /// Khóa chính của đơn vị khoản thu
        /// </summary>
        [Primarykey]
        public Guid UnitFeeId { get; set; }

        /// <summary>
        /// Tên đơn vị khoản thu
        /// </summary>
        [Required]
        public string UnitFeeName { get; set; }
        
        #endregion
    }
}
