using FacadePattern.Entities;
using System;

namespace FacadePattern.Services
{
    public class WeatherService
    {
        public WeatherService()
        {
        }

        internal int GetTempFahrenheit(City city, State state)
        {
            return 53;
        }
    }
}