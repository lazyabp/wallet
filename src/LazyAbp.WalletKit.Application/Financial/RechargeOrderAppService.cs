using System;
using LazyAbp.WalletKit.Permissions;
using LazyAbp.WalletKit.Financial.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Volo.Abp.Users;
using System.Linq;

namespace LazyAbp.WalletKit.Financial
{
    public class RechargeOrderAppService : WalletKitAppService, IRechargeOrderAppService
    {
        private readonly IRechargeOrderRepository _repository;
        private readonly IRechargeProductRepository _productRepository;

        public RechargeOrderAppService(
            IRechargeOrderRepository repository,
            IRechargeProductRepository productRepository
        )
        {
            _repository = repository;
            _productRepository = productRepository;
        }

        [Authorize(WalletKitPermissions.RechargeOrder.Default)]
        public async Task<RechargeOrderDto> GetAsync(Guid id)
        {
            var order = await _repository.GetByIdAsync(id, true);

            return ObjectMapper.Map<RechargeOrder, RechargeOrderDto>(order);
        }

        [Authorize(WalletKitPermissions.RechargeOrder.Default)]
        public async Task<PagedResultDto<RechargeOrderDto>> GetListAsync(GetRechargeOrderListRequestDto input)
        {
            var count = await _repository.GetCountAsync(CurrentUser.GetId(), input.Gateway, input.Status, input.IsClosed,
                input.MinAmount, input.MaxAmount, input.CreationAfter, input.CreationBefore, input.Filter, input.IncludeDetails);
            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, CurrentUser.GetId(), input.Gateway, input.Status,
                input.IsClosed, input.MinAmount, input.MaxAmount, input.CreationAfter, input.CreationBefore, input.Filter, input.IncludeDetails);

            return new PagedResultDto<RechargeOrderDto>(
                count,
                ObjectMapper.Map<List<RechargeOrder>, List<RechargeOrderDto>>(list)
            );
        }

        [Authorize(WalletKitPermissions.RechargeOrder.Management)]
        public async Task<PagedResultDto<RechargeOrderDto>> GetManagementListAsync(GetRechargeOrderListRequestDto input)
        {
            var count = await _repository.GetCountAsync(null, input.Gateway, input.Status, input.IsClosed,
                input.MinAmount, input.MaxAmount, input.CreationAfter, input.CreationBefore, input.Filter, input.IncludeDetails);
            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, null, input.Gateway, input.Status,
                input.IsClosed, input.MinAmount, input.MaxAmount, input.CreationAfter, input.CreationBefore, input.Filter, input.IncludeDetails);

            return new PagedResultDto<RechargeOrderDto>(
                count,
                ObjectMapper.Map<List<RechargeOrder>, List<RechargeOrderDto>>(list)
            );
        }

        [Authorize(WalletKitPermissions.RechargeOrder.Create)]
        public async Task<RechargeOrderDto> CreateAsync(CreateUpdateRechargeOrderDto input)
        {
            var order = new RechargeOrder(GuidGenerator.Create(), CurrentUser.TenantId, null);
            var productIds = order.Items.Select(q => q.RechargeProductId).ToList();
            var products = await _productRepository.GetByIdsAsync(productIds);

            foreach (var item in input.Items)
            {
                var product = products.FirstOrDefault(q => q.Id == item.RechargeProductId);
                order.AddItem(item.RechargeProductId, product.SalePrice, item.Quantity);
            }

            await _repository.InsertAsync(order);

            return ObjectMapper.Map<RechargeOrder, RechargeOrderDto>(order);
        }

        [Authorize(WalletKitPermissions.RechargeOrder.Update)]
        public async Task<RechargeOrderDto> AddItemAsync(Guid id, ItemRequestDto input)
        {
            var order = await _repository.GetByIdAsync(id, true);
            var product = await _productRepository.GetAsync(input.RechargeProductId);

            order.AddItem(input.RechargeProductId, product.SalePrice, input.Quantity);
            await _repository.UpdateAsync(order);

            return ObjectMapper.Map<RechargeOrder, RechargeOrderDto>(order);
        }

        [Authorize(WalletKitPermissions.RechargeOrder.Update)]
        public async Task<RechargeOrderDto> RemoveItemAsync(Guid id, ItemRequestDto input)
        {
            var order = await _repository.GetByIdAsync(id, true);

            order.AddItem(input.RechargeProductId, 0, 0);
            await _repository.UpdateAsync(order);

            return ObjectMapper.Map<RechargeOrder, RechargeOrderDto>(order);
        }

        [Authorize(WalletKitPermissions.RechargeOrder.Update)]
        public async Task<RechargeOrderDto> SetAsClosedAsync(Guid id)
        {
            var order = await _repository.GetAsync(id);
            order.SetAsClosed();

            return ObjectMapper.Map<RechargeOrder, RechargeOrderDto>(order);
        }

        [Authorize(WalletKitPermissions.RechargeOrder.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
