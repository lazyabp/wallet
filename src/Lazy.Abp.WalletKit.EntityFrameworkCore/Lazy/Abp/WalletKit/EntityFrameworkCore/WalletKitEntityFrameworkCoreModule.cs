using Lazy.Abp.WalletKit.Recharges;
using Lazy.Abp.WalletKit.Wallets;
using Lazy.Abp.WalletKit.Withdraws;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Lazy.Abp.WalletKit.EntityFrameworkCore
{
    [DependsOn(
        typeof(WalletKitDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class WalletKitEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<WalletKitDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<RechargeProduct, RechargeProductRepository>();
                options.AddRepository<Wallet, WalletRepository>();
                options.AddRepository<WalletLog, WalletLogRepository>();
                options.AddRepository<WithdrawAccount, WithdrawAccountRepository>();
                options.AddRepository<RechargeHistory, RechargeHistoryRepository>();
            });
        }
    }
}
