using System;
using System.Net.Http;

namespace YANLib.Blazor.Client;

[DependsOn(
    typeof(AbpSettingManagementBlazorWebAssemblyModule),
    typeof(AbpAutofacWebAssemblyModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyLeptonXLiteThemeModule),
    typeof(AbpIdentityBlazorWebAssemblyModule),
    typeof(AbpTenantManagementBlazorWebAssemblyModule),
    typeof(YANLibHttpApiClientModule)
)]
public class YANLibBlazorClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var environment = context.Services.GetSingletonInstance<IWebAssemblyHostEnvironment>();
        var builder = context.Services.GetSingletonInstance<WebAssemblyHostBuilder>();

        ConfigureLocalization();
        //ConfigureAuthentication(builder);
        ConfigureHttpClient(context, environment);
        ConfigureBlazorise(context);
        ConfigureRouter(context);
        //ConfigureMenu(context);
        ConfigureAutoMapper(context);
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<YANLibResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }

    private void ConfigureRouter(ServiceConfigurationContext context)
    {
        Configure<AbpRouterOptions>(options =>
        {
            options.AppAssembly = typeof(YANLibBlazorClientModule).Assembly;
        });
    }

    //private void ConfigureMenu(ServiceConfigurationContext context)
    //{
    //    Configure<AbpNavigationOptions>(options =>
    //    {
    //        options.MenuContributors.Add(new YANLibMenuContributor(context.Services.GetConfiguration()));
    //    });
    //}

    private void ConfigureBlazorise(ServiceConfigurationContext context)
    {
        context.Services
            .AddBootstrap5Providers()
            .AddFontAwesomeIcons();
    }

    //private static void ConfigureAuthentication(WebAssemblyHostBuilder builder)
    //{
    //    builder.Services.AddOidcAuthentication(options =>
    //    {
    //        builder.Configuration.Bind("AuthServer", options.ProviderOptions);
    //        options.UserOptions.NameClaim = OpenIddictConstants.Claims.Name;
    //        options.UserOptions.RoleClaim = OpenIddictConstants.Claims.Role;

    //        options.ProviderOptions.DefaultScopes.Add("YANLib");
    //        options.ProviderOptions.DefaultScopes.Add("roles");
    //        options.ProviderOptions.DefaultScopes.Add("email");
    //        options.ProviderOptions.DefaultScopes.Add("phone");
    //    });
    //}

    private static void ConfigureHttpClient(ServiceConfigurationContext context, IWebAssemblyHostEnvironment environment)
    {
        context.Services.AddTransient(sp => new HttpClient
        {
            BaseAddress = new Uri(environment.BaseAddress)
        });
    }

    private void ConfigureAutoMapper(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<YANLibBlazorClientModule>();
        });
    }
}
