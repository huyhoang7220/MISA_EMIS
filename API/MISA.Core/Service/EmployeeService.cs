using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.Core.Service
{
    public class EmployeeService: BaseService, IEmployeeService
    {


        IEmployeeRepository employeeRepository;
        public EmployeeService(IEmployeeRepository _employeeRepository) : base(_employeeRepository)
        {
            employeeRepository = _employeeRepository;
        }

        public ServiceResult GetEmployeeByGender(int Gender)
        {
            var employees = employeeRepository.GetEmployeeByGender(Gender);
            if(employees.Count() <= 0)
            {
                serviceResult.Msg = Properties.Resources.ErrorMsg_CannotFindData;
                serviceResult.Code = MISACode.NoContent;
            }
            else
            {
                serviceResult.Data = employees;
                serviceResult.Code = MISACode.Success;
            }
            return serviceResult;
        }

        public ServiceResult GetEmployeeByEmployeeCode(string Code)
        {
            var employee = employeeRepository.GetEmployeeByEmployeeCode(Code);
            if(employee == null)
            {
                serviceResult.Msg = Properties.Resources.ErrorMsg_CannotFindData;
                serviceResult.Code = MISACode.NoContent;
            }
            else
            {
                serviceResult.Data = employee;
                serviceResult.Code = MISACode.Success;
            }
            return serviceResult;
        }



        public ServiceResult GetEmployeeByPhoneNumber(string phoneNumber)
        {
            var employee = employeeRepository.GetEployeeByPhoneNumber(phoneNumber);
            if(employee != null)
            {
                serviceResult.Code = MISACode.Success;
                serviceResult.Data = employee;
            }
            else
            {
                serviceResult.Msg = Properties.Resources.ErrorMsg_CannotFindData;
                serviceResult.Code = MISACode.NoContent;
            }
            return serviceResult;
        }
        //protected override void ValidateData<Employee>(Employee obj, StateCode state)
        //{
        //    base.ValidateData<Employee>(obj, state);
        //    if (state == StateCode.Put)
        //    {
        //        var Id = obj.GetType().GetProperty("EmployeeId").GetValue(obj).ToString();
        //        //Check mã nhân viên

        //        //Check số điện thoại
        //    }
        //    else
        //    {
        //        var employeeCode = obj.GetType().GetProperty("EmployeeCode").GetValue(obj).ToString();
        //        var employee = employeeRepository.GetEmployeeByEmployeeCode(employeeCode);
        //        if (employee != null)
        //        {
        //            serviceResult.IsValid = false;
        //            serviceResult.Code = MISACode.NotDuplicate;
        //            serviceResult.Msg = Properties.Resources.ErrorMsg_NotDuplicateCode;
        //        }
        //    }

        //}

        /// <summary>
        /// Hàm kiểm tra dữ lệu có bị thay đổi hay không 
        /// </summary>
        /// <typeparam name="entity"></typeparam>
        /// <param name="obj">Đối tượng</param>
        /// <param name="NameData">Tên cột cần kiểm tra</param>
        //public void CheckOldValueNotChange<entity>(entity obj, string NameData)
        //{
        //    var Id = obj.GetType().GetProperty("CustomerId").GetValue(obj).ToString();
        //    Guid employeeId = new Guid(Id);
        //    //Lấy dữ liệu được chuyền từ client vào
        //    var NewValue = obj.GetType().GetProperty(NameData).GetValue(obj).ToString();

        //    //Lấy dữ liệu trong database 
        //    var DBEmployee = employeeRepository.GetObjectById<Customer>(employeeId);
        //    string OldValue = DBEmployee.GetType().GetProperty(NameData).GetValue(DBEmployee).ToString();
        //    //Kiểm tra xem hai dữ liệu cũ và mới có khác nhau không? 
        //    //Nếu không thì duyệt để tìm xem dữ liệu mới có bị trùng với dữ liệu khách trong DB hay không.
        //    if (OldValue != NewValue)  // trường mã đã bị thay đổi => cần kiểm tra mã mới có trong DB hay chưa
        //    {
        //        //Check trùng mã 
        //        CheckDuplicateValue<entity>(obj, NameData, NameData);
        //    }
        //    //Nếu dữ liệu mới và cũ bằng nhau thì không kiểm tra trùng nhau giữa các trường dữ liệu này
        //}

        /// <summary>
        /// Created by : VXKHANH(20/3/2021)
        /// Hàm kiểm tra trùng dữ liệu
        /// </summary>
        /// <typeparam name="entity">Type</typeparam>
        /// <param name="value">đối tượng</param>
        /// <param name="field">tên của trường muốn kiểm tra (VD: CustomerCode, CustomerPhoneNumber)</param>
        //public void CheckDuplicateValue<entity>(entity value, string employeeCode, string phoneNumber)
        //{
        //    var Entity = value.GetType().GetProperty(employeeCode).GetValue(value);
        //    var EntityData = employeeRepository.GetEmployeeByEmployeeCode(Entity.ToString());
        //    if (EntityData != null)
        //    {
        //        serviceResult.IsValid = false;
        //        serviceResult.Code = MISACode.NotDuplicate;
        //        serviceResult.Msg = Properties.Resources.ErrorMsg_NotDuplicateCode;
        //        return;
        //    }
        //    Entity = value.GetType().GetProperty(phoneNumber).GetValue(value);
        //    EntityData = employeeRepository.GetEployeeByPhoneNumber(Entity.ToString());
        //    if (EntityData != null)
        //    {
        //        serviceResult.IsValid = false;
        //        serviceResult.Code = MISACode.NotDuplicate;
        //        serviceResult.Msg = Properties.Resources.PhoneNumberIsDuplicate;
        //        return;
        //    }
        //}
    }
}
