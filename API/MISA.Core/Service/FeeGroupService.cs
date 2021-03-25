using MISA.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Service
{
    public class FeeGroupService:BaseService, IFeeGroupService
    {
        IFeeGroupRepository feeGroupRepository;
        public FeeGroupService(IFeeGroupRepository _feeGroupRepository) : base(_feeGroupRepository)
        {
            feeGroupRepository = _feeGroupRepository;
        }
    }
}
