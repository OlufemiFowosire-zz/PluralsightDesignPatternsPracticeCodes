using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePattern
{
    public interface IWeatherFacade
    {
        WeatherFacadeResults GetTempInCity(string zipCode); 
    }
}
