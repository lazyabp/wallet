using Volo.Abp.Modularity;

namespace LazyAbp.WalletKit
{
    [DependsOn(
        typeof(WalletKitApplicationModule),
        typeof(WalletKitDomainTestModule)
        )]
    public class WalletKitApplicationTestModule : AbpModule
    {

    }
}
