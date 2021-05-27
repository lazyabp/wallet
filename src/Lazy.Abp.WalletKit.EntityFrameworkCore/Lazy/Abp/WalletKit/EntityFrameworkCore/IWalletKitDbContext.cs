using Lazy.Abp.WalletKit.RechargeProducts;
using Lazy.Abp.WalletKit.WalletActions;
using Lazy.Abp.WalletKit.WalletLogs;
using Lazy.Abp.WalletKit.Wallets;
using Lazy.Abp.WalletKit.WithdrawAccounts;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.WalletKit.EntityFrameworkCore
{
    [ConnectionStringName(WalletKitDbProperties.ConnectionStringName)]
    public interface IWalletKitDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<RechargeProduct> RechargeProducts { get; set; }
        DbSet<Wallet> Wallets { get; set; }
        DbSet<WalletLog> WalletLogs { get; set; }
        DbSet<WithdrawAccount> WithdrawAccounts { get; set; }
        DbSet<WalletAction> WalletActions { get; set; }
    }
}
