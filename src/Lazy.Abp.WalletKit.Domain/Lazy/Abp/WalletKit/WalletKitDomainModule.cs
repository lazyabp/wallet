using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Lazy.Abp.WalletKit
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(WalletKitDomainSharedModule)
    )]
    public class WalletKitDomainModule : AbpModule
    {

    }
}
