using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DecoratorDesignPattern.WeatherInterface
{
    public class WeatherServiceLoggingDecorator : IWeatherService
    {
        private readonly IWeatherService weatherService;
        private readonly ILogger<WeatherServiceLoggingDecorator> logger;

        public WeatherServiceLoggingDecorator(IWeatherService weatherService, ILogger<WeatherServiceLoggingDecorator> logger)
        {
            this.weatherService = weatherService;
            this.logger = logger;
        }
        public CurrentWeather GetCurrentWeather(string location)
        {
            Stopwatch sw = Stopwatch.StartNew();
            CurrentWeather currentWeather = weatherService.GetCurrentWeather(location);
            sw.Stop();
            logger.LogWarning($"Retrieved weather data for " +
                $"{location} - " +
                $"Elapsed ms: {sw.ElapsedMilliseconds}, " +
                $"{currentWeather}");
            return currentWeather;
        }

        public LocationForecast GetForecast(string location)
        {
            Stopwatch sw = Stopwatch.StartNew();
            LocationForecast forecast = weatherService.GetForecast(location);
            sw.Stop();
            logger.LogWarning($"Retrieved forecast data for " +
                $"{location} - " +
                $"Elapsed ms: {sw.ElapsedMilliseconds}, " +
                $"{forecast}");
            return forecast;
        }
    }
}
