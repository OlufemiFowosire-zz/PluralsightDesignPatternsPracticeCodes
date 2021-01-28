using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using MyShop.Infrastructure;
using MyShop.Infrastructure.Repositories;
using MyShop.Web.Models;

namespace MyShop.Web.Controllers
{
    public class OrderController : Controller
    {
        //private ShoppingContext context;
        //private readonly IRepository<Order> orderRepository;
        //private readonly IRepository<Product> productRepository;
        //private readonly IRepository<Customer> customerRepository;
        private readonly IUnitOfWork unitOfWork;

        public OrderController(
            IUnitOfWork unitOfWork
            )
        {
            //context = new ShoppingContext();
            //this.orderRepository = orderRepository;
            //this.productRepository = productRepository;
            //this.customerRepository = customerRepository;
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            //var orders = context.Orders
            //    .Include(order => order.LineItems)
            //    .ThenInclude(lineItem => lineItem.Product)
            //    .Where(order => order.OrderDate > DateTime.UtcNow.AddDays(-1)).ToList();

            var orders = unitOfWork.OrderRepository.Find(order => order.OrderDate > DateTime.UtcNow.AddDays(-1));

            return View(orders);
        }

        public IActionResult Create()
        {
            //var products = context.Products.ToList();

            var products = unitOfWork.ProductRepository.All();

            return View(products);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderModel model)
        {
            #region Model Validation
            if (!model.LineItems.Any()) return BadRequest("Please submit line items");

            if (string.IsNullOrWhiteSpace(model.Customer.Name)) return BadRequest("Customer needs a name");
            #endregion

            var customer = unitOfWork.CustomerRepository.Find(c => c.Name == model.Customer.Name).FirstOrDefault();
            if(customer != null)
            {
                customer.ShippingAddress = model.Customer.ShippingAddress;
                customer.City = model.Customer.ShippingAddress;
                customer.PostalCode = model.Customer.PostalCode;
                customer.Country = model.Customer.Country;

                unitOfWork.CustomerRepository.Update(customer);
            }
            else
            {
                customer = new Customer
                {
                    Name = model.Customer.Name,
                    ShippingAddress = model.Customer.ShippingAddress,
                    City = model.Customer.City,
                    PostalCode = model.Customer.PostalCode,
                    Country = model.Customer.Country
                };
            }

            var order = new Order
            {
                LineItems = model.LineItems
                    .Select(line => new LineItem { ProductId = line.ProductId, Quantity = line.Quantity })
                    .ToList(),

                Customer = customer
            };

            //context.Orders.Add(order);
            //context.SaveChanges();

            unitOfWork.OrderRepository.Add(order);
            unitOfWork.SaveChanges();

            return Ok("Order Created");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
