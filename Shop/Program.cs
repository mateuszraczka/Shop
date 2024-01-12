using Microsoft.EntityFrameworkCore;
using Shop.Models.Contexts;
using Microsoft.AspNetCore.Identity;
using Shop.Areas.Identity.Data;

namespace Shop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Product services

            //Combined product services
            builder.Services.AddScoped<IProductServices, ProductServices>();

            //Seperate product services
            builder.Services.AddScoped<IProductFetchService, ProductFetchService>();
            builder.Services.AddScoped<IProductEditService, ProductEditService>();
            builder.Services.AddScoped<IProductDeleteService, ProductDeleteService>();
            builder.Services.AddScoped<IProductCreateService, ProductCreateService>();
            builder.Services.AddDbContext<ProductsDbContext>(options=> options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));
            builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<IdentityDbContext>();
            builder.Services.AddDbContext<CategoriesDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));
            builder.Services.AddDbContext<OrdersDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));
            builder.Services.AddDbContext<IdentityDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
                        app.UseAuthentication();;

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                    name: "productDetails",
                    pattern: "Product/Details/{id}",
                    defaults: new { controller = "Product", action = "Details" });
            app.MapRazorPages();

            app.Run();
        }
    }
}