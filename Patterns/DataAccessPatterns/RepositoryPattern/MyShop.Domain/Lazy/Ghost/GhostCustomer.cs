using MyShop.Domain.Lazy.Proxy;
using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Lazy.Ghost
{
    public class GhostCustomer : CustomerProxy
    {
        private LoadStatus status;
        private readonly Func<Customer> load;

        public bool IsGhost => status == LoadStatus.GHOST;
        public bool IsLoaded => status == LoadStatus.LOADED;

        public GhostCustomer(Func<Customer> load) : base()
        {
            this.load = load;
            status = LoadStatus.GHOST;
        }
        public override string Name 
        {
            get
            {
                Load();
                return base.Name;
            }
            set
            {
                Load();
                base.Name = value;
            } 
        }
        public override string ShippingAddress { get => base.ShippingAddress; set => base.ShippingAddress = value; }
        public override string City { get => base.City; set => base.City = value; }
        public override string PostalCode { get => base.PostalCode; set => base.PostalCode = value; }
        public override string Country { get => base.Country; set => base.Country = value; }

        private void Load()
        {
            if(IsGhost)
            {
                status = LoadStatus.LOADING;

                var customer = load();
                base.Name = customer.Name;
                base.PostalCode = customer.PostalCode;
                base.ShippingAddress = customer.ShippingAddress;
                base.City = customer.City;
                base.Country = customer.Country;

                status = LoadStatus.LOADED;
            }
        }
    }

    enum LoadStatus
    {
        GHOST,
        LOADING,
        LOADED
    }
}
