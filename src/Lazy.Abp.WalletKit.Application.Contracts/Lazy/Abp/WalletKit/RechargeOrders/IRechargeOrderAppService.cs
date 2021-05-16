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

        Task<PagedResultDto<RechargeOrderDto>> GetListAsync(RechargeOrderListRequestDto input);

        Task<PagedResultDto<RechargeOrderDto>> GetManagementListAsync(RechargeOrderListRequestDto input);

        Task<RechargeOrderDto> CreateAsync(RechargeOrderCreateUpdateDto input);

        Task<RechargeOrderDto> AddItemAsync(Guid id, ItemRequestDto input);

        Task<RechargeOrderDto> RemoveItemAsync(Guid id, ItemRequestDto input);

        Task<RechargeOrderDto> SetAsClosedAsync(Guid id);

        Task DeleteAsync(Guid id);
    }
}