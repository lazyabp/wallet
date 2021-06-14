using Lazy.Abp.WalletKit.Wallets;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Uow;

namespace Lazy.Abp.WalletKit.Recharges
{
    public class RechargeHistoryManager : DomainService, IUnitOfWorkEnabled
    {
        private readonly IRechargeHistoryRepository _repository;
        private readonly IRechargeProductRepository _productRepository;
        private readonly IWalletRepository _walletRepository;
        private readonly IWalletLogRepository _walletLogRepository;

        public RechargeHistoryManager(
            IRechargeHistoryRepository repository,
            IRechargeProductRepository productRepository,
            IWalletRepository walletRepository,
            IWalletLogRepository walletLogRepository
        )
        {
            _repository = repository;
            _productRepository = productRepository;
            _walletRepository = walletRepository;
            _walletLogRepository = walletLogRepository;
        }

        public async Task<RechargeHistory> GetAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<RechargeHistory> GetAsync(Guid id, Guid? tenantId)
        {
            using (CurrentTenant.Change(tenantId))
            {
                return await _repository.GetAsync(id);
            }
        }

        /// <summary>
        /// 充值
        /// </summary>
        [UnitOfWork]
        public async Task<RechargeHistory> RechargeAsync(
            Guid? tenantId,
            Guid userId,
            Guid rechargeProductId,
            int productQuantity,
            string orderId,
            int creditAmount,
            decimal paidAmount,
            string title,
            string description
        )
        {
            using (CurrentTenant.Change(tenantId))
            {
                var coinPurchased = new RechargeHistory(GuidGenerator.Create(), tenantId, userId, rechargeProductId, productQuantity, orderId, creditAmount, paidAmount);

                await _repository.InsertAsync(coinPurchased);

                // 修改销售数量
                var product = await _productRepository.GetAsync(rechargeProductId);
                product.SetSoldQuantity(product.SoldQuantity + productQuantity);

                // 钱包
                var wallet = await _walletRepository.GetByUserIdAsync(userId);
                wallet.IncBalance(creditAmount);

                // 写日志
                var log = new WalletLog(GuidGenerator.Create(), tenantId, userId, "Recharge", false, creditAmount, wallet.Balance, title, description);
                await _walletLogRepository.InsertAsync(log);

                return coinPurchased;
            }
        }

        /// <summary>
        /// 支付
        /// </summary>
        [UnitOfWork]
        public async Task<decimal> PayAsync(
            Guid? tenantId,
            Guid userId,
            int creditAmount,
            string title,
            string description,
            string typeName = "Pay"
        )
        {
            using (CurrentTenant.Change(tenantId))
            {
                // 钱包
                var wallet = await _walletRepository.GetByUserIdAsync(userId);
                wallet.DecBalance(creditAmount);

                // 写日志
                var log = new WalletLog(GuidGenerator.Create(), tenantId, userId, typeName, true, creditAmount, wallet.Balance, title, description);
                await _walletLogRepository.InsertAsync(log);

                return wallet.Balance;
            }
        }

        /// <summary>
        /// 存（赚取，赠送等得到的消费点）
        /// </summary>
        [UnitOfWork]
        public async Task<decimal> DepositAsync(
            Guid? tenantId,
            Guid userId,
            int creditAmount,
            string title,
            string description,
            string typeName = "Deposit"
        )
        {
            using (CurrentTenant.Change(tenantId))
            {
                // 钱包
                var wallet = await _walletRepository.GetByUserIdAsync(userId);
                wallet.IncBalance(creditAmount);

                // 写日志
                var log = new WalletLog(GuidGenerator.Create(), tenantId, userId, typeName, false, creditAmount, wallet.Balance, title, description);
                await _walletLogRepository.InsertAsync(log);

                return wallet.Balance;
            }
        }
    }
}
