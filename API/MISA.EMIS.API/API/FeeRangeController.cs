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
    /// Cerated by VXKHANH(26/3/2021)
    /// </summary>
    public class FeeRangeController : BaseController<FeeRange>
    {
        public FeeRangeController(IFeeRangeService _feeRangeService) : base(_feeRangeService)
        {

        }
      
    }
}
