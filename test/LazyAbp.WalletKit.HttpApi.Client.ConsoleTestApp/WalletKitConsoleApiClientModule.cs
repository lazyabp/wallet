using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace LazyAbp.WalletKit
{
    [DependsOn(
        typeof(WalletKitHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class WalletKitConsoleApiClientModule : AbpModule
    {
        
    }
}
