using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace LazyAbp.WalletKit.Blazor.WebAssembly
{
    [DependsOn(
        typeof(WalletKitBlazorModule),
        typeof(WalletKitHttpApiClientModule),
        typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
        )]
    public class WalletKitBlazorWebAssemblyModule : AbpModule
    {
        
    }
}