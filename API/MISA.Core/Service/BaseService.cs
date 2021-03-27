using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interface;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using static MISA.Core.Entities.CreatedInfor;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MISA.Core.Service
{
    public class BaseService : IBaseService
    {
        /// <summary>
        /// Created By: VXKHANH
        /// Created Date: 10/3/2021
        /// Class xứ lý các vấn đề chung về nghiệp vụ
        /// </summary>


        protected ServiceResult serviceResult;
        IBaseRepository baseRepository;
        public BaseService(IBaseRepository _baseRepository)
        {
            this.baseRepository = _baseRepository;
            serviceResult = new ServiceResult();
        }
        /// <summary>
        /// Lấy toàn bộ danh sách
        /// </summary>
        /// <typeparam name="entity">Class</typeparam>
        /// <returns>Danh sách</returns>
        public IEnumerable<entity> GetAll<entity>()
        {
            var Response = baseRepository.GetAll<entity>();
            return Response;
        }

        /// <summary>
        /// Lấy thông tin theo id
        /// </summary>
        /// <typeparam name="entity">Class</typeparam>
        /// <param name="entityId">Id của đối tượng</param>
        /// <returns>Thông tin 1 bản ghi</returns>
        public ServiceResult GetObjectById<entity>(Guid entityId)
        {
            var Response = baseRepository.GetObjectById<entity>(entityId);
            if (Response == null)
            {
                serviceResult.Msg = "Không tìm thấy thông tin nào";
                serviceResult.Code = MISACode.NoContent;
            }
            else
            {
                serviceResult.Data = Response;
                serviceResult.Code = MISACode.Success;
                serviceResult.Msg = "";
            }
            return serviceResult;
        }

        /// <summary>
        /// Thêm một bản ghi mới
        /// </summary>
        /// <typeparam name="entity">Class</typeparam>
        /// <param name="obj">Đối tượng thêm vào</param>
        /// <returns>Số dòng thay đổi</returns>
        public ServiceResult InsertObject<entity>(entity obj)
        {
            BaseValidate<entity>(obj,StateCode.Post);
            if (serviceResult.IsValid == false)
            {
                serviceResult.Msg = Properties.Resources.ErrorMsg_DataIsNotValidate;
            }
            else
            {
                var rowAffect = baseRepository.InsertObject<entity>(obj);
                if (rowAffect <= 0)
                {
                    serviceResult.Code = MISACode.NoRecordAdd;
                    serviceResult.Data = rowAffect;
                    serviceResult.Msg = Properties.Resources.ErrorMsg_NoRecordAddInDB;
                    return serviceResult;
                }
                else
                {
                    serviceResult.Code = MISACode.Created;
                    serviceResult.Data = rowAffect;
                    serviceResult.Msg = Properties.Resources.InsertSuccess;
                }
            }
            return serviceResult;
        }

        /// <summary>
        /// Cập nhật thông tin về bản ghi mới
        /// </summary>
        /// <typeparam name="entity">Class</typeparam>
        /// <param name="obj">Đối tượng được thay đổi</param>
        /// <returns>Số dòng được thay đổi</returns>
        public ServiceResult UpdateObject<entity>(entity obj)
        {
            //ValidateData<entity>(obj, StateCode.Put);
            BaseValidate<entity>(obj,StateCode.Put);
            if (serviceResult.IsValid == false)
            {
                serviceResult.Code = MISACode.NotValid;
            }
            else
            {
                var rowAffect = baseRepository.UpdateObject<entity>(obj);
                if(rowAffect <= 0)
                {
                    serviceResult.Code = MISACode.NoRecordUpdate;
                    serviceResult.Data = rowAffect;
                    serviceResult.Msg = Properties.Resources.ErrorMsg_UpdateFail;
                    return serviceResult;
                }
                else
                {
                    serviceResult.Code = MISACode.Success;
                    serviceResult.Data = rowAffect;
                    serviceResult.Msg = Properties.Resources.UpdateSuccess;
                }
            }
            return serviceResult;
        }

        /// <summary>
        /// Xóa bản ghi thep id
        /// </summary>
        /// <typeparam name="entity">Class</typeparam>
        /// <param name="Id">Id của bản ghi</param>
        /// <returns>Số dòng bị ảnh hưởng</returns>
        public virtual ServiceResult DeleteObject<entity>(Guid Id)
        {
            var rowAffect = baseRepository.DeleteObject<entity>(Id);
            if (rowAffect <= 0)
            {
                serviceResult.Code = MISACode.NoRecordDelete;
                serviceResult.Data = rowAffect;
                serviceResult.Msg = Properties.Resources.ErrorMsg_DeleteFail;
                return serviceResult;
            }
            else
            {
                serviceResult.Code = MISACode.Success;
                serviceResult.Data = rowAffect;
                serviceResult.Msg = Properties.Resources.DeleteSuccess;
            }
            return serviceResult;
        }

        private ServiceResult BaseValidate<entity>(entity obj, StateCode state)
        {
            serviceResult.IsValid = true;
            var listError = new List<string>();
            var properties = obj.GetType().GetProperties();
            foreach(var property in properties)
            {
                //Kiểm tra các trường bắt buộc nhập
                if (property.IsDefined(typeof(Required), false))
                {
                    // Check bắt buộc nhập
                    var propertyValue = property.GetValue(obj);
                    //property và propertyValue đều là object nên giá trị mặc định là  = null
                    if(propertyValue == null || propertyValue.ToString() == "")
                    {
                        serviceResult.IsValid = false;
                        serviceResult.Msg = Properties.Resources.ErrorMsg_DataIsNotValidate;
                        serviceResult.Code = MISACode.NotValid;
                        var displayName = property.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().Single().DisplayName;
                        listError.Add(displayName + Properties.Resources.RequiredValue);
                    }
                }
                //Kiểm tra dữ lieju trùng lặp
                if(property.IsDefined(typeof(Duplicate), false))
                {
                    bool IsChange = false;
                    if (state == StateCode.Put)
                    {
                        var Id = obj.GetType().GetProperty($"{typeof(entity).Name}Id").GetValue(obj).ToString();
                        Guid GuidId = new Guid(Id);
                        var DBEntity = baseRepository.GetObjectById<entity>(GuidId);
                        var CurrentValue = property.GetValue(obj).ToString();
                        var DBValue = DBEntity.GetType().GetProperty(property.Name).GetValue(DBEntity).ToString();
                        if (CurrentValue != DBValue)
                        {
                            IsChange = true;
                        }
                    }
                    else
                    {
                        IsChange = true;
                    }
                    if(IsChange)
                    {
                        var entityValue = baseRepository.GetEntityByProperty<entity>(property.Name, property.GetValue(obj));
                        if (entityValue != null)
                        {
                            serviceResult.IsValid = false;
                            serviceResult.Msg = Properties.Resources.ErrorMsg_DataIsNotValidate;
                            var displayName = property.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().Single().DisplayName;
                            listError.Add(displayName + Properties.Resources.DuplicatedValue);
                        }
                    }
                    //Kiểm tra trùng dữ liệu
                    
                }
            }
            serviceResult.Data = listError;
            return serviceResult;
        }
       
    }
}
