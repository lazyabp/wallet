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
    public class WalletKitDbContext : AbpDbContext<WalletKitDbContext>, IWalletKitDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public DbSet<PaymentSetting> PaymentSettings { get; set; }
        public DbSet<RechargeOrder> RechargeOrders { get; set; }
        public DbSet<RechargeOrderItem> RechargeOrderItems { get; set; }
        public DbSet<RechargeProduct> RechargeProducts { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletLog> WalletLogs { get; set; }
        public DbSet<WithdrawAccount> WithdrawAccounts { get; set; }

        public WalletKitDbContext(DbContextOptions<WalletKitDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureWalletKit();
        }
    }
}
