using MISA.Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interface
{
    /// <summary>
    /// created by: VXKHANH(26/3/2021)
    /// </summary>
    public interface IFeeRepository:IBaseRepository
    {
        /// <summary>
        /// Lấy ra khoản thu có tên khoản thu tương ứng
        /// </summary>
        /// <param name="feeName"></param>
        /// <returns></returns>
        Fee GetFeeByFeeName(string feeName);

        IEnumerable GetFeeIsStopFollow();
    }
}
