using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Lazy.Abp.WalletKit.Web.Menus
{
    public class WalletKitMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            //Add main menu items.
            context.Menu.AddItem(new ApplicationMenuItem(WalletKitMenus.Prefix, displayName: "WalletKit", "~/WalletKit", icon: "fa fa-globe"));

            return Task.CompletedTask;
        }
    }
}