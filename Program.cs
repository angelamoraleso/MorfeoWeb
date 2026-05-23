using Microsoft.EntityFrameworkCore;
using MorfeoWeb.Models;

namespace MorfeoWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 1. Obtienes la cadena de texto limpia desde el appsettings.json
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // 2. Detectamos automáticamente la versión de tu servidor MySQL para evitar errores
            var serverVersion = ServerVersion.AutoDetect(connectionString);

            // 3. Configuramos el DbContext correctamente pasándole la conexión y la versión
            builder.Services.AddDbContext<MorfeoContext>(options =>
                options.UseMySql(connectionString, serverVersion));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}