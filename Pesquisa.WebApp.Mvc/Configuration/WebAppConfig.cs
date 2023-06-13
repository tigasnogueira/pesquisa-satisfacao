using Pesquisa.WebApp.Mvc.Extensions;

namespace Pesquisa.WebApp.Mvc.Configuration;

public static class WebAppConfig
{
    public static void AddMvcConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllersWithViews();

        services.Configure<AppSettings>(configuration);
    }



    public static void UseMvcConfiguration(this IApplicationBuilder app)
    {
        app.UseDeveloperExceptionPage();
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseIdentityConfiguration();

        app.UseMiddleware<ExceptionMiddleware>();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}
