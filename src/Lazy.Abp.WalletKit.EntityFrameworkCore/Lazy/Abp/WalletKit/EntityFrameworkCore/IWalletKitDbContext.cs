using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Lazy.Abp.WalletKit.PaymentSettings;
using Lazy.Abp.WalletKit.RechargeOrders;
using Lazy.Abp.WalletKit.RechargeProducts;
using Lazy.Abp.WalletKit.Wallets;
using Lazy.Abp.WalletKit.WalletLogs;
using Lazy.Abp.WalletKit.WithdrawAccounts;

namespace Lazy.Abp.WalletKit.EntityFrameworkCore
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
