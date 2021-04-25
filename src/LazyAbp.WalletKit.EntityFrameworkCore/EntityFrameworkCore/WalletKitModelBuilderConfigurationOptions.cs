using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace LazyAbp.WalletKit.EntityFrameworkCore
{
    public class WalletKitModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public WalletKitModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}