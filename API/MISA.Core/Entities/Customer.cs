using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Thông tin khách hàng
    /// Createdby: VXKHANH(3/3/2021)
    /// </summary>
    public class Customer : CreatedInfor
    {
        #region Declare
        public static List<Customer> listCustomer = new List<Customer>();
        #endregion

        #region Constructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="CustomerCode">Mã khách hàng</param>
        /// <param name="CustomerName">Tên khách hàng</param>
        public Customer(string CustomerCode, string CustomerName)
        {
            CustomerId = Guid.NewGuid();
            this.CustomerCode = CustomerCode;
            this.FullName = CustomerName;
        }

        public Customer()
        {

        }
        #endregion

        #region Property
        /// <summary>
        /// Khóa chỉnh của bảng
        /// </summary>
        /// 
        [Primarykey]
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        [DisplayName("Mã khách hàng")]
        [Required]
        [Duplicate]
        public string CustomerCode { get; set; }

        /// <summary>
        /// Họ tên khách hàng
        /// </summary>
        [DisplayName("Họ và tên")]
        [Required]
        public string FullName { get; set; }

        /// <summary>
        /// Ngày sinh 
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính (0 - Nữ, 1 - Nam)
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// Mã thẻ nhân viên
        /// </summary>
        public string MemberCardCode { get; set; }

        /// <summary>
        /// Khóa ngoại 
        /// </summary>
        public Guid? CustomerGroupId { get; set; }

        /// <summary>
        /// Số điện thoại 
        /// </summary>
        [DisplayName("Số điên thoại")]
        [Required]
        [Duplicate]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// địa chỉ email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Tên công ty của khách hàng
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Mã số thuế của công ty
        /// </summary>
        public string CompanyTaxCode { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        public string Note { get; set; }
        #endregion

        /// <summary>
        /// Tên nhóm khách hàng
        /// </summary>
        public string CustomerGroupName { get; set; }
        #region Methods
        public List<Customer> GetCustomers()
        {
            var customers = new List<Customer>();
            for (int i = 0; i < 10; i++)
            {
                customers.Add(new Customer("KH001", "Vu Xuan Khanh"));
            }
            listCustomer = customers;
            return customers;
        }

        #endregion


        #region Others

        #endregion
    }
}
