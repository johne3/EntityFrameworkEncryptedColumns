using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EncryptedColumns.DataAccess;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>((serviceProvider, options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString("EncryptedColumnsDb"), sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());
        });

        return services;
    }
}

