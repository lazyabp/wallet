using Lazy.Abp.WalletKit.Localization;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.WalletKit
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
