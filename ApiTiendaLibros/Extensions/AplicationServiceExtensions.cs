using Core.Interfaces;
using Infraestructura.Repositories;
using Infraestructura.UnitOfWork;

namespace ApiTiendaLibros.Extensions;

public static class AplicationServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(Options =>
        {
            Options.AddPolicy("CorsPolicy", builer =>
            builer.AllowAnyOrigin() //WhithOrigins("https://dominio.com")
            .AllowAnyMethod() //WithMethods("GET", "POST")
            .AllowAnyHeader()); //WhithHeards("accept", "content-type")
        });
    }

    public static void AddApplicationServices(this IServiceCollection services)
    {
        //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        //services.AddScoped<IClienteRepository, ClienteRepository>();
        //services.AddScoped<ILibroRepository, LibroRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
