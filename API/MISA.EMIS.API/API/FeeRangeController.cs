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
    /// Cerated by: VXKHANH
    /// Created date: 26/3/2021
    /// Controller Phạm vi thu
    /// </summary>
    public class FeeRangeController : BaseController<FeeRange>
    {
        IFeeRangeService feeRangeService;
        public FeeRangeController(IFeeRangeService _feeRangeService) : base(_feeRangeService)
        {
            feeRangeService = _feeRangeService;
        }
      
    }
}
