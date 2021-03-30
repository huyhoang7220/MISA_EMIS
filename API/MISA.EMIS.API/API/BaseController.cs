using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.Core.Entities;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace MISA.EMIS.API.API
{
    /// <summary>
    /// CreatedBy :VXKHANH
    /// CreatedDate: 26/3/2021
    /// </summary>
    /// <typeparam name="entity"></typeparam>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<entity> : ControllerBase
    {
        protected IBaseService _baseService;
        /// <summary>
        /// Hàm khởi tạo
        /// CreatedBy :VXKHANH
        /// CreatedDate: 26/3/2021
        /// </summary>
        /// <param name="baseService"></param>
        public BaseController(IBaseService baseService)
        {
            //Tiêm IBaseService để chỉ định BaseService thực hiện các hàm của interface
            _baseService = baseService;
        }
        /// <summary>
        /// CreatedBy :VXKHANH
        /// CreatedDate: 26/3/2021
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var response = _baseService.GetAll<entity>();
            return Ok(response);
        }

        /// <summary>
        /// CreatedBy :VXKHANH
        /// CreatedDate: 26/3/2021
        /// Lấy dữ liệu theo khóa chính
        /// </summary>
        /// <param name="Id">Giá trị khóa chính</param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public IActionResult GetById(Guid Id)
        {
            try
            {
                var result = _baseService.GetObjectById<entity>(Id);
                if (result.Code == MISACode.Success)
                    return Ok(result.Data);
                else
                    return StatusCode(204, result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    devMsg = e.Message,
                    userMsg = Properties.Resources.ErrorMsg_ExceptionOccur,
                    errorCode = MISACode.Exception.ToString()
                }) ;
            }
        }

        /// <summary>
        /// CreatedBy :VXKHANH
        /// CreatedDate: 26/3/2021
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="obj">Đối tượng thêm</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post( entity obj)
        {
            try
            {
                var check = _baseService.InsertObject<entity>(obj);
                if (check.Code == MISACode.NotValid)
                    return StatusCode(400, check);
                else if(check.Code == MISACode.NotDuplicate)
                {
                    return StatusCode(400, check);
                }
                else if (check.Code == MISACode.NoRecordAdd)
                    return StatusCode(200, check);
                else
                    return StatusCode(201, check);
            }catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    devMsg = ex.Message,
                    userMsg = Properties.Resources.ErrorMsg_ExceptionOccur,
                    errorCode = MISACode.Exception.ToString()
                });
            }
           
        }

        /// <summary>
        /// CreatedBy :VXKHANH
        /// CreatedDate: 26/3/2021
        /// Cập nhật dữ liệu
        /// </summary>
        /// <param name="obj">Đối tượng cần sửa</param>
        /// <returns>IActionResult()</returns>
        [HttpPut]
        public IActionResult Put( entity obj)
        {
            try
            {
                var check = _baseService.UpdateObject<entity>(obj);
                if (check.Code == MISACode.NotValid)
                    return StatusCode(400, check);
                else if (check.Code == MISACode.NoRecordUpdate)
                    return StatusCode(200, check);
                else
                    return StatusCode(200, check);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    devMsg = ex.Message,
                    userMsg = Properties.Resources.ErrorMsg_ExceptionOccur,
                    errorCode = MISACode.Exception.ToString()
                });
            }
        }

        /// <summary>
        /// CreatedBy :VXKHANH
        /// CreatedDate: 26/3/2021
        /// Xóa dữ liệu theo khóa chính
        /// </summary>
        /// <param name="Id">Khóa chính</param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                var check = _baseService.DeleteObject<entity>(Id);
                if (check.Code == MISACode.NoRecordDelete)
                    return StatusCode(200, check);
                else
                    return StatusCode(200, check);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    devMsg = ex.Message,
                    userMsg = Properties.Resources.ErrorMsg_ExceptionOccur,
                    errorCode = MISACode.Exception.ToString()
                });
            }
        }
    }
}
