using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Lazy.Abp.WalletKit.MongoDB
{
    public static class WalletKitMongoDbContextExtensions
    {
        public static void ConfigureWalletKit(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new WalletKitMongoModelBuilderConfigurationOptions(
                WalletKitDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}