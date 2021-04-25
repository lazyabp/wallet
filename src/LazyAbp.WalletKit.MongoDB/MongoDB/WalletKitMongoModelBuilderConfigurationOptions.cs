using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace LazyAbp.WalletKit.MongoDB
{
    public class WalletKitMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public WalletKitMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}