namespace TemplateMethod
{
    public class PizzaBakingService : PanFoodServiceBase<Pizza>
    {
        public PizzaBakingService(LoggerAdapter logger) : base(logger)
        {
        }

        protected override void Slice()
        {
            logger.Log("Cutting into 8 slices.");
        }

        protected override void Bake()
        {
            logger.Log("Baking for 15 minutes");
        }

        protected override void AddToppings()
        {
            logger.Log("Adding pizza toppings");
        }

        protected override void PrepareCrust()
        {
            logger.Log("Rolling out and hand tossing the dough");
        }
    }
}
