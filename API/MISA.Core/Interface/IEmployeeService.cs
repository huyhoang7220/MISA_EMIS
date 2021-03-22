using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Core.Interface
{
    public interface IEmployeeService : IBaseService
    {
        /// <summary>
        /// Lấy danh sách nhân viên theo giới tính
        /// </summary>
        /// <param name="Gender"></param>
        /// <returns>Trả về danh sách nhân viên | nếu không có thì trả về 1 danh sách rỗng (count = 0)</returns>
        ServiceResult GetEmployeeByGender(int Gender);

        /// <summary>
        ///Lấy ra nhân viên có mã nhân viên tương ứng
        /// </summary>
        /// <param name="Code">Mã nhân viên</param>
        /// <returns>Một đối tượng nhân viên | nếu không có trả về null</returns>
        ServiceResult GetEmployeeByEmployeeCode(string Code);

        ServiceResult GetEmployeeByPhoneNumber(string phoneNumber);
    }
}
