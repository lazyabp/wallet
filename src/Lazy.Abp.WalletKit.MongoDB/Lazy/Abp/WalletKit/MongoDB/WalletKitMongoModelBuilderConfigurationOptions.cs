using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Lazy.Abp.WalletKit.MongoDB
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