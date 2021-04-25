using LazyAbp.WalletKit.Localization;
using Volo.Abp.Application.Services;

namespace LazyAbp.WalletKit
{
    public abstract class WalletKitAppService : ApplicationService
    {
        protected WalletKitAppService()
        {
            LocalizationResource = typeof(WalletKitResource);
            ObjectMapperContext = typeof(WalletKitApplicationModule);
        }
    }
}
