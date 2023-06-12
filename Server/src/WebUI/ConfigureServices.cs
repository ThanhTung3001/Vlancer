using TSoft.TaskManagement.Application.Common.Interfaces;
using TSoft.TaskManagement.Infrastructure.Persistence;
using TSoft.TaskManagement.WebUI.Filters;
using TSoft.TaskManagement.WebUI.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using NSwag;
using NSwag.Generation.Processors.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    [Obsolete]
    public static IServiceCollection AddWebUIServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddScoped<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        services.AddControllersWithViews(options =>
                options.Filters.Add<ApiExceptionFilterAttribute>())
            .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

        services.AddRazorPages();

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        services.AddOpenApiDocument(configure =>
        {
            configure.Title = "TSoft.TaskManagement API";
            configure.AddSecurity("JWT", Enumerable.Empty<string>(),
                new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."
                });

            configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
        });
        var issuer = configuration["Jwt:Issuer"];
        Console.Write(issuer);
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
         .AddJwtBearer(options =>
         {
             options.RequireHttpsMetadata = false;
             options.SaveToken = true;
             options.TokenValidationParameters = new TokenValidationParameters
             {
                 ValidIssuer = configuration["Jwt:Issuer"],
                 ValidAudience = configuration["Jwt:Audience"],
                 IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!)),
                 ValidateIssuer = true,
                 ValidateAudience = true,
                 ValidateLifetime = false,
                 ValidateIssuerSigningKey = true
             };
         });

        return services;
    }
}