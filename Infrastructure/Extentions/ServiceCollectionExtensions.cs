using Domain.Repository;
using Infrastructure.Database;
using Infrastructure.Interfaces;
using Infrastructure.Repositoy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extentions;

public static class ServiceCollectionExtensions
{

    public static void AddInfrastructure(this IServiceCollection services, IConfiguration conf)
    {
        AddDbContext(services, conf);
        AddServices(services);
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration conf)
    {
        var connectionString = conf.GetConnectionString("APP_DATABASE");
        if (connectionString == null)
            throw new Exception("connectionString not found");

        services.AddDbContext<AppDbContext>(op =>
        {
            op.UseSqlite(connectionString);
        });

        /*services.AddDbContext<AppDbContext>(op =>
        {
            op.UseSqlite(connectionString, x => x.MigrationsAssembly("Infrastructure"));
        });*/
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<ISeeder, Seeder>();
        services.AddScoped<IGuestRepository, GuestRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
    }

}

