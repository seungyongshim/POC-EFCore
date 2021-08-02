using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplication1
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
