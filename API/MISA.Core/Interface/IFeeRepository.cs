using MISA.Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interface
{
    /// <summary>
    /// created by: VXKHANH
    /// Created by: 26/3/2021
    /// </summary>
    public interface IFeeRepository:IBaseRepository
    {
        /// <summary>
        /// Creatd by: VXKHANH
        /// Created date: 26/3/2021
        /// Lấy ra khoản thu có tên khoản thu tương ứng
        /// </summary>
        /// <param name="feeName"></param>
        /// <returns></returns>
        Fee GetFeeByFeeName(string feeName);

        /// <summary>
        /// Creatd by: VXKHANH
        /// Created date: 26/3/2021
        /// Hàm lấy danh sách ngừng theo dõi
        /// </summary>
        /// <returns>Danh sách khoản thu ngừng theo dõi</returns>
        IEnumerable GetFeeIsStopFollow();
    }
}
