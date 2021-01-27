using MyShop.Domain.Models;
using MyShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShoppingContext context;
        private IRepository<Order> orderRepository;
        private IRepository<Customer> customerRepository;
        private IRepository<Product> productRepository;

        public UnitOfWork(ShoppingContext context)
        {
            this.context = context;
        }

        public IRepository<Product> ProductRepository
        {
            get
            {
                if(productRepository == null)
                {
                    productRepository = new ProductRepository(context);
                }
                return productRepository;
            }
        } 
        public IRepository<Customer> CustomerRepository
        {
            get
            {
                if (customerRepository == null)
                {
                    customerRepository = new CustomerRepository(context);
                }
                return customerRepository;
            }
        }
        public IRepository<Order> OrderRepository
        {
            get
            {
                if (orderRepository == null)
                {
                    orderRepository = new OrderRepository(context);
                }
                return orderRepository;
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
