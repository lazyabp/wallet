using Lazy.Abp.WalletKit.Recharges;
using Lazy.Abp.WalletKit.Wallets;
using Lazy.Abp.WalletKit.WithdrawAccounts;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.WalletKit.EntityFrameworkCore
{
    [ConnectionStringName(WalletKitDbProperties.ConnectionStringName)]
    public class WalletKitDbContext : AbpDbContext<WalletKitDbContext>, IWalletKitDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public DbSet<RechargeProduct> RechargeProducts { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletLog> WalletLogs { get; set; }
        public DbSet<WithdrawAccount> WithdrawAccounts { get; set; }
        public DbSet<RechargeHistory> RechargeHistories { get; set; }

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
