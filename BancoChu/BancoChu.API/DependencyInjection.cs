using BancoChu.API.TokenSettings;
using BancoChu.Domain.Repositories;
using BancoChu.Persistence;
using BancoChu.Persistence.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
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

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIContagem", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description =
                    "JWT Authorization Header - used with Bearer Authentication.\r\n\r\n" +
                    "Enter 'Bearer' [space] and then your token in the field below.\r\n\r\n" +
                    "Example (enter without quotes): 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
        });

        services.AddAuthorization();

        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly));

        services.AddValidatorsFromAssembly(Application.AssemblyReference.Assembly);

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