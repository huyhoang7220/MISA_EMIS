using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interface;
using MISA.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace MISA.EMIS.API.API
{

    /// <summary>
    /// Created by : VXKHANH(26/3/2021)
    /// </summary>
    public class FeeController : BaseController<Fee>
    {
        IFeeService feeService;
        public FeeController(IFeeService _feeService) : base(_feeService)
        {
            feeService = _feeService;
        }

        [HttpGet("FeeName/{feeName}")]
        public IActionResult GetFeeByFeeName(string feeName)
        {
            try
            {
                var result = feeService.GetFeeByFeeName(feeName);
                if (result.Code == MISACode.Success)
                {
                    return StatusCode(200, result.Data);
                }
                else
                {
                    return StatusCode(204, result);
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

        /// <summary>
        /// Endpoint: fee/feestopfollow
        /// </summary>
        /// <returns></returns>
        [HttpGet("feestopfollow")]
        public IActionResult GetFeeIsStopFollow()
        {
            try
            {
                var result = feeService.GetFeeIsStopFollow();
                return StatusCode(200, result.Data);
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

        [HttpDelete("DeleteMulti")]
        public IActionResult DeleteMultiFee(List<Guid> feeIds)
        {
            
        }
    }
}
