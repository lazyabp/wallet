using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace LazyAbp.WalletKit.MongoDB
{
    [ConnectionStringName(WalletKitDbProperties.ConnectionStringName)]
    public interface IWalletKitMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
