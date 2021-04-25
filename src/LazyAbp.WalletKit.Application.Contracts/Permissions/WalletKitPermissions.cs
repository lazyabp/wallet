using Volo.Abp.Reflection;

namespace LazyAbp.WalletKit.Permissions
{
    public class WalletKitPermissions
    {
        public const string GroupName = "WalletKit";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(WalletKitPermissions));
        }

        public class PaymentSetting
        {
            public const string Default = GroupName + ".PaymentSetting";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class RechargeOrder
        {
            public const string Default = GroupName + ".RechargeOrder";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
            public const string Management = Default + ".Management";
        }

        public class RechargeOrderItem
        {
            public const string Default = GroupName + ".RechargeOrderItem";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class RechargeProduct
        {
            public const string Default = GroupName + ".RechargeProduct";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Wallet
        {
            public const string Default = GroupName + ".Wallet";
            public const string Management = Default + ".Management";
            public const string Reset = Default + ".Reset";
        }

        public class WalletLog
        {
            public const string Default = GroupName + ".WalletLog";
            public const string Management = Default + ".Management";
        }

        public class WithdrawAccount
        {
            public const string Default = GroupName + ".WithdrawAccount";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
            public const string Management = Default + ".Management";
        }
    }
}
