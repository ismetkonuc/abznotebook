using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Description).HasColumnType("ntext");
            builder.Property(I => I.Name).HasMaxLength(250).IsRequired();
            builder.Property(I => I.DiscCapacity).IsRequired();
            builder.Property(I => I.ProcessorModel).IsRequired();
            builder.Property(I => I.ProcessorType).IsRequired();
            builder.Property(I => I.GraphicsCard).IsRequired();
            builder.Property(I => I.SKU).IsRequired();
            builder.Property(I => I.IDSKU).IsRequired();
            builder.Property(I => I.ProcessorVendor).IsRequired();
            builder.Property(I => I.MemoryCapacity).IsRequired();
            builder.Property(I => I.QuantityPerUnit).IsRequired();
            builder.Property(I => I.UnitInStock).IsRequired();
            builder.Property(I => I.Picture).IsRequired();
            builder.Property(I => I.Vendor).IsRequired();
            builder.Property(I => I.UnitPrice).IsRequired();

            builder.HasMany(I => I.OrderDetails).WithOne(I => I.Product).HasForeignKey(I => I.ProductId).OnDelete(deleteBehavior: DeleteBehavior.SetNull);
        }
    }
}
