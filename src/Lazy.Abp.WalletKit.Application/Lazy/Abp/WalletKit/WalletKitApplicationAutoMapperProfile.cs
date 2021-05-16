using AutoMapper;

using Lazy.Abp.WalletKit.PaymentSettings;
using Lazy.Abp.WalletKit.RechargeOrders;
using Lazy.Abp.WalletKit.RechargeProducts;
using Lazy.Abp.WalletKit.Wallets;
using Lazy.Abp.WalletKit.WalletLogs;
using Lazy.Abp.WalletKit.WithdrawAccounts;
using Lazy.Abp.WalletKit.PaymentSettings.Dtos;
using Lazy.Abp.WalletKit.RechargeOrders.Dtos;
using Lazy.Abp.WalletKit.RechargeProducts.Dtos;
using Lazy.Abp.WalletKit.Wallets.Dtos;
using Lazy.Abp.WalletKit.WalletLogs.Dtos;
using Lazy.Abp.WalletKit.WithdrawAccounts.Dtos;

namespace Lazy.Abp.WalletKit
{
    public class WalletKitApplicationAutoMapperProfile : Profile
    {
        public WalletKitApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<PaymentSetting, PaymentSettingDto>();
            CreateMap<PaymentSetting, PaymentSettingAlipayDto>()
                .ForMember(q => q.Settings, op => op.Ignore());
            CreateMap<PaymentSetting, PaymentSettingWeixinDto>()
                .ForMember(q => q.Settings, op => op.Ignore());
            CreateMap<RechargeOrder, RechargeOrderDto>();
            CreateMap<RechargeOrderItem, RechargeOrderItemDto>();
            CreateMap<RechargeProduct, RechargeProductDto>();
            CreateMap<Wallet, WalletDto>();
            CreateMap<WalletLog, WalletLogDto>();
            CreateMap<WithdrawAccount, WithdrawAccountDto>();
        }
    }
}
