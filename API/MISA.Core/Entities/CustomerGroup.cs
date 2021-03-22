using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class CustomerGroup:CreatedInfor
    {
        /// <summary>
        /// Khóa chính 
        /// </summary>
        [Primarykey]
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// Tên nhóm khách hàng
        /// </summary>
        [Required]
        public string CustomerGroupName { get; set; }

        /// <summary>
        /// Id nhóm khách hàng cha
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// Mô tả cho nhóm khách hàng
        /// </summary>
        public string Description { get; set; }
    }
}
