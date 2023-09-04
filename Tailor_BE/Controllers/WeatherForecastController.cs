using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tailor_Infrastructure.Services.IServices;

namespace Tailor_BE.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ILoggedUserService _logger1;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ILoggedUserService logger1)
        {
            _logger = logger;
            _logger1 = logger1;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public string Get()
        {
            return _logger1.UserName;
        }
    }
}