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
    public class EmployeesController : BaseController<Employee>
    {
        IEmployeeService employeeService;
        public EmployeesController(IEmployeeService _employeeService, IBaseService baseService): base(_employeeService){
            employeeService = _employeeService;
        }

        [HttpGet("gender/{Gender}")]
        public IActionResult GetEmployeeByGender(int Gender)
        {
            var employees = employeeService.GetEmployeeByGender(Gender);
            return Ok(employees);
        }

        [HttpGet("employeecode/{Code}")]
        public IActionResult GetEmployeeByCode(string Code)
        {
            var employee = employeeService.GetEmployeeByEmployeeCode(Code);
            return Ok(employee);
        }
    }
}
