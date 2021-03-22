using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MISA.CUKCUK.API.API
{
    public class CustomersController : BaseController<Customer>
    {
        ICustomerService _customerService;
        public CustomersController(ICustomerService customerService,IBaseService baseService):base(customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("gender/{Gender}")]
        public IActionResult GetCustomerByGender(int Gender)
        {
            try
            {
                var result = _customerService.GetCustomerByGender(Gender);
                if (result.Code == MISACode.NotValid)
                {
                    return StatusCode(400, result);
                }
                else
                {
                    return StatusCode(200, result.Data);
                }
            }catch(Exception e)
            {
                return StatusCode(500, new
                {
                    devMsg = e.Message,
                    userMsg = Properties.Resources.ErrorMsg_ExceptionOccur,
                    errorCode = MISACode.Exception.ToString()
                }) ;
            }
        }

        [HttpGet("CustomerCode/{Code}")]
        public IActionResult GetCustomerByCode(string Code)
        {
            try
            {
                var result = _customerService.GetCustomerByCode(Code);
                if (result.Code == MISACode.NotValid)
                {
                    return StatusCode(400, result);
                }
                else
                {
                    return StatusCode(200, result.Data);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    devMsg = e.Message,
                    userMsg = Properties.Resources.ErrorMsg_ExceptionOccur,
                    errorCode = MISACode.Exception.ToString()
                });
            }
        }
    }
}
