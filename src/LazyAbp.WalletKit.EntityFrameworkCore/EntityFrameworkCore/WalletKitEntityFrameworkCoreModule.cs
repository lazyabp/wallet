using LazyAbp.WalletKit.Financial;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LazyAbp.WalletKit.EntityFrameworkCore
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
                options.AddRepository<RechargeOrderItem, RechargeOrderItemRepository>();
                options.AddRepository<RechargeProduct, RechargeProductRepository>();
                options.AddRepository<Wallet, WalletRepository>();
                options.AddRepository<WalletLog, WalletLogRepository>();
                options.AddRepository<WithdrawAccount, WithdrawAccountRepository>();
            });
        }
    }
}
