using Localization.Resources.AbpUi;
using LazyAbp.WalletKit.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace LazyAbp.WalletKit
{
    [DependsOn(
        typeof(WalletKitApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class WalletKitHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(WalletKitHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<WalletKitResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
