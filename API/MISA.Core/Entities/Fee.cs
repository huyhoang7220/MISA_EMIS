using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Lớp khoản thu
    /// Created by : VXKHANH (24/3/2021)
    /// </summary>
    public class Fee :CreatedInfor
    {
        #region Porerty
        /// <summary>
        /// Khoá chính
        /// </summary>
        public Guid FeeId { get; set; }

        /// <summary>
        /// Tên khoản thu
        /// </summary>
        [Required]
        [Duplicate]
        public string FeeName { get; set; }

        /// <summary>
        /// Khóa ngoại nhóm khoản thu
        /// </summary>
        public Guid? FeeGroupId { get; set; }

        /// <summary>
        /// Khóa ngoại mức khoản thu
        /// </summary>
        [Required]
        public Guid FeeRangeId { get; set; }

        /// <summary>
        /// Khóa ngoại đơn vị 
        /// </summary>
        [Required]
        public Guid? UnitFeeId { get; set; }

        /// <summary>
        /// Kỳ thu 
        /// </summary>
        [Required]
        public string TurnFee { get; set; }

        /// <summary>
        /// Mức thu 
        /// </summary>
        [Required]
        public double AmountOfFee { get; set; }

        /// <summary>
        /// Áp dụng miễn giảm
        /// </summary>
        public bool Discount { get; set; }

        /// <summary>
        /// Cho phép xuất hóa đơn
        /// </summary>
        public bool AllowExportBill { get; set; }

        /// <summary>
        /// Cho phép xuất chứng từ
        /// </summary>
        public bool AllowExportLicense { get; set; }

        /// <summary>
        /// Khoản thu bắt buộc
        /// </summary>
        public bool FeeRequired { get; set; }

        /// <summary>
        /// Cho phép hoàn trả 
        /// </summary>
        public bool AllowReturn { get; set; }

        /// <summary>
        /// Thu nội bộ
        /// </summary>
        public bool FeePrivate { get; set; }
        
        /// <summary>
        /// Phân loại đăng ký
        /// </summary>
        public bool TypeRegistion { get; set; }

        /// <summary>
        /// Đã ngừng theo dõi chưa
        /// </summary>
        public bool Follow { get; set; }

        /// <summary>
        /// Tên nhóm khoản thu
        /// </summary>
        public string FeeGroupName { get; set; }
        #endregion
    }

}
