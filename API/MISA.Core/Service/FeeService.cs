﻿using MISA.Core.Entities;
using MISA.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Service
{
    /// <summary>
    /// Creatd by: VXKHANH
    /// Created date: 26/3/2021
    /// Service cho khoản thu
    /// </summary>
    public class FeeService:BaseService, IFeeService
    {
        IFeeRepository feeRepository;
        public FeeService(IFeeRepository _feeRepository):base(_feeRepository)
        {
            feeRepository = _feeRepository;
        }
        /// <summary>
        /// Creatd by: VXKHANH
        /// Created date: 26/3/2021
        /// Lấy khoản thu theo tên khoản thu
        /// </summary>
        /// <param name="feeName">Tên khoản thu</param>
        /// <returns>Đối tượng khoản thu</returns>
        public ServiceResult GetFeeByFeeName(string feeName)
        {
            var fee = feeRepository.GetFeeByFeeName(feeName);
            if(fee != null)
            {
                serviceResult.Data = fee;
                serviceResult.Code = MISACode.Success;
            }
            else
            {
                serviceResult.Data = null;
                serviceResult.Msg = Properties.Resources.ErrorMsg_CannotFindData;
                serviceResult.Code = MISACode.NoContent;
            }
            return serviceResult;
        }

        /// <summary>
        /// Creatd by: VXKHANH
        /// Created date: 26/3/2021
        /// Lấy danh sách khoản thu ngừng theo dõi
        /// </summary>
        /// <returns></returns>
        public ServiceResult GetFeeIsStopFollow()
        {
            var result = feeRepository.GetFeeIsStopFollow();
            serviceResult.Data = result;
            return serviceResult;
        }

        /// <summary>
        /// Creatd by: VXKHANH
        /// Created date: 26/3/2021
        /// Hàm xóa khoản thu có kiểm tra khoản 
        /// Nếu là 'Học phí' thì không cho phép xóa
        /// </summary>
        /// <typeparam name="entity"></typeparam>
        /// <param name="Id"></param>
        /// <returns></returns>
        public override ServiceResult DeleteObject<entity>(Guid Id)
        {
            if(CheckFeeName(Id) == true)
            {
                return serviceResult;
            }
            var rowAffect = feeRepository.DeleteObject<entity>(Id);
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

        /// <summary>
        /// Creatd by: VXKHANH
        /// Created date: 26/3/2021 
        /// Xóa nhiều khoản thu 1 lúc
        /// </summary>
        /// <param name="feeIds">Danh sách id những khoản thu cần xáo</param>
        /// <returns></returns>
        public ServiceResult DeleteMulti(List<Guid> feeIds)
        {
            var important = false;
            foreach(Guid feeId in feeIds)
            {
                var fee = feeRepository.GetObjectById<Fee>(feeId);
                var system = fee.GetType().GetProperty("Important").GetValue(fee);
                if (Convert.ToBoolean(system) == true)
                {
                    important = true;
                }
            }
            //Important == false => Không có dữ liệu nào là dữ liệu của hệ thống . Cho phép xóa
            if (important == false)
            {
                var rowaffect = 0;
                foreach (Guid feeId in feeIds)
                {
                    rowaffect += feeRepository.DeleteObject<Fee>(feeId);
                }
                serviceResult.Data = rowaffect;
                serviceResult.Code = MISACode.Success;
                serviceResult.Msg = Properties.Resources.DeleteSuccess;
            }
            else
            {
                serviceResult.Msg = Properties.Resources.NotAllowDeleteThisData;
                serviceResult.Code = MISACode.NoRecordDelete;
                serviceResult.Data = 0;
            }
            return serviceResult;
        }

        /// <summary>
        /// Creatd by: VXKHANH
        /// Created date: 26/3/2021
        /// Hàm kiểm tra trường tên xem có phải học phí không. Nếu đúng thì không cho phép xóa
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool CheckFeeName(Guid Id)
        {
            var fee = feeRepository.GetObjectById<Fee>(Id);
            if(fee != null)
            {
                var FeeName = fee.GetType().GetProperty("Important").GetValue(fee);
                if (Convert.ToBoolean(FeeName) == true)
                {
                    serviceResult.Code = MISACode.NoRecordDelete;
                    serviceResult.Msg = Properties.Resources.NotAllowDeleteThisData;
                    serviceResult.Data = 0;
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

       
    }
}
