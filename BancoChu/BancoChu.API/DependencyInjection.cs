using BancoChu.API.TokenSettings;
using BancoChu.Domain.Repositories;
using BancoChu.Persistence;
using BancoChu.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Scrutor;

namespace BancoChu.API;

public static class DependencyInjection
{
    public static IServiceCollection AddAuthenticationAndAuthorization(this IServiceCollection services)
    {
        services.ConfigureOptions<GetJwtSettings>();
        services.ConfigureOptions<JwtOptionsSettings>();

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();

        services.AddAuthorization();

        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly));

        return services;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
        .Scan(
            selector => selector
                .FromAssemblies(
                    Infrastructure.AssemblyReference.Assembly,
                    Persistence.AssemblyReference.Assembly)
                .AddClasses(false)
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());

        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Database")!;
        services.AddDbContext<ApplicationDbContext>(op =>
                op.UseNpgsql(configuration.GetConnectionString("Database")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();

        return services;
    }
}