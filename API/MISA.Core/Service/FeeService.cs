using MISA.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Service
{
    public class FeeService:BaseService, IFeeService
    {
        IFeeRepository feeRepository;
        public FeeService(IFeeRepository _feeRepository):base(_feeRepository)
        {
            feeRepository = _feeRepository;
        }
    }
}
