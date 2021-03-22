using MISA.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Service
{
    class CustomerGroupService:BaseService
    {
        IBaseRepository baseRepository;
        public CustomerGroupService(IBaseRepository _baseRepository) : base(_baseRepository)
        {
            baseRepository = _baseRepository;
        }
    }
}
