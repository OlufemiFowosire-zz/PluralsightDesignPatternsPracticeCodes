using MyShop.Domain.Lazy.Ghost;
using MyShop.Domain.Lazy.Proxy;
using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository(ShoppingContext context) : base(context)
        {
        }

        public override IEnumerable<Customer> All()
        {
            return base.All().Select(MapToProxy);
        }

        public override IEnumerable<Customer> Find(Expression<Func<Customer, bool>> predicate)
        {
            return base.Find(predicate).Select(MapToProxy);
        }

        public override Customer Get(Guid id)
        {
            var customerId = context.Customers.Where(c => c.CustomerId == id).Select(c => c.CustomerId).Single();

            return new GhostCustomer(()=>base.Get(id)) 
            { 
                CustomerId = customerId
            };
        }

        public override Customer Update(Customer entity)
        {
            var customer = context.Customers.Single(c => c.CustomerId == entity.CustomerId);

            customer.Name = entity.Name;
            customer.PostalCode = entity.PostalCode;
            customer.ShippingAddress = entity.ShippingAddress;
            customer.City = entity.City;
            customer.Country = entity.Country;

            return base.Update(customer);
        }

        private CustomerProxy MapToProxy(Customer c)
        {
            return new CustomerProxy
            {
                CustomerId = c.CustomerId,
                Name = c.Name,
                City = c.City,
                Country = c.Country,
                PostalCode = c.PostalCode,
                ShippingAddress = c.ShippingAddress
            };
        }
    }
}
