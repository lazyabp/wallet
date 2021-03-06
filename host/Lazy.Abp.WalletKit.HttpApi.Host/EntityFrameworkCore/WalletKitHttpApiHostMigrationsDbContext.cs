using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.WalletKit.EntityFrameworkCore
{
    public class WalletKitHttpApiHostMigrationsDbContext : AbpDbContext<WalletKitHttpApiHostMigrationsDbContext>
    {
        public WalletKitHttpApiHostMigrationsDbContext(DbContextOptions<WalletKitHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureWalletKit();
        }
    }
}
