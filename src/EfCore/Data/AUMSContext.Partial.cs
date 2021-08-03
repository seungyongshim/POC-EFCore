namespace EfCore.Data
{
    using System.Threading;
    using System.Threading.Tasks;

    public partial class AUMSContext : IIpInfosDbContext, IUserInfosDbContext
    {
        public Task<int> CommitAsync(CancellationToken cancellationToken) =>
            base.SaveChangesAsync(cancellationToken);
    }
}
