using System;

namespace FoodOrderingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Original Order:");
            //FoodOrder savedOrder = new FoodOrder("Harrison", true, new string[] { "Pizza", "Coke"}, new OrderInfo(1));
            //savedOrder.Debug();

            //Console.WriteLine("Cloned Order:");
            //FoodOrder clonedOrder = savedOrder.DeepCopy() as FoodOrder;
            //clonedOrder.Debug();

            //Console.WriteLine("Order Changes");
            //savedOrder.CustomerName = "Jeff";
            //savedOrder.OrderInfo.Id = 5555;

            //savedOrder.Debug();
            //clonedOrder.Debug();

            PrototypeManager manager = new PrototypeManager();
            manager["18/01/2021"] = new FoodOrder("Steve", true, new string[] { "Chicken Parm","Root Beer" }, new OrderInfo(8912));
            var managedOrder = manager["18/01/2021"].DeepCopy();
            managedOrder.Debug();
        }
    }
}
