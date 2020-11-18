using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Contexts;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Web.Seeders
{
    public static class SeedOrderDetails
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            TechnoStoreDbContext context = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<TechnoStoreDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.OrderDetails.Any())
            {
                context.OrderDetails.AddRange(

                    new OrderDetail()
                    {
                        OrderId = 1,
                        ProductId = 1,
                        Price = 1,
                        Quantity = 1
                    }
                );
                context.SaveChanges();
            }

        }
    }
}
