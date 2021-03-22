using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.Instructure.DataAccess
{
    public class EmployeeRepository:BaseRepository, IEmployeeRepository
    {
        public IEnumerable<Employee> GetEmployeeByGender(int Gender)
        {
            string procName = "proc_Get_CustomerByGender";
            var employees = dbConnection.Query<Employee>(procName, new { Gender = Gender }, commandType: CommandType.StoredProcedure);
            return employees;
        }

        public Employee GetEmployeeByEmployeeCode(string Code)
        {
            string procName = "proc_Get_EmployeeByEmployeeCode";
            Employee employee = dbConnection.Query<Employee>(procName, new { EmployeeCode = Code }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return employee;
        }

        public Employee GetEployeeByPhoneNumber(string phoneNumber)
        {
            string procName = "proc_Get_EmployeeByPhoneNumber";
            var employee = dbConnection.Query<Employee>(procName, new { PhoneNumber = phoneNumber }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return employee;
        }
    }
}
