using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using Dapper;
using MISA.Core;
using MISA.Core.Entities;
using MISA.Core.Interface;

namespace MISA.Core.Service
{
    public class CustomerService : BaseService, ICustomerService
    {
        ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository _customerRepository) : base(_customerRepository)
        {
            customerRepository = _customerRepository;
        }
        /// <summary>
        /// Lấy khách hàng theo giới tính 
        /// </summary>
        /// <param name="Gender"></param>
        /// <returns></returns>
        public ServiceResult GetCustomerByGender(int Gender)
        {
            var customers = customerRepository.GetCustomerByGender(Gender);
            if(customers.Count() <= 0)
            {
                serviceResult.Msg = Properties.Resources.ErrorMsg_CannotFindData;
                serviceResult.IsValid = false;
                serviceResult.Code = MISACode.NotValid;
            }
            else
            {
                serviceResult.Data = customers;
                serviceResult.Code = MISACode.Success;
                serviceResult.IsValid = true;
            }
            return serviceResult;
        }

        /// <summary>
        /// Lấy khách hàng theo mã khách hàng
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public ServiceResult GetCustomerByCode(string Code)
        {
            var customer = customerRepository.GetCustomerByCustomerCode(Code);
            if (customer == null)
            {
                serviceResult.Msg = Properties.Resources.ErrorMsg_CannotFindData;
                serviceResult.Code = MISACode.NotValid;
                serviceResult.IsValid = false;
            }
            else
            {
                serviceResult.Data = customer;
                serviceResult.Code = MISACode.Success;
                serviceResult.IsValid = true;
            }
            return serviceResult;
        }


        public ServiceResult GetCustomerByPhoneNumber(string phoneNumber)
        {
            var customer = customerRepository.GetCustomerByPhoneNumber(phoneNumber);
            if (customer == null)
            {
                serviceResult.Msg = Properties.Resources.ErrorMsg_CannotFindData;
                serviceResult.Code = MISACode.NotValid;
                serviceResult.IsValid = false;
            }
            else
            {
                serviceResult.Data = customer;
                serviceResult.Code = MISACode.Success;
                serviceResult.IsValid = true;
            }
            return serviceResult;
        }


        //protected override void ValidateData<Customer>(Customer obj, StateCode state)
        //{
        //    base.ValidateData<Customer>(obj,state);
        //    if(state == StateCode.Put)
        //    {
        //        //Validate code
        //        CheckOldValueNotChange<Customer>(obj, "CustomerCode");
        //        //validate phonenumber
        //        CheckOldValueNotChange<Customer>(obj, "PhoneNumber");
        //        //validate citizenCode

        //    }
        //    else
        //    {
        //        CheckDuplicateValue<Customer>(obj,"CustomerCode", "PhoneNumber");
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
        //    Guid customerId = new Guid(Id);
        //    //Lấy dữ liệu được chuyền từ client vào
        //    var NewValue = obj.GetType().GetProperty(NameData).GetValue(obj).ToString();

        //    //Lấy dữ liệu trong database 
        //    var DBCustomer = customerRepository.GetObjectById<Customer>(customerId);
        //    string OldValue = DBCustomer.GetType().GetProperty(NameData).GetValue(DBCustomer).ToString();
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
        //public void CheckDuplicateValue<entity>(entity value,string customerCode, string phoneNumber)
        //{
        //    var listError = new List<string>();
        //    var Entity = value.GetType().GetProperty(customerCode).GetValue(value);
        //    var EntityData = customerRepository.GetCustomerByCustomerCode(Entity.ToString());
        //    if (EntityData != null)
        //    {
        //        serviceResult.IsValid = false;
        //        serviceResult.Code = MISACode.NotDuplicate;
        //        listError.Add(Properties.Resources.CustomerCodeIsDuplicate);
        //    }
        //    Entity = value.GetType().GetProperty(phoneNumber).GetValue(value);
        //    EntityData = customerRepository.GetCustomerByPhoneNumber(Entity.ToString());
        //    if (EntityData != null)
        //    {
        //        serviceResult.IsValid = false;
        //        serviceResult.Code = MISACode.NotDuplicate;
        //        listError.Add(Properties.Resources.PhoneNumberIsDuplicate);
        //    }
        //    serviceResult.Data = listError;
        //}
    }
}
