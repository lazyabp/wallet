using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Lazy.Abp.WalletKit.PaymentSettings;
using Lazy.Abp.WalletKit.RechargeOrders;
using Lazy.Abp.WalletKit.RechargeProducts;
using Lazy.Abp.WalletKit.Wallets;
using Lazy.Abp.WalletKit.WalletLogs;
using Lazy.Abp.WalletKit.WithdrawAccounts;

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
                options.AddRepository<PaymentSetting, PaymentSettingRepository>();
                options.AddRepository<RechargeOrder, RechargeOrderRepository>();
                options.AddRepository<RechargeProduct, RechargeProductRepository>();
                options.AddRepository<Wallet, WalletRepository>();
                options.AddRepository<WalletLog, WalletLogRepository>();
                options.AddRepository<WithdrawAccount, WithdrawAccountRepository>();
            });
        }
    }
}
