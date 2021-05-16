using System;
using Lazy.Abp.WalletKit.Permissions;
using Lazy.Abp.WalletKit.WithdrawAccounts.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Users;
using System.Collections.Generic;

namespace Lazy.Abp.WalletKit.WithdrawAccounts
{
    public class WithdrawAccountAppService : WalletKitAppService, IWithdrawAccountAppService
    {
        private readonly IWithdrawAccountRepository _repository;
        
        public WithdrawAccountAppService(IWithdrawAccountRepository repository)
        {
            _repository = repository;
        }

        [Authorize(WalletKitPermissions.WithdrawAccount.Default)]
        public async Task<WithdrawAccountDto> GetAsync(Guid id)
        {
            var account = await _repository.GetAsync(id);

            return ObjectMapper.Map<WithdrawAccount, WithdrawAccountDto>(account);
        }

        [Authorize(WalletKitPermissions.WithdrawAccount.Default)]
        public async Task<PagedResultDto<WithdrawAccountDto>> GetListAsync(WithdrawAccountListRequestDto input)
        {
            var count = await _repository.GetCountAsync(CurrentUser.GetId(), input.AccountType, input.IsDefault, input.Filter);
            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount,
                CurrentUser.GetId(), input.AccountType, input.IsDefault, input.Filter);

            return new PagedResultDto<WithdrawAccountDto>(
                count,
                ObjectMapper.Map<List<WithdrawAccount>, List<WithdrawAccountDto>>(list)
            );
        }

        [Authorize(WalletKitPermissions.WithdrawAccount.Management)]
        public async Task<PagedResultDto<WithdrawAccountDto>> GetManagementListAsync(WithdrawAccountListRequestDto input)
        {
            var count = await _repository.GetCountAsync(null, input.AccountType, input.IsDefault, input.Filter);
            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount,
                null, input.AccountType, input.IsDefault, input.Filter);

            return new PagedResultDto<WithdrawAccountDto>(
                count,
                ObjectMapper.Map<List<WithdrawAccount>, List<WithdrawAccountDto>>(list)
            );
        }

        [Authorize(WalletKitPermissions.WithdrawAccount.Create)]
        public async Task<WithdrawAccountDto> CreateAsync(WithdrawAccountCreateUpdateDto input)
        {
            var account = new WithdrawAccount(GuidGenerator.Create(), CurrentUser.TenantId, input.AccountType, input.Account, input.IsDefault, input.Description);

            await _repository.InsertAsync(account);

            return ObjectMapper.Map<WithdrawAccount, WithdrawAccountDto>(account);
        }

        [Authorize(WalletKitPermissions.WithdrawAccount.Update)]
        public async Task<WithdrawAccountDto> UpdateAsync(Guid id, WithdrawAccountCreateUpdateDto input)
        {
            var account = await _repository.GetAsync(id);
            account.Update(input.AccountType, input.Account, input.IsDefault, input.Description);

            return ObjectMapper.Map<WithdrawAccount, WithdrawAccountDto>(account);
        }

        [Authorize(WalletKitPermissions.WithdrawAccount.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
