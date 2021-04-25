using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace LazyAbp.WalletKit.Blazor.Server
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsServerThemingModule),
        typeof(WalletKitBlazorModule)
        )]
    public class WalletKitBlazorServerModule : AbpModule
    {
        
    }
}