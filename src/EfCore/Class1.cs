namespace EfCore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EfCore.Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class Extensions
    {
        public static IServiceCollection AddEfCore(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IIpInfosDbContext, AUMSContext>();
            services.AddScoped<IUserInfosDbContext, AUMSContext>();
            services.AddDbContext<AUMSContext>(options =>
                options
                       //.UseLazyLoadingProxies()
                       .UseSqlServer(connectionString));

            return services;
        }
    }
}
