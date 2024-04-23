using Asp.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        AddApiVersioning(services);

        return services;
    }



    ///<summary>
    /// Add API Versioning when using Controllers
    /// If using Minimal APIs, consider the Nuget Package "Asp.Versioning.Http"
    /// </summary>
    /// <param name="services"></param>
    private static void AddApiVersioning(IServiceCollection services)
    {
        services
        .AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1);
            options.ReportApiVersions = true;
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
        })
        .AddMvc()
        .AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'API Version 'VVV";
            options.SubstituteApiVersionInUrl = true;
        });
    }

}

