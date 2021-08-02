using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplication1
{
    public interface IIpInfosDbContext 
    {
        DbSet<IpInfo> IpInfos { get; set; }

    }
}
