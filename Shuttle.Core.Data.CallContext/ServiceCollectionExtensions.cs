using Microsoft.Extensions.DependencyInjection;
using Shuttle.Core.Contract;

namespace Shuttle.Core.Data.CallContext
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCallContextDatabaseContextCache(this IServiceCollection services)
        {
            Guard.AgainstNull(services, nameof(services));

            services.AddSingleton<IDatabaseContextCache, ContextDatabaseContextCache>();

            return services;
        }
    }
}