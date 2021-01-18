using ChainOfResponsibilityApp.Business.Exceptions;
using System;
using System.Globalization;

namespace ChainOfResponsibilityApp.Business.Validators
{
    internal class SocialSecurityNumberValidator
    {
        public bool Validate(string socialSecurityNumber, RegionInfo citizenshipRegion)
        {
            switch (citizenshipRegion.TwoLetterISORegionName)
            {
                case "SE": return ValidateSwedishSocialSecurityNumber(socialSecurityNumber);
                case "US": return ValidateUnitedStatesSocialSecurityNumber(socialSecurityNumber);
                default: throw new UnsupportedSocialSecurityNumberException();
            }

            // C# 8.0 version
            //return region.TwoLetterISORegionName switch
            //{
            //    "SE" => ValidateSwedishSocialSecurityNumber(socialSecurityNumber),
            //    "US" => ValidateUnitedStatesSocialSecurityNumber(socialSecurityNumber),
            //    _ => throw new UnsupportedSocialSecurityNumberException()
            //};
        }

        private bool ValidateUnitedStatesSocialSecurityNumber(string socialSecurityNumber)
        {
            // Not actually how it's done..

            return socialSecurityNumber.Length > 2;
        }

        private bool ValidateSwedishSocialSecurityNumber(string socialSecurityNumber)
        {
            // Not actually how it's done..

            return socialSecurityNumber.Length > 1;
        }
    }
}