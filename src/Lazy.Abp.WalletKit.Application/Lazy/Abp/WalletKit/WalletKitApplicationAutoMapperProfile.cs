using AutoMapper;
using Lazy.Abp.WalletKit.Recharges;
using Lazy.Abp.WalletKit.Recharges.Dtos;
using Lazy.Abp.WalletKit.Wallets;
using Lazy.Abp.WalletKit.Wallets.Dtos;
using Lazy.Abp.WalletKit.Withdraws;
using Lazy.Abp.WalletKit.Withdraws.Dtos;

namespace Lazy.Abp.WalletKit
{
    public class WalletKitApplicationAutoMapperProfile : Profile
    {
        public WalletKitApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<RechargeProduct, RechargeProductDto>();
            CreateMap<Wallet, WalletDto>();
            CreateMap<WalletLog, WalletLogDto>();
            CreateMap<WithdrawAccount, WithdrawAccountDto>();
            CreateMap<RechargeHistory, RechargeHistoryDto>();
        }
    }
}
