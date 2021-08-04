using System;
using System.Collections.Generic;

#nullable disable

namespace EfCore.Models
{
    public partial class UserInfo
    {
        public int UserInfoId { get; set; }
        public string EmpNo { get; set; }
        public string CmpCode { get; set; }
        public List<IpInfo> IpInfos { get; set; }
    }
}
