using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository(ShoppingContext context) : base(context)
        {
        }

        public override IEnumerable<Order> Find(Expression<Func<Order, bool>> predicate)
        {
            return context.Orders
                .Include(o => o.LineItems)
                .ThenInclude(li => li.Product)
                .Where(predicate);
        }

        public override Order Update(Order entity)
        {
            var order = context.Orders
                .Include(o => o.LineItems)
                .ThenInclude(li => li.Product)
                .Single(o => o.OrderId == entity.OrderId);

            order.Customer = entity.Customer;
            order.OrderDate = entity.OrderDate;
            order.LineItems = entity.LineItems;

            //entity.LineItems.ToList().ForEach(el =>
            //{
            //    var ol = order.LineItems.Single(l => el.LineItemId == l.LineItemId);

            //    // To add new line item to the database context
            //    if (ol == null)
            //    {
            //        order.LineItems.Add(el);
            //        return;
            //    }

            //    // To update existing line item in the database context
            //    ol.Product = el.Product;
            //    ol.Quantity = el.Quantity;
            //});

            //// To remove deleted line items from current order in the database context
            //order.LineItems.ToList().ForEach(ol => 
            //{
            //    if (entity.LineItems.Contains(ol)) return;
            //    order.LineItems.Remove(ol);
            //}
            //);

            return base.Update(order);
        }
    }
}
