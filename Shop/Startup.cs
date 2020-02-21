using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Domain.Interfaces;
using Shop.Infrastructure.Business;
using Shop.Infrastructure.Data;
using Shop.Services.Interfaces;

namespace Shop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ShopContext>(options => options.UseSqlServer(connection, sqlServerOptions => sqlServerOptions.MigrationsAssembly("Shop")));

            services.AddScoped<IBranchOfficeRepository, BranchOfficeRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IDeliveryRepository, DeliveryRepository>();
            services.AddScoped<IDiscountCardRepository, DiscountCardRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IMarkdownRepository, MarkdownRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPromotionRepository, PromotionRepository>();
            services.AddScoped<IPurchaseReturnRepository, PurchaseReturnRepository>();
            services.AddScoped<IRentRepository, RentRepository>();
            services.AddScoped<IStorageRepository, StorageRepository>();

            services.AddScoped<IOrder, BankCardOrder>();
            services.AddScoped<IEmployee, EmployeeAccount>();
            services.AddScoped<IDelivery, StorageDelivery>();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}