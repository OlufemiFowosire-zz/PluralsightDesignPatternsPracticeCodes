using MyShop.Domain.Models;
using MyShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure
{
    public interface IUnitOfWork
    {
        IRepository<Order> OrderRepository { get; }
        IRepository<Customer> CustomerRepository { get; }
        IRepository<Product> ProductRepository { get; }

        void SaveChanges();
    }
}
