using MISA.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Service
{
    public class FeeRangeService:BaseService, IFeeRangeService
    {
        IFeeRangeRepository feeRangeRepository;
        public FeeRangeService(IFeeRangeRepository _feeRangeRepository) : base(_feeRangeRepository)
        {
            feeRangeRepository = _feeRangeRepository;
        }
    }
}
