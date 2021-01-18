using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethod
{
    public class PieBakingService : PanFoodServiceBase<Pie>
    {
        public PieBakingService(LoggerAdapter logger) : base(logger)
        {
        }

        protected override void Slice()
        {
            logger.Log("Cutting into 6 slices.");
        }

        protected override void Bake()
        {
            logger.Log("Baking for 45 minutes");
        }

        protected override void Cover()
        {
            logger.Log("Adding lattice top");
        }

        protected override void AddToppings()
        {
            logger.Log("Adding pie fillings");
        }

        protected override void PrepareCrust()
        {
            logger.Log("Rolling out crust and pressing into pie pan");
        }
    }
}
