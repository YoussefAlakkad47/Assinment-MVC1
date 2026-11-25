namespace Assinment_MVC1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.UseExceptionHandler("/Home/Error"); // 1
            app.UseStaticFiles();                   // 2

            // Use · Run · Map
            // الفرع ده لوحده على /pipeline.
            // Run هنا بيقفل الفرع بس. لو اتحط على البايبلاين الأساسي الـ MVC مش هيشتغل.
            ((IApplicationBuilder)app).Map("/pipeline", branch =>
            {
                branch.Use(async (context, next) =>
                {
                    Console.Write("A ");
                    await next(context);
                    Console.Write("D ");
                });

                branch.Use(async (context, next) =>
                {
                    Console.Write("B ");
                    await next(context);
                    Console.Write("C ");
                });

                branch.Run(async context =>
                {
                    await context.Response.WriteAsync("Hi");
                });
            });

            app.UseRouting();                       // 3
            app.UseAuthorization();                 // 4

            // specific route FIRST
            app.MapControllerRoute(
                name: "shop",
                pattern: "shop/{id:int}",
                defaults: new { controller = "Products", action = "Details" });

            // general route LAST
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
