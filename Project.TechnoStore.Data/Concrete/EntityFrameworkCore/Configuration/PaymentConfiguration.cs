﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Configuration
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(I => I.PaymentId);
            builder.Property(I => I.Allowed).IsRequired();
            builder.Property(I => I.PaymentType).IsRequired();

            builder.HasMany(I => I.Orders).WithOne(I => I.Payment).HasForeignKey(I => I.PaymentId)
                .OnDelete(deleteBehavior: DeleteBehavior.SetNull);
        }
    }
}