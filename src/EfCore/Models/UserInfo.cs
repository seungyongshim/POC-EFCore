using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EfCore.Models
{
    public partial class UserInfo
    {
        public int UserInfoId { get; set; }
        [MaxLength(5)]
        public byte[] EmpNo { get; set; }
        public string EmpName { get; set; }
        [MaxLength(2)]
        public byte[] CmpCode { get; set; }

        public byte[] DeptCode { get; set; }

        public List<IpInfo> IpInfos { get; set; }
    }
}
