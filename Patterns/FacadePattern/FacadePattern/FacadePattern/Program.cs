using FacadePattern.Entities;
using FacadePattern.Services;
using System;

namespace FacadePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //BigClass bigClass = new BigClass();

            //bigClass.SetValueI(3);

            //bigClass.IncrementI();
            //bigClass.IncrementI();
            //bigClass.IncrementI();

            //bigClass.DecrementI();

            //Console.WriteLine($"Final Number: {bigClass.GetValueB()}");

            //BigClassFacade bigClass = new BigClassFacade();

            //bigClass.IncreaseBy(numberToAdd: 50);
            //bigClass.DecreaseBy(numberToSubtract: 20);

            //Console.WriteLine($"Final Number: {bigClass.GetCurrentValue()}");

            const string zipCode = "98074";

            // call to service 1
            //GeoLookupService geoLookupService = new GeoLookupService();
            //City city = geoLookupService.GetCityForZipCode(zipCode);
            //State state = geoLookupService.GetStateForZipCode(zipCode);

            //// call to service 2
            //WeatherService weatherService = new WeatherService();
            //int fahrenheit = weatherService.GetTempFahrenheit(city, state);

            //// call to service 3
            //ConverterService metricConverter = new ConverterService();
            //int celsius = metricConverter.ConvertFahrenheitToCelsius(fahrenheit);

            WeatherFacade weatherFacade = new WeatherFacade();

            var results = weatherFacade.GetTempInCity(zipCode);

            // bring the result of all service calls together
            Console.WriteLine(
                $"The current temperature is " +
                $"{results.Fahrenheit} F / " +
                $"{results.Celsius} C in " +
                $"{results.City.Name}, " +
                $"{results.State.Name}"
            );

        }
    }
}
