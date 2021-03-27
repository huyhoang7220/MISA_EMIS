using MISA.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Service
{
    /// <summary>
    /// Created by: VXKHANH(26/3/2021)
    /// Service cho nhóm khoản thu
    /// </summary>
    public class FeeGroupService:BaseService, IFeeGroupService
    {
        IFeeGroupRepository feeGroupRepository;
        public FeeGroupService(IFeeGroupRepository _feeGroupRepository) : base(_feeGroupRepository)
        {
            feeGroupRepository = _feeGroupRepository;
        }
    }
}
