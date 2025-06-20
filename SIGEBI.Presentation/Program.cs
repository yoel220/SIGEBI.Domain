using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using SIGEBI.Presentation.Forms;
using SIGEBI.Persistence.Context;
using SIGEBI.Persistence.Repositories;
using SIGEBI.Domain.Interfaces;

namespace SIGEBI.Presentation
{
    internal static class Program
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            ApplicationConfiguration.Initialize(); // Estilo moderno
            Application.Run(ServiceProvider.GetRequiredService<MainForm>());
        }

        static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Cadena de conexión directa (puedes cambiarla o leerla de un archivo)
                    services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer("Server=YOELMIS;Database=SIGEBI;User Id=sa;Password=Sariel123456;TrustServerCertificate=True;"));

                    // Registro de repositorios (del dominio)
                    services.AddScoped<IAutorRepository, AutorRepository>();
                    services.AddScoped<IEditorialRepository, EditorialRepository>();
                    services.AddScoped<ILibroRepository, LibroRepository>();
                    services.AddScoped<ILibroAutorRepository, LibroAutorRepository>();
                    services.AddScoped<IUsuarioRepository, UsuarioRepository>();
                    services.AddScoped<IPrestamoRepository, PrestamoRepository>();
                    services.AddScoped<IReservationRepository, ReservationRepository>();
                    services.AddScoped<INotificationRepository, NotificationRepository>();
                    services.AddScoped<IPenalizationRepository, PenalizationRepository>();
                    services.AddScoped<IRolRepository, RolRepository>();

                    // Registro de formularios
                    services.AddScoped<MainForm>();
                    services.AddScoped<LibroForm>();
                    services.AddScoped<AutorForm>();
                    services.AddScoped<EditorialForm>();
                });
    }
}