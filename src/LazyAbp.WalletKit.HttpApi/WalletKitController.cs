using LazyAbp.WalletKit.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace LazyAbp.WalletKit
{
    public abstract class WalletKitController : AbpController
    {
        protected WalletKitController()
        {
            LocalizationResource = typeof(WalletKitResource);
        }
    }
}
