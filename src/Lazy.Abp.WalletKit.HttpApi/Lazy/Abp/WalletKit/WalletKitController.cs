using Lazy.Abp.WalletKit.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Lazy.Abp.WalletKit
{
    public abstract class WalletKitController : AbpController
    {
        protected WalletKitController()
        {
            LocalizationResource = typeof(WalletKitResource);
        }
    }
}
