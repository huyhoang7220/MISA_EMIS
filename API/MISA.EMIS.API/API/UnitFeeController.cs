using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.EMIS.API.API
{
    /// <summary>
    /// CreatedBy :VXKHANH
    /// CreatedDate: 26/3/2021
    /// Controller đơn vị khoản thu
    /// </summary>
    public class UnitFeeController : BaseController<UnitFee>
    {
        IUnitFeeService unitFeeService;
        public UnitFeeController(IUnitFeeService _unitFeeService) : base(_unitFeeService)
        {
            unitFeeService = _unitFeeService;
        }
    }
}
