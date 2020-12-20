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
    public static class SeedPayment
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            TechnoStoreDbContext context = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<TechnoStoreDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Payments.Any())
            {
                context.Payments.AddRange(

                    new Payment()
                    {
                        PaymentType = "Kredi / Banka Kartı"
                    },

                    new Payment()
                    {
                        PaymentType = "Kapıda Ödeme"
                    },

                    new Payment()
                    {
                        PaymentType = "Havale"
                    }

                );
                context.SaveChanges();
            }

        }
    }
}
