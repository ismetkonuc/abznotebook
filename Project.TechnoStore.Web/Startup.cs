using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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

            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IOrderDal, EfOrderRepository>();
            services.AddScoped<IProductDal, EfProductRepository>();

            services.AddDbContext<TechnoStoreDbContext>();

            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<TechnoStoreDbContext>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            IdentityInitializer.SeedData(userManager, roleManager).Wait();
            //SeedCategory.EnsurePopulated(app);
            SeedProduct.EnsurePopulated(app);
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
