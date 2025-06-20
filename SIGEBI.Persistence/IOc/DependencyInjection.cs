using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sigebi.Aplication.Interfaces.Repository;
using Sigebi.Aplication.Interfaces.Service;
using Sigebi.Aplication.Service;
using SIGEBI.Domain.Interfaces.Repository;
using SIGEBI.Persistence.Context;
using SIGEBI.Persistence.Repositories;



namespace SIGEBI.Persistence.IOc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // Register DbContext with SQL Server
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 3,
                            maxRetryDelay: TimeSpan.FromSeconds(10),
                            errorNumbersToAdd: new List<int>()); // Provide an empty list for 'errorNumbersToAdd'
                    })
                    .EnableSensitiveDataLogging()
                    .LogTo(Console.WriteLine, LogLevel.Information);
            });

            // Other service registrations remain unchanged
            services.AddScoped(typeof(IGeneryRepository<>), typeof(GeneryRepository<>));
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

            services.AddScoped(typeof(IGeneryService<>), typeof(GeneryService<>));
            services.AddScoped<IAutorService, AutorService>();
            services.AddScoped<IEditorService, EditorService>();
            services.AddScoped<ILibroService, LibroService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPrestamoService, PrestamoService>();
            services.AddScoped<IReservacionService, ReservacionesService>();
            services.AddScoped<INotificacionesService, NotificacionesService>();
            services.AddScoped<IPenalizacionService, PenalizacionService>();
            services.AddScoped<IRolService, RolService>();

            return services;
        }
    }
}
