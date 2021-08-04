using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

#nullable disable

[Flags]
public enum SendingTypes : short
{
    None = 0,
    Mail = 1,
    Sms = 2,
    BackOffice = 8//16384
}

namespace EfCore.Models
{
    [Index(nameof(IpAddress))]
    public partial class IpInfo
    {
        public int IpInfoId { get; set; }

        [MaxLength(16)]
        public byte[] IpAddress { get; set; }

        public SendingTypes PermissionSendingType { get; set; }
        public bool? PermissionYn { get; set; }
        public bool? UseYn { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}
