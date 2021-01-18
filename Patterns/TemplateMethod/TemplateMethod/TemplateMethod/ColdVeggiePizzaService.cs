using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethod
{
    public class ColdVeggiePizzaService : PanFoodServiceBase<ColdVeggiePizza>
    {
        public ColdVeggiePizzaService(LoggerAdapter logger) : base(logger)
        {

        }
        protected override void AddToppings()
        {
            logger.Log("Add cream cheese, peppers, and veggies");
        }

        protected override void PrepareCrust()
        {
            logger.Log("Rolling out dough and press into pan");
        }

        protected override void Slice()
        {
            logger.Log("Slice into squares");
        }
    }
}
