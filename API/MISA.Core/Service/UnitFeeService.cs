using MISA.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Service
{
    /// <summary>
    /// Created by : VXKHANH
    /// Created date: 26/3/2021
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
