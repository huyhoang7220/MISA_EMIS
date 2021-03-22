using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interface
{
    public interface ICustomerService: IBaseService
    {
        /// <summary>
        /// Lấy khách hàng theo giới tính 0 - Nữ , 1 - Nam , 2 - Khác
        /// </summary>
        /// <param name="Gender"></param>
        /// <returns>List Customer</returns>
        ServiceResult GetCustomerByGender(int Gender);

        /// <summary>
        /// Lấy khách hàng theo mã khách hàng
        /// </summary>
        /// <param name="Code">Mã khách hàng</param>
        /// <returns>Customer</returns>
        ServiceResult GetCustomerByCode(string Code);

        /// <summary>
        /// Lấy danh sách khách hàng theo sô điện thoại
        /// </summary>
        /// <param name="phoneNumber">Số điện thoại</param>
        /// <returns>Đối tượng khách hàng</returns>
        ServiceResult GetCustomerByPhoneNumber(string phoneNumber);
    }
}
