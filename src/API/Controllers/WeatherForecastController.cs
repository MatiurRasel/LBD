using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[ApiVersion(ApiVersion.V1)]
[ApiVersion(ApiVersion.V2)]
[ApiVersion(ApiVersion.V3)]
[Route("api/v{version:apiVersion}/weather")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

    private static readonly string[] Summaries2 = new[]
    {
            "Freezing2", "Bracing2", "Chilly2", "Cool2", "Mild2", "Warm2", "Balmy2", "Hot2", "Sweltering2", "Scorching2"
        };

    private static readonly string[] Summaries3 = new[]
    {
            "Freezing3", "Bracing3", "Chilly3", "Cool3", "Mild3", "Warm3", "Balmy3", "Hot3", "Sweltering3", "Scorching3"
        };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet("weathers")]
    [MapToApiVersion(ApiVersion.V1)]
    public IEnumerable<WeatherForecast> GetV1()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("weathers")]
    [MapToApiVersion(ApiVersion.V2)]
    public IEnumerable<WeatherForecast> GetV2()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries2[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("weathers")]
    [MapToApiVersion(ApiVersion.V3)]
    public IEnumerable<WeatherForecast> GetV3()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries3[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}

