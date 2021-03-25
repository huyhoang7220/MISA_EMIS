using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interface;
using MISA.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.EMIS.API.API
{
    public class FeeController : BaseController<Fee>
    {
        IFeeService feeService;
        public FeeController(IFeeService _feeService) : base(_feeService)
        {
            feeService = _feeService;
        }
    }
}
