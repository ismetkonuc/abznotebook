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
            var test = context.Categories.Single(I => I.Id == 2);
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
                        Processor = "10210U",
                        ProcessorVendor = "Intel",
                        SKU = "HBV00000X88NL",
                        IDSKU = 1,
                        Picture = "img.jpg",
                        UnitInStock = 100,
                        UnitPrice = 6699,
                        Vendor = "HP",
                        GraphicsCard = "Nvidia GeForce MX110",
                        QuantityPerUnit = 100,
                        DiscCapacity = "1 TB",
                        MemoryCapacity = "4 GB",
                        Category = context.Categories.Single(I => I.Id == 2),
                        CategoryId = 2
                    },

                    new Product()
                    {
                        Name = "HP 15S-FQ100NT",
                        Description = "HP 15S-FQ100NT Intel Core i5 1035G1 8GB 256GB SSD Windows 10 Home 15.6'' Taşınabilir Bilgisayar 8KR82EA",
                        IsAvailable = true,
                        Processor = "1035G1",
                        ProcessorVendor = "Intel",
                        SKU = "HBV00000Q9W14",
                        IDSKU = 2,
                        Picture = "img.jpg",
                        UnitInStock = 100,
                        UnitPrice = 7249,
                        Vendor = "HP",
                        GraphicsCard = "Nvidia GeForce MX110",
                        QuantityPerUnit = 100,
                        DiscCapacity = "256 GB",
                        MemoryCapacity = "4 GB",
                        Category = new Category()
                        {
                            Id = 2,
                            Name = "Ev - Ofis Laptop'ları",
                            Description = "Günlük temel düzeyde kullanımı temel alan ev - ofis bilgisayarları."
                        },
                        CategoryId = 2
                    }
                    
                    );
                context.SaveChanges();
            }
        }
    }
}