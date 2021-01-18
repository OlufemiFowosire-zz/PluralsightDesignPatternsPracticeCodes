using System;

namespace BridgePattern
{
    public class MovieLicense
    {
        private readonly Discount discount;
        private readonly LicenseType licenseType;
        private readonly SpecialOffer specialOffer;

        public string Movie { get; }
        public DateTime PurchaseTime { get; }

        public MovieLicense(
            string movie, 
            DateTime purchaseTime,
            LicenseType licenseType,
            Discount discount = Discount.None,
            SpecialOffer specialOffer = SpecialOffer.None
            )
        {
            this.discount = discount;
            this.licenseType = licenseType;
            this.specialOffer = specialOffer;
            Movie = movie;
            PurchaseTime = purchaseTime;
        }
        public decimal GetPrice()
        {
            var multiplier = 1 - GetDiscount() / 100m;
            return GetBasePrice() * multiplier;
        }
        protected int GetDiscount()
        {
            return discount switch
            {
                Discount.None => 0,
                Discount.Military => 10,
                Discount.Senior => 20,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        protected decimal GetBasePrice()
        {
            return licenseType switch
            {
                LicenseType.TwoDays => 4,
                LicenseType.LifeLong => 8,
                _ => throw new ArgumentOutOfRangeException(),
            };
        }
        public DateTime? GetExpirationDate()
        {
            return GetBaseExpirationDate()?.Add(GetSpecialOffer());
        }
        public DateTime? GetBaseExpirationDate()
        {
            return licenseType switch
            {
                LicenseType.TwoDays => PurchaseTime.AddDays(2),
                LicenseType.LifeLong => null,
                _ => throw new ArgumentOutOfRangeException(),
            };
        }
        public TimeSpan GetSpecialOffer()
        {
            return specialOffer switch
            {
                SpecialOffer.None => TimeSpan.Zero,
                SpecialOffer.TwoDaysExtension => TimeSpan.FromDays(2),
                _ => throw new ArgumentOutOfRangeException(),
            };
        }
    }
    public enum LicenseType
    {
        TwoDays,
        LifeLong
    }

    //public class TwoDaysLicense : MovieLicense
    //{
    //    public TwoDaysLicense(string movie, DateTime purchaseTime, Discount discount)
    //        : base(movie, purchaseTime, discount)
    //    {
    //    }

    //    protected override decimal GetPriceCore() => 4;

    //    public override DateTime? GetExpirationDate() => PurchaseTime.AddDays(2);
    //}

    //public class LifeLongLicense : MovieLicense
    //{
    //    public LifeLongLicense(string movie, DateTime purchaseTime, Discount discount)
    //        : base(movie, purchaseTime, discount)
    //    {
    //    }

    //    protected override decimal GetPriceCore() => 8;

    //    public override DateTime? GetExpirationDate() => null;
    //}
    public enum Discount
    {
        None,
        Military,
        Senior
    }
    public enum SpecialOffer
    {
        None,
        TwoDaysExtension
    }
    //public abstract class Discount
    //{
    //    public abstract int GetDiscount();
    //}

    //public class NoDiscount : Discount
    //{
    //    public override int GetDiscount() => 0;
    //}

    //public class MilitaryDiscount : Discount
    //{
    //    public override int GetDiscount() => 10;
    //}

    //public class SeniorDiscount : Discount
    //{
    //    public override int GetDiscount() => 20;
    //}
}
