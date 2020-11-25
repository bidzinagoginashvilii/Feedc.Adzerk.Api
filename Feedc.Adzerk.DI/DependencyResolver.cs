using Microsoft.Extensions.Configuration;
using Feedc.Adzerk.Application.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Feedc.Adzerk.Infrastructure.Configuration;

namespace Feedc.Adzerk.DI
{
    public class DependencyResolver
    {
        private IConfiguration Configuration { get; }

        public DependencyResolver(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServiceCollection Resolve(IServiceCollection services)
        {
            services ??= new ServiceCollection();

            var adzerkConfig = Configuration.GetSection(nameof(AdzerkConfig)).Get<AdzerkConfig>();
            services.AddSingleton(adzerkConfig);

            services.AddScoped<QueryExecutor, QueryExecutor>();
            services.AddScoped<CommandExecutor, CommandExecutor>();

            return services;
        }
    }
}
