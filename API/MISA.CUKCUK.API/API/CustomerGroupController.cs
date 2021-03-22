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
    /// <summary>
    /// Created by : VXKHANH
    /// Created date : 10/3/2021
    /// Controller của nhóm khách hàng
    /// </summary>
    public class CustomerGroupsController : BaseController<CustomerGroup>
    {
        public CustomerGroupsController(IBaseService baseService) : base(baseService)
        {

        }
    }
}
