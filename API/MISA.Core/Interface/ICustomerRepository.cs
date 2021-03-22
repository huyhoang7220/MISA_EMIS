using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interface
{
    public interface ICustomerRepository: IBaseRepository
    {
        /// <summary>
        /// Lấy khách hàng theo mã khách hàng
        /// </summary>
        /// <param name="CustomerCode">Mã khách hàng</param>
        /// <returns>Đối tượng khách hàng</returns>
        Customer GetCustomerByCustomerCode(string CustomerCode);

        /// <summary>
        /// Lấy khách hàng theo giới tính
        /// </summary>
        /// <param name="Gender"></param>
        /// <returns></returns>
        IEnumerable<Customer> GetCustomerByGender(int Gender);

        Customer GetCustomerByPhoneNumber(string phoneNumber);
    }
}
