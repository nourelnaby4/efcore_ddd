using Domain.Orders;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class LineItemConfiguration : IEntityTypeConfiguration<LineItem>
    {
        public void Configure(EntityTypeBuilder<LineItem> builder)
        {
            builder.HasKey(li => li.Id);

            builder.Property(li => li.Id).HasConversion(
                lineItemId => lineItemId.Value,
                value => new LineItemId(value));

            builder.HasOne<Product>()
                .WithMany()
                .HasForeignKey(li => li.ProductId);

            //builder.Property(li => li.Price).HasConversion(
            //    price => price.Amount,
            //    money => new Money(string.Empty, money));

            builder.ComplexProperty(p => p.Price);

        }
    }
}
