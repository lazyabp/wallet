using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LazyAbp.WalletKit.EntityFrameworkCore
{
    public class WalletKitHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<WalletKitHttpApiHostMigrationsDbContext>
    {
        public WalletKitHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<WalletKitHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("WalletKit"));

            return new WalletKitHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
