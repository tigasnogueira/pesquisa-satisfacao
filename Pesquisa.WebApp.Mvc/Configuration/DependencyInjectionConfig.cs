using Pesquisa.WebApp.Mvc.Extensions;
using Pesquisa.WebApp.Mvc.Interfaces;
using Pesquisa.WebApp.Mvc.Services;

namespace Pesquisa.WebApp.Mvc.Configuration;

public class DependencyInjectionConfig
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddHttpClient<IAuthenticationService, AuthenticationService>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IUser, AspNetUser>();
    }
}
