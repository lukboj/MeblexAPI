using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MeblexData.Interfaces;
using MeblexData.Mocks;
using MeblexData.Repositories;
using MeblexData.Models;
using Microsoft.AspNetCore.Identity;
using MeblexData.Data;
using MeblexData.Models.ShoppingCart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Meblex.Services.Interfaces;
using Meblex.Services;

namespace Meblex
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<MeblexData.Data.AppDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("AppDbContext")));

            services.AddScoped<IAdminRepository, AdminRepository>();

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IProductService, ProductService>();


            //services.AddRazorPages()
            //      .AddMvcOptions(options =>
            //{
            //  options.MaxModelValidationErrors = 50;
            // options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
            //_ => "The field is required.");
            //});

            //services.AddSingleton<IValidationAttributeAdapterProvider,
            //    CustomValidationAttributeAdapterProvider>();

            services.AddAutoMapper(typeof(Startup));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShoppingCart.GetCart(sp));
            services.AddSession();
            services.AddMemoryCache();
            services.AddHttpContextAccessor();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            AppDbContext appDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();

            DbInitializer.Seed(userManager, roleManager, appDbContext);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "categoryFilter",
                    pattern: "{controller=Product}/{action=List}/{category?}",
                    defaults: new { Controller = "Product", action = "List" }
                    );
            });
        }
    }
}
