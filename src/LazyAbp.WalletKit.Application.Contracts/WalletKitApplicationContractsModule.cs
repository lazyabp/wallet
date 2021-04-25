using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace LazyAbp.WalletKit
{
    [DependsOn(
        typeof(WalletKitDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class WalletKitApplicationContractsModule : AbpModule
    {

    }
}
