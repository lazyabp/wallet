using System;
using Lazy.Abp.WalletKit.Permissions;
using Lazy.Abp.WalletKit.Wallets.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Users;
using System.Collections.Generic;
using Lazy.Abp.WalletKit.WalletLogs;

namespace Lazy.Abp.WalletKit.Wallets
{
    public class WalletAppService : WalletKitAppService, IWalletAppService
    {
        private readonly IWalletRepository _repository;
        private readonly WalletLogManager _walletLogManager;

        public WalletAppService(
            IWalletRepository repository,
            WalletLogManager walletLogManager
        )
        {
            _repository = repository;
            _walletLogManager = walletLogManager;
        }

        [Authorize(WalletKitPermissions.Wallet.Default)]
        public async Task<WalletDto> GetAsync()
        {
            var wallet = await _repository.GetByUserIdAsync(CurrentUser.GetId());
            if (null == wallet)
            {
                wallet = new Wallet(GuidGenerator.Create(), CurrentUser.TenantId, CurrentUser.GetId(), 0, 0);
                await _repository.InsertAsync(wallet);
            }

            return ObjectMapper.Map<Wallet, WalletDto>(wallet);
        }

        [Authorize(WalletKitPermissions.Wallet.Management)]
        public async Task<PagedResultDto<WalletDto>> GetListAsync(WalletListRequestDto input)
        {
            var count = await _repository.GetCountAsync(null, input.MinBalance, input.MaxBalance, input.HasLockedAmount, input.Filter);

            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, 
                null, input.MinBalance, input.MaxBalance, input.HasLockedAmount, input.Filter);

            return new PagedResultDto<WalletDto>(
                count,
                ObjectMapper.Map<List<Wallet>, List<WalletDto>>(list)
            );
        }

        [Authorize(WalletKitPermissions.Wallet.Reset)]
        public async Task<WalletDto> ResetAsync(Guid userId, ResetReasonDto input)
        {
            var wallet = await _repository.GetByUserIdAsync(userId);

            if (wallet.Balance > 0)
            {
                var balance = wallet.Balance;

                wallet.Reset();

                await _walletLogManager.WriteOutLogAsync(wallet.TenantId, wallet.UserId, "ResetWallet", balance, 0, L["ResetWallet"], input.Reason);
            }

            return ObjectMapper.Map<Wallet, WalletDto>(wallet);
        }
    }
}
