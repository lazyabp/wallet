using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace LazyAbp.WalletKit
{
    [DependsOn(
        typeof(WalletKitApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class WalletKitHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "WalletKit";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(WalletKitApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
