using LazyAbp.WalletKit.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LazyAbp.WalletKit
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(WalletKitEntityFrameworkCoreTestModule)
        )]
    public class WalletKitDomainTestModule : AbpModule
    {
        
    }
}
