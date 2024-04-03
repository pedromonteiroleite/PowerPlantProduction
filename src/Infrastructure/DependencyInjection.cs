using Application.Common.Interfaces;
using Infrastructure.DataAccess;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IApplicationDbService, SqlServerDbService>();
            return services;
        }
    }
}
