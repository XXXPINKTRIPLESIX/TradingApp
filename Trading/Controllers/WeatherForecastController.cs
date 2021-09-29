using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;
using Trading.Interfaces.Database;

namespace Trading.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IRepository<Balance, int> _balanceRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IRepository<Balance, int> balanceRepository)
        {
            _logger = logger;
            _balanceRepository = balanceRepository;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            Balance balance = new Balance(0, 0, new Currency(0, "USD", CurrencyType.Fiat), 100);
            _balanceRepository.Add(balance);

            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
