using Lazy.Abp.WalletKit.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Lazy.Abp.WalletKit.Permissions
{
    public class WalletKitPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(WalletKitPermissions.GroupName, L("Permission:WalletKit"));

            var rechargeProductPermission = myGroup.AddPermission(WalletKitPermissions.RechargeProduct.Default, L("Permission:RechargeProduct"));
            rechargeProductPermission.AddChild(WalletKitPermissions.RechargeProduct.Create, L("Permission:Create"));
            rechargeProductPermission.AddChild(WalletKitPermissions.RechargeProduct.Update, L("Permission:Update"));
            rechargeProductPermission.AddChild(WalletKitPermissions.RechargeProduct.Delete, L("Permission:Delete"));

            var walletActionPermission = myGroup.AddPermission(WalletKitPermissions.RechargeHistory.Default, L("Permission:RechargeHistory"));
            walletActionPermission.AddChild(WalletKitPermissions.RechargeHistory.Delete, L("Permission:Delete"));

            var walletPermission = myGroup.AddPermission(WalletKitPermissions.Wallet.Default, L("Permission:Wallet"));
            walletPermission.AddChild(WalletKitPermissions.Wallet.Management, L("Permission:Management"));
            walletPermission.AddChild(WalletKitPermissions.Wallet.AdjustmentBalance, L("Permission:AdjustmentBalance"));

            var walletLogPermission = myGroup.AddPermission(WalletKitPermissions.WalletLog.Default, L("Permission:WalletLog"));
            walletLogPermission.AddChild(WalletKitPermissions.WalletLog.Management, L("Permission:Management"));

            var withdrawAccountPermission = myGroup.AddPermission(WalletKitPermissions.WithdrawAccount.Default, L("Permission:WithdrawAccount"));
            withdrawAccountPermission.AddChild(WalletKitPermissions.WithdrawAccount.Create, L("Permission:Create"));
            withdrawAccountPermission.AddChild(WalletKitPermissions.WithdrawAccount.Update, L("Permission:Update"));
            withdrawAccountPermission.AddChild(WalletKitPermissions.WithdrawAccount.Delete, L("Permission:Delete"));
            withdrawAccountPermission.AddChild(WalletKitPermissions.WithdrawAccount.Management, L("Permission:Management"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<WalletKitResource>(name);
        }
    }
}
