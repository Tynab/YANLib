//using Microsoft.Extensions.Configuration;
//using System;
//using System.Threading.Tasks;
//using Volo.Abp.Authorization.Permissions;
//using Volo.Abp.Identity.Blazor;
//using Volo.Abp.SettingManagement.Blazor.Menus;
//using Volo.Abp.TenantManagement.Blazor.Navigation;
//using Volo.Abp.UI.Navigation;
//using YANLib.Localization;
//using YANLib.Permissions;

//namespace YANLib.Blazor.Client.Navigation;

//public class YANLibMenuContributor : IMenuContributor
//{
//    private readonly IConfiguration _configuration;

//    public YANLibMenuContributor(IConfiguration configuration)
//    {
//        _configuration = configuration;
//    }

//    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
//    {
//        if (context.Menu.Name == StandardMenus.Main)
//        {
//            await ConfigureMainMenuAsync(context);
//        }
//        else if (context.Menu.Name == StandardMenus.User)
//        {
//            await ConfigureUserMenuAsync(context);
//        }
//    }

//    private static async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
//    {
//        var l = context.GetLocalizer<YANLibResource>();

//        //Administration
//        var administration = context.Menu.GetAdministration();
//        administration.Order = 5;

//        context.Menu.AddItem(new ApplicationMenuItem(
//            YANLibMenus.Home,
//            l["Menu:Home"],
//            "/",
//            icon: "fas fa-home",
//            order: 1
//        ));
//        if (MultiTenancyConsts.IsEnabled)
//        {
//            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
//        }
//        else
//        {
//            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
//        }

//        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
//        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

//        var bookStoreMenu = new ApplicationMenuItem(
//            "BooksStore",
//            l["Menu:Books"],
//            icon: "fa fa-book"
//        );

//        context.Menu.AddItem(bookStoreMenu);

//        //CHECK the PERMISSION
//        if (await context.IsGrantedAsync(YANLibPermissions.Books.Default))
//        {
//            bookStoreMenu.AddItem(new ApplicationMenuItem(
//                "BooksStore.Books",
//                l["Menu:Books"],
//                url: "/books"
//            ));
//        }
//    }

//    private async Task ConfigureUserMenuAsync(MenuConfigurationContext context)
//    {
//        var accountStringLocalizer = context.GetLocalizer<AccountResource>();
//        var authServerUrl = _configuration["AuthServer:Authority"] ?? "";

//        context.Menu.AddItem(new ApplicationMenuItem(
//            "Account.Manage",
//            accountStringLocalizer["MyAccount"],
//            $"{authServerUrl.EnsureEndsWith('/')}Account/Manage?returnUrl={_configuration["App:SelfUrl"]}",
//            icon: "fa fa-cog",
//            order: 1000,
//            null).RequireAuthenticated());

//        await Task.CompletedTask;
//    }
//}
