using FacadePattern.Entities;
using FacadePattern.Services;

namespace FacadePattern
{
    public class WeatherFacade : IWeatherFacade
    {
        private readonly ConverterService converterService;
        private readonly GeoLookupService geoLookupService;
        private readonly WeatherService weatherService;

        public WeatherFacade() : 
            this(
                new ConverterService(),
                new GeoLookupService(),
                new WeatherService()
            )
        {

        }
        public WeatherFacade(
            ConverterService converterService,
            GeoLookupService geoLookupService,
            WeatherService weatherService)
        {
            this.converterService = converterService;
            this.geoLookupService = geoLookupService;
            this.weatherService = weatherService;
        }
        public WeatherFacadeResults GetTempInCity(string zipCode)
        {
            City city = geoLookupService.GetCityForZipCode(zipCode);
            State state = geoLookupService.GetStateForZipCode(zipCode);
            int fahrenheit = weatherService.GetTempFahrenheit(city, state);
            int celsius = converterService.ConvertFahrenheitToCelsius(fahrenheit);

            WeatherFacadeResults result = new WeatherFacadeResults
            {
                City = city,
                State = state,
                Fahrenheit = fahrenheit,
                Celsius = celsius
            };

            return result;
        }
    }
}