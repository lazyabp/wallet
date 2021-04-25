using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using LazyAbp.WalletKit.Financial;

namespace LazyAbp.WalletKit.EntityFrameworkCore
{
    [ConnectionStringName(WalletKitDbProperties.ConnectionStringName)]
    public interface IWalletKitDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<PaymentSetting> PaymentSettings { get; set; }
        DbSet<RechargeOrder> RechargeOrders { get; set; }
        DbSet<RechargeOrderItem> RechargeOrderItems { get; set; }
        DbSet<RechargeProduct> RechargeProducts { get; set; }
        DbSet<Wallet> Wallets { get; set; }
        DbSet<WalletLog> WalletLogs { get; set; }
        DbSet<WithdrawAccount> WithdrawAccounts { get; set; }
    }
}
