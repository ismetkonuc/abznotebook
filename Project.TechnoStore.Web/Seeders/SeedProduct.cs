using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Contexts;
using Project.TechnoStore.Data.Interfaces;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Web
{
    public static class SeedProduct
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            TechnoStoreDbContext context = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<TechnoStoreDbContext>();
            if (EnumerableExtensions.Any(context.Database.GetPendingMigrations()))
            {
                context.Database.Migrate();
            }

            if (!EnumerableExtensions.Any(context.Products))
            {
                context.Products.AddRange(
                    
                    new Product()
                    {
                        Name = "HP 15-DA2067",
                        Description = "HP 15-DA2067NT Intel Core i5 10210U 4GB 256GB SSD MX110 Freedos 15.6",
                        IsAvailable = false,
                        ProcessorVendor = "Intel",
                        ProcessorType = "Intel Core i5",
                        ProcessorModel = "10210U",
                        SKU = "HBV00000X88NL",
                        IDSKU = 1,
                        Picture = "HP15-DA2067.jpg",
                        UnitInStock = 100,
                        UnitPrice = 6699,
                        Vendor = "HP",
                        GraphicsCard = "Nvidia GeForce MX110",
                        QuantityPerUnit = 100,
                        DiscCapacity = "1 TB",
                        MemoryCapacity = "4 GB",
                    },

                    new Product()
                    {
                        Name = "HP 15S-FQ100NT",
                        Description = "HP 15S-FQ100NT Intel Core i5 1035G1 8GB 256GB SSD Windows 10 Home 15.6'' Taşınabilir Bilgisayar 8KR82EA",
                        IsAvailable = true,
                        ProcessorVendor = "Intel",
                        ProcessorType = "Intel Core i5",
                        ProcessorModel = "1035G1",
                        SKU = "HBV00000Q9W14",
                        IDSKU = 2,
                        Picture = "hp15s-fq100nt.jpg",
                        UnitInStock = 100,
                        UnitPrice = 7249,
                        Vendor = "HP",
                        GraphicsCard = "Nvidia GeForce MX110",
                        QuantityPerUnit = 100,
                        DiscCapacity = "256 GB",
                        MemoryCapacity = "4 GB",
                    },

                    new Product()
                    {
                        Name = "Asus X509JA-BR089T",
                        Description = "Asus X509JA-BR089T Intel Core i3 1005G1 4GB 256GB SSD Windows 10 Home 15.6\" Taşınabilir Bilgisayar",
                        IsAvailable = true,
                        ProcessorVendor = "Intel",
                        ProcessorType = "Intel Core i3",
                        ProcessorModel = "1005G1",
                        SKU = "HBV00000Q9W14",
                        IDSKU = 2,
                        Picture = "finger1.jpg",
                        UnitInStock = 100,
                        UnitPrice = 5399,
                        Vendor = "HP",
                        GraphicsCard = "Intel UHD Graphics",
                        QuantityPerUnit = 100,
                        DiscCapacity = "256 GB",
                        MemoryCapacity = "4 GB",
                    },

                    new Product()
                    {
                        Name = "MSI GF63 Thin 9SCXR-620XTR",
                        Description = "MSI GF63 Thin 9SCXR-620XTR Intel Core i7 9750H 8GB 512GB SSD GTX1650 Freedos 15.6\" FHD Taşınabilir Bilgisayar",
                        IsAvailable = true,
                        ProcessorVendor = "Intel",
                        ProcessorType = "Intel Core i7",
                        ProcessorModel = "9750H",
                        SKU = "HBV00000VPSTO",
                        IDSKU = 2,
                        Picture = "gfthin9scxr619xtr_01.jpg",
                        UnitInStock = 100,
                        UnitPrice = 12199,
                        Vendor = "HP",
                        GraphicsCard = "Nvidia GeForce GTX1650",
                        QuantityPerUnit = 10,
                        DiscCapacity = "512 GB",
                        MemoryCapacity = "8 GB",
                    }

                    );
                context.SaveChanges();
            }
        }
    }
}