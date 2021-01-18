using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecoratorDesignPattern.WeatherInterface
{
    public class WeatherServiceCachingDecorator : IWeatherService
    {
        /**
        private readonly IWeatherService weatherService;
        private readonly Dictionary<string, CurrentWeather> storedWeather;

        public WeatherServiceCachingDecorator(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
            storedWeather = new Dictionary<string, CurrentWeather>();
        }
        public CurrentWeather GetCurrentWeather(string location)
        {
            CurrentWeather currentWeather = null;
            if (storedWeather.ContainsKey(location))
            {
                currentWeather = storedWeather[location];
            }
            else
            {
                currentWeather = weatherService.GetCurrentWeather(location);
                storedWeather[location] = currentWeather;
            }
            return currentWeather;
        }

        public LocationForecast GetForecast(string location)
        {
            LocationForecast forecast = weatherService.GetForecast(location);
            return forecast;
        }
        */
        private readonly IWeatherService weatherService;
        private readonly IMemoryCache cache;

        public WeatherServiceCachingDecorator(IWeatherService weatherService, IMemoryCache cache)
        {
            this.weatherService = weatherService;
            this.cache = cache;
        }
        public CurrentWeather GetCurrentWeather(string location)
        {
            string cacheKey = $"WeatherConditions::{location}";
            if(cache.TryGetValue<CurrentWeather>(cacheKey, out CurrentWeather currentWeather))
            {
                return currentWeather;
            }
            else
            {
                currentWeather = weatherService.GetCurrentWeather(location);
                cache.Set<CurrentWeather>(cacheKey, currentWeather, TimeSpan.FromMinutes(30));
                return currentWeather;
            }
        }

        public LocationForecast GetForecast(string location)
        {
            string cacheKey = $"WeatherForecast::{location}";
            if (cache.TryGetValue<LocationForecast>(cacheKey, out LocationForecast forecast))
            {
                return forecast;
            }
            else
            {
                forecast = weatherService.GetForecast(location);
                cache.Set<LocationForecast>(cacheKey, forecast, TimeSpan.FromMinutes(30));
                return forecast;
            }
        }
    }
}
