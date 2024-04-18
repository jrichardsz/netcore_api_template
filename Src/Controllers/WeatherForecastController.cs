using Microsoft.AspNetCore.Mvc;
using Src.Repository;

namespace WebApplication2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private IMovieRepository movieRepository;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IMovieRepository movieRepository)
    {
        _logger = logger;
        this.movieRepository = movieRepository;
    }

    [HttpGet]
    [Route("/WeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
    
    [HttpGet]
    [Route("/movie")]
    public List<Dictionary<string, object>> GetMovies()
    {
        return this.movieRepository.FindMovies();
    }
}