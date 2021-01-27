using Moq;
using MyShop.Domain.Models;
using MyShop.Infrastructure;
using MyShop.Infrastructure.Repositories;
using MyShop.Web.Controllers;
using MyShop.Web.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace MyShop.Web.Tests
{
    public class OrderControllerTests
    {
        [Fact]
        public void CanCreateOrderWithConcreteModel()
        {
            // Arrange
            //var orderRepository = new Mock<IRepository<Order>>();
            //var productRepository = new Mock<IRepository<Product>>();
            //var orderController = new OrderController(orderRepository.Object, productRepository.Object);

            var unitOfWork = new Mock<IUnitOfWork>();

            unitOfWork.SetupGet<IRepository<Order>>(u => u.OrderRepository).Returns(Mock.Of<IRepository<Order>>);
            unitOfWork.SetupGet<IRepository<Customer>>(u => u.CustomerRepository).Returns(Mock.Of<IRepository<Customer>>);
            unitOfWork.SetupGet<IRepository<Product>>(u => u.ProductRepository).Returns(Mock.Of<IRepository<Product>>);

            var orderController = new OrderController(unitOfWork.Object);
            var createOrderModel = new CreateOrderModel
            {
                Customer = new CustomerModel
                {
                    Name = "Olufemi Fowosire",
                    ShippingAddress = "Test Address",
                    City = "Test City",
                    PostalCode = "234"
                },
                LineItems = new[]{
                    new LineItemModel{ProductId = Guid.NewGuid(), Quantity = 2},
                    new LineItemModel{ProductId = Guid.NewGuid(), Quantity = 12}
                }
            };

            // Act
            orderController.Create(createOrderModel);

            // Assert
            //unitOfWork.Verify(repository => repository.(It.IsAny<Order>()), Times.AtMostOnce());
            unitOfWork.Verify();
        }
    }
}
