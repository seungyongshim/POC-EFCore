using System.Threading;
using System.Threading.Tasks;
using EfCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Abstractions
{
   
    public interface IIpInfosDbContext
    {
        DbSet<IpInfo> IpInfos { get; set; }

        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }

    public interface IUserInfosDbContext
    {
        DbSet<UserInfo> UserInfos { get; set; }

        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
