using LazyAbp.WalletKit.Financial;
using LazyAbp.WalletKit.Financial.Dtos;
using AutoMapper;

namespace LazyAbp.WalletKit
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
