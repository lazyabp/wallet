using System;
using LazyAbp.WalletKit.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace LazyAbp.WalletKit.Financial
{
    public class RechargeOrderItemRepository : EfCoreRepository<IWalletKitDbContext, RechargeOrderItem>, IRechargeOrderItemRepository
    {
        public RechargeOrderItemRepository(IDbContextProvider<IWalletKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}