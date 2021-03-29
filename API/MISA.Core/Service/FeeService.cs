using MISA.Core.Entities;
using MISA.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Service
{
    /// <summary>
    /// Creatd by: VXKHANH(26/3/2021)
    /// Service cho khoản thu
    /// </summary>
    public class FeeService:BaseService, IFeeService
    {
        IFeeRepository feeRepository;
        public FeeService(IFeeRepository _feeRepository):base(_feeRepository)
        {
            feeRepository = _feeRepository;
        }

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

        public ServiceResult DeleteMulti(List<Guid> feeIds)
        {
            var important = false;
            foreach(Guid feeid in feeIds)
            {
                
            }
            return serviceResult;
        }

        /// <summary>
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
