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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                    name: "productDetails",
                    pattern: "Product/Details/{id}",
                    defaults: new { controller = "Product", action = "Details" });

            app.Run();
        }
    }
}