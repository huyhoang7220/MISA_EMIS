using MISA.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Service
{
    /// <summary>
    /// created by : VXKHANH(26/3/2021)
    /// </summary>
    public class UnitFeeService:BaseService, IUnitFeeService
    {
        IUnitFeeRepository unitFeeRepository;
        public UnitFeeService(IUnitFeeRepository _unitFeeRepository) : base(_unitFeeRepository)
        {
            unitFeeRepository = _unitFeeRepository;
        }
    }
}
