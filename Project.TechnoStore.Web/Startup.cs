using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.TechnoStore.Business.Concrete;
using Project.TechnoStore.Business.Interfaces;
using Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Contexts;
using Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Repositories;
using Project.TechnoStore.Data.Interfaces;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();


            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IOrderDal, EfOrderRepository>();
            services.AddScoped<IProductDal, EfProductRepository>();
            services.AddScoped<ICategoryDal, EfCategoryRepository>();

            services.AddDbContext<TechnoStoreDbContext>();

            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<TechnoStoreDbContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = new PathString("/Account/Login");
                opt.Cookie.Name = "TechnoStoreCookie";
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.ExpireTimeSpan = TimeSpan.FromDays(90);
            });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            IdentityInitializer.SeedData(userManager, roleManager).Wait();
            //SeedCategory.EnsurePopulated(app);
            //SeedProduct.EnsurePopulated(app);
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
                );


                endpoints.MapControllerRoute("pagination", "urunler/sayfa{productPage}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("products", "urunler/{productId}/{name}",
                    new { Controller = "Home", action = "Product" });

                endpoints.MapControllerRoute("category", "Kategori/Bilgisayar/Oyun",
                    new { Controller = "Category", action = "Gaming" });

                endpoints.MapControllerRoute("category2", "Kategori/Bilgisayar/EvOfis",
                    new { Controller = "Category", action = "HomeOffice" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );

            });
        }
    }
}
