using Lazy.Abp.WalletKit.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Lazy.Abp.WalletKit.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class WalletKitPageModel : AbpPageModel
    {
        protected WalletKitPageModel()
        {
            LocalizationResourceType = typeof(WalletKitResource);
            ObjectMapperContext = typeof(WalletKitWebModule);
        }
    }
}