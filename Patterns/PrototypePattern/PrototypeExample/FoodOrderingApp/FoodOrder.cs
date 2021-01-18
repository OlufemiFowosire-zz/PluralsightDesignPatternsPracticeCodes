using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp
{
    public class FoodOrder : Prototype
    {
        public string CustomerName { get; set; }
        public bool IsDelivery { get; set; }
        public string[] OrderContents { get; set; }
        public OrderInfo OrderInfo { get; set; }

        public FoodOrder(string customerName, bool isDelivery, string[] orderContents, OrderInfo orderInfo)
        {
            CustomerName = customerName;
            IsDelivery = isDelivery;
            OrderContents = orderContents;
            OrderInfo = orderInfo;
        }

        public override Prototype ShallowCopy()
        {
            return this.MemberwiseClone() as Prototype;
        }

        public override Prototype DeepCopy()
        {
            var clonedOrder = this.MemberwiseClone() as FoodOrder;
            clonedOrder.OrderInfo = new OrderInfo(OrderInfo.Id);

            return clonedOrder;
        }

        public override void Debug()
        {
            Console.WriteLine("\n----------- Prototype Food Order -------------");
            Console.WriteLine($"\nName: {CustomerName} \nDelivery: {IsDelivery}");
            Console.WriteLine($"ID: {OrderInfo.Id}");
            Console.WriteLine($"Order Contents: {string.Join(", ", OrderContents)}\n");
        }
    }
}
