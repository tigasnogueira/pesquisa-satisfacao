using Pesquisa.ClientApi.Context;
using Pesquisa.ClientApi.Interfaces;
using Pesquisa.ClientApi.Repository;
using Pesquisa.ClientApi.Services;

namespace Pesquisa.ClientApi.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddScoped<ClientDbContext>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IClientService, ClientService>();

        return services;
    }
}
