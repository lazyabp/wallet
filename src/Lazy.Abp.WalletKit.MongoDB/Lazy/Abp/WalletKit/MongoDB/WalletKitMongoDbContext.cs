using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Lazy.Abp.WalletKit.MongoDB
{
    [ConnectionStringName(WalletKitDbProperties.ConnectionStringName)]
    public class WalletKitMongoDbContext : AbpMongoDbContext, IWalletKitMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureWalletKit();
        }
    }
}