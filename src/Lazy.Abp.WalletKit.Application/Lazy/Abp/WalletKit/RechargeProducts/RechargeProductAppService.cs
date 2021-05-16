using System;
using Lazy.Abp.WalletKit.Permissions;
using Lazy.Abp.WalletKit.RechargeProducts.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace Lazy.Abp.WalletKit.RechargeProducts
{
    public class RechargeProductAppService : WalletKitAppService, IRechargeProductAppService
    {
        private readonly IRechargeProductRepository _repository;
        
        public RechargeProductAppService(IRechargeProductRepository repository)
        {
            _repository = repository;
        }

        [Authorize(WalletKitPermissions.RechargeProduct.Default)]
        public async Task<RechargeProductDto> GetAsync(Guid id)
        {
            var product = await _repository.GetAsync(id);

            return ObjectMapper.Map<RechargeProduct, RechargeProductDto>(product);
        }

        [Authorize(WalletKitPermissions.RechargeProduct.Default)]
        public async Task<PagedResultDto<RechargeProductDto>> GetListAsync(GetRechargeProductListRequestDto input)
        {
            var count = await _repository.GetCountAsync(input.IsActive, input.MinPrice, input.MaxPrice, input.CreationAfter, input.CreationBefore, input.Filter);
            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount,
                input.IsActive, input.MinPrice, input.MaxPrice, input.CreationAfter, input.CreationBefore, input.Filter);

            return new PagedResultDto<RechargeProductDto>(
                count,
                ObjectMapper.Map<List<RechargeProduct>, List<RechargeProductDto>>(list)
            );
        }

        [Authorize(WalletKitPermissions.RechargeProduct.Create)]
        public async Task<RechargeProductDto> CreateAsync(CreateUpdateRechargeProductDto input)
        {
            var product = new RechargeProduct(GuidGenerator.Create(), CurrentUser.TenantId, input.Name, input.Thumbnail,
                input.RetailPrice, input.SalePrice, input.Quantity, input.Description, input.IsActive, input.DisplayOrder);

            await _repository.InsertAsync(product);

            return ObjectMapper.Map<RechargeProduct, RechargeProductDto>(product);
        }

        [Authorize(WalletKitPermissions.RechargeProduct.Update)]
        public async Task<RechargeProductDto> UpdateAsync(Guid id, CreateUpdateRechargeProductDto input)
        {
            var product = await _repository.GetAsync(id);
            product.Update(input.Name, input.Thumbnail, input.RetailPrice, 
                input.SalePrice, input.Quantity, input.Description, input.IsActive, input.DisplayOrder);

            await _repository.UpdateAsync(product);

            return ObjectMapper.Map<RechargeProduct, RechargeProductDto>(product);
        }

        [Authorize(WalletKitPermissions.RechargeProduct.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
