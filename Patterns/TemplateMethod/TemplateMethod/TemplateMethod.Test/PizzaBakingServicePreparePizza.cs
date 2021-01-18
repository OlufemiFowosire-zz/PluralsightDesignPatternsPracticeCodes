using Xunit;
using Xunit.Abstractions;

namespace TemplateMethod.Test
{
    public class PizzaBakingServicePreparePizza
    {
        private readonly ITestOutputHelper output;

        public PizzaBakingServicePreparePizza(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ReturnsAPizza()
        {
            var logger = new LoggerAdapter();
            var service = new PizzaBakingService(logger);
            
            Pizza pizza = service.Prepare();

            Assert.NotNull(pizza);
            output.WriteLine(logger.Dump());
        }
    }
}
