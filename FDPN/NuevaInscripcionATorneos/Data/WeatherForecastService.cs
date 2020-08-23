using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuevaInscripcionATorneos.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }

        public List<WeatherForecast> GetData(DateTime startDate)
        {
            var rng = new Random();
            List<WeatherForecast> Listado = new List<WeatherForecast>();
            for(int i =0; i<5; i++)
            {
                WeatherForecast foreCast = new WeatherForecast
                {
                    Date = startDate.AddDays(i),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)],
                    Clase ="",
                };
                Listado.Add(foreCast);
            }
            return Listado;
        }
    }
}
