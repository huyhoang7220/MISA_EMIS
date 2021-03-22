using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interface
{
    public interface IEmployeeRepository:IBaseRepository
    {
        /// <summary>
        /// Lấy nhân viên theo giới tính
        /// </summary>
        /// <param name="Gender">Giới tính</param>
        /// <returns>Danh sách nhân viên</returns>
        IEnumerable<Employee> GetEmployeeByGender(int Gender);

        /// <summary>
        /// Lấy Nhân viên theo mã nhân viên
        /// </summary>
        /// <param name="Code">Mã nhân viên</param>
        /// <returns>Một nhân viên mới mã nhân viên tương ứng hoặc null</returns>
        Employee GetEmployeeByEmployeeCode(string Code);

        /// <summary>
        /// Lấy ra nhân viên có số điện thoại tương ứng
        /// </summary>
        /// <param name="phoneNumber">Số điện thoại</param>
        /// <returns>Đối tượng nhân viên</returns>
        Employee GetEployeeByPhoneNumber(string phoneNumber);
    }
}
