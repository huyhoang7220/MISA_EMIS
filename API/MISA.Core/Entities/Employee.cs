using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Nhân viên
    /// Created by: Vũ Xuân Khánh (03/03/2021)
    /// </summary>
    public class Employee: CreatedInfor
    {
        #region Declare

        #endregion

        #region Constructor
        /// <summary>
        /// Hàm khởi tạo employee
        /// </summary>
        public Employee():base()
        {
             
        }
        #endregion

        #region Property
        /// <summary>
        /// Khóa chính 
        /// </summary>
        /// 
        [Primarykey]
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên 
        /// </summary>
        [DisplayName("Mã nhân viên")]
        [Required]
        [Duplicate]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Họ tên của nhân viên 
        /// </summary>
        [DisplayName("Tên nhân viên")]
        [Required]
        public string FullName { get; set; }

        /// <summary>
        /// Ngày sinh của nhân viên
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// Tình trạng hôn nhân
        /// </summary>
        public int? MaritalStatus { get; set; }

        /// <summary>
        /// Lương của nhân viên
        /// </summary>
        public double? Salary { get; set; }

        /// <summary>
        /// Địa chỉ email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        [DisplayName("Số điện thoại")]
        [Required]
        [Duplicate]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Số chứng minh thư/ căn cước công đan
        /// </summary>
        [DisplayName("Số CMND/Căn cước công dân")]
        [Required]
        [Duplicate]
        public string CitizenIdentificationCode { get; set; }

        /// <summary>
        /// Ngày cấp chứng minh thư/ căn cước
        /// </summary>
        public DateTime? DateOfIssue{ get; set; }

        /// <summary>
        /// Nơi cấp chứng minh thư/ căn cước
        /// </summary>
        public string PlaceOfIssue { get; set; }

        /// <summary>
        /// vị trí trong công ty
        /// </summary>
        public Guid? PositionId { get; set; }

        /// <summary>
        /// Phòng ban
        /// </summary>
        public Guid? DepartmentId { get; set; }

        /// <summary>
        /// Mã số thuế cá nhân
        /// </summary>
        public string PersonalTaxCode { get; set; }

        /// <summary>
        /// Trạng thái làm việc
        /// </summary>
        public int? WorkStatus { get; set; }

        /// <summary>
        /// Ngày gia nhập công ty
        /// </summary>
        public DateTime? ApplyDate { get; set; }
        #endregion

        #region Methods

        #endregion

        #region Others
        #endregion
    }
}
