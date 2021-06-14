using Lazy.Abp.WalletKit.Recharges;
using Lazy.Abp.WalletKit.Wallets;
using Lazy.Abp.WalletKit.Withdraws;
using Microsoft.EntityFrameworkCore;
using System;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Lazy.Abp.WalletKit.EntityFrameworkCore
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


            builder.Entity<RechargeHistory>(b =>
            {
                b.ToTable(options.TablePrefix + "RechargeHistories", options.Schema);
                b.ConfigureByConvention(); 
                

                /* Configure more properties here */
            });
        }
    }
}
