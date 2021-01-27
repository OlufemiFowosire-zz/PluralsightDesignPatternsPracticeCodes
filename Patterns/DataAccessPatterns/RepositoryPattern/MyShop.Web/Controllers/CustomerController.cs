using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Models;
using MyShop.Infrastructure;
using MyShop.Infrastructure.Repositories;

namespace MyShop.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepository<Customer> customerRepository;
        //private ShoppingContext context;

        public CustomerController(IRepository<Customer> customerRepository)
        {
            //context = new ShoppingContext();
            this.customerRepository = customerRepository;
        }

        public IActionResult Index(Guid? id)
        {
            if (id == null)
            {
                //var customers = context.Customers.ToList();
                var customers = customerRepository.All();

                return View(customers);
            }
            else
            {
                //var customer = context.Customers.Find(id.Value);
                var customer = customerRepository.Get(id.Value);

                return View(new[] { customer });
            }
        }
    }
}
