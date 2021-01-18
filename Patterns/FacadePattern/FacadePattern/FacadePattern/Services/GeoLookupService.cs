using FacadePattern.Entities;
using System;

namespace FacadePattern.Services
{
    public class GeoLookupService
    {
        public GeoLookupService()
        {
        }

        internal City GetCityForZipCode(string zipCode)
        {
            return new City { Name = "Redmond" };
        }

        internal State GetStateForZipCode(string zipCode)
        {
            return new State { Name = "Washington" };
        }
    }
}