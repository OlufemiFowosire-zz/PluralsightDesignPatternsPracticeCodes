using System;
using System.Globalization;

namespace ChainOfResponsibilityApp.Business.Models
{
    public class User
    {
        public User(string name, string socialSecurityNumber, RegionInfo regionInfo, DateTimeOffset dateTimeOffset)
        {
            Name = name;
            SocialSecurityNumber = socialSecurityNumber;
            CitizenshipRegion = regionInfo;
            DateOfBirth = dateTimeOffset;
        }

        public string SocialSecurityNumber { get; internal set; }
        public RegionInfo CitizenshipRegion { get; internal set; }
        public int Age => (int)((DateTimeOffset.UtcNow - DateOfBirth.UtcDateTime).TotalDays / 365.2425);
        public DateTimeOffset DateOfBirth { get; }
        public string Name { get; internal set; }
    }
}