using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace LazyAbp.WalletKit
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(WalletKitDomainSharedModule)
    )]
    public class WalletKitDomainModule : AbpModule
    {

    }
}
