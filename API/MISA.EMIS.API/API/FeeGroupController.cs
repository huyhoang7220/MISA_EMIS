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
    /// Controller Nhóm khách hàng
    /// CreatedBy :VXKHANH
    /// CreatedDate: 26/3/2021
    /// </summary>
    public class FeeGroupController : BaseController<FeeGroup>
    {
        IFeeGroupService feeGroupService;
        public FeeGroupController(IFeeGroupService _feeGroupService) : base(_feeGroupService)
        {
            feeGroupService = _feeGroupService;
        }
    }
}
