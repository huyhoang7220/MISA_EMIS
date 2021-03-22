using Dapper;
using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using MISA.Core.Interface;

namespace MISA.Instructure.DataAccess
{
    public class CustomerRepository:BaseRepository, ICustomerRepository
    {
        public Customer GetCustomerByCustomerCode(string CustomerCode)
        {
            string procName = "proc_Get_CustomerByCustomerCode";
            var customer = dbConnection.Query<Customer>(procName, new { CustomerCode = CustomerCode }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return customer;
        }

        public IEnumerable<Customer> GetCustomerByGender(int Gender)
        {
            string procName = "proc_Get_CustomerByGender";
            var customers = dbConnection.Query<Customer>(procName, new { Gender = Gender }, commandType: CommandType.StoredProcedure);
            return customers;
        }

        /// <summary>
        /// Lấy ra nhân viên có số điện thoại tương ứng
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public Customer GetCustomerByPhoneNumber(string phoneNumber)
        {
            string procName = "proc_FindCustomerPhoneNumber";
            var customer = dbConnection.Query<Customer>(procName, new { PhoneNumber = phoneNumber }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return customer;
        }
    }
}
