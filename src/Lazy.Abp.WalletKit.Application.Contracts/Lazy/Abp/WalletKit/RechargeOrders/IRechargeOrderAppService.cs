using System;
using System.Threading.Tasks;
using Lazy.Abp.WalletKit.RechargeOrders.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.WalletKit.RechargeOrders
{
    public interface IRechargeOrderAppService : IApplicationService
    {
        Task<RechargeOrderDto> GetAsync(Guid id);

        Task<PagedResultDto<RechargeOrderDto>> GetListAsync(GetRechargeOrderListRequestDto input);

        Task<PagedResultDto<RechargeOrderDto>> GetManagementListAsync(GetRechargeOrderListRequestDto input);

        Task<RechargeOrderDto> CreateAsync(CreateUpdateRechargeOrderDto input);

        Task<RechargeOrderDto> AddItemAsync(Guid id, ItemRequestDto input);

        Task<RechargeOrderDto> RemoveItemAsync(Guid id, ItemRequestDto input);

        Task<RechargeOrderDto> SetAsClosedAsync(Guid id);

        Task DeleteAsync(Guid id);
    }
}