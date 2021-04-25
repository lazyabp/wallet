using LazyAbp.WalletKit.Financial;
using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace LazyAbp.WalletKit.EntityFrameworkCore
{
    public static class WalletKitDbContextModelCreatingExtensions
    {
        public static void ConfigureWalletKit(
            this ModelBuilder builder,
            Action<WalletKitModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new WalletKitModelBuilderConfigurationOptions(
                WalletKitDbProperties.DbTablePrefix,
                WalletKitDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureByConvention();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */


            builder.Entity<PaymentSetting>(b =>
            {
                b.ToTable(options.TablePrefix + "PaymentSettings", options.Schema);
                b.ConfigureByConvention(); 
                

                /* Configure more properties here */
            });


            builder.Entity<RechargeOrder>(b =>
            {
                b.ToTable(options.TablePrefix + "RechargeOrders", options.Schema);
                b.ConfigureByConvention();

                b.HasIndex(q => q.OrderNo);
                b.HasIndex(q => q.TradeNo);

                b.HasMany(q => q.Items).WithOne().HasForeignKey(x => x.RechargeOrderId).IsRequired();
                /* Configure more properties here */
            });


            builder.Entity<RechargeOrderItem>(b =>
            {
                b.ToTable(options.TablePrefix + "RechargeOrderItems", options.Schema);
                b.ConfigureByConvention(); 
                
                b.HasKey(e => new
                {
                    e.RechargeOrderId,
                    e.RechargeProductId,
                });

                /* Configure more properties here */
            });


            builder.Entity<RechargeProduct>(b =>
            {
                b.ToTable(options.TablePrefix + "RechargeProducts", options.Schema);
                b.ConfigureByConvention(); 
                

                /* Configure more properties here */
            });


            builder.Entity<Wallet>(b =>
            {
                b.ToTable(options.TablePrefix + "Wallets", options.Schema);
                b.ConfigureByConvention(); 
                
                /* Configure more properties here */
            });


            builder.Entity<WalletLog>(b =>
            {
                b.ToTable(options.TablePrefix + "WalletLogs", options.Schema);
                b.ConfigureByConvention(); 
                

                /* Configure more properties here */
            });


            builder.Entity<WithdrawAccount>(b =>
            {
                b.ToTable(options.TablePrefix + "WithdrawAccounts", options.Schema);
                b.ConfigureByConvention(); 
                

                /* Configure more properties here */
            });
        }
    }
}
