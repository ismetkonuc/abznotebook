using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.AddressLine).IsRequired().HasColumnType("ntext").HasMaxLength(250);
            builder.Property(I => I.City).IsRequired().HasMaxLength(30);
            builder.Property(I => I.District).IsRequired().HasMaxLength(30);
            builder.Property(I => I.PostalCode).IsRequired(false).HasMaxLength(10);

            builder.HasOne(I => I.AppUser).WithMany(I => I.Addresses).HasForeignKey(I => I.AppUserId);
        }
    }
}
