namespace Lazy.Abp.WalletKit
{
    public static class WalletKitDbProperties
    {
        public static string DbTablePrefix { get; set; } = "WalletKit";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "WalletKit";
    }
}
