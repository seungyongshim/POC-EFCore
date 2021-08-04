namespace EfCore
{
    using EfCore.Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class Extensions
    {
        public static IServiceCollection AddEfCore(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AUMSContext>(options =>
                options
                       //.UseLazyLoadingProxies()
                       .UseSqlServer(connectionString));

            return services;
        }
    }
}
