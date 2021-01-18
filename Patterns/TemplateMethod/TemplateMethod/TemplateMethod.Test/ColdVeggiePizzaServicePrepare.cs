using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace TemplateMethod.Test
{
    public class ColdVeggiePizzaServicePrepare
    {
        private readonly ITestOutputHelper output;

        public ColdVeggiePizzaServicePrepare(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ReturnsAColdPizzaVeggie()
        {
            var logger = new LoggerAdapter();
            var service = new ColdVeggiePizzaService(logger);

            var coldVeggiePizza = service.Prepare();

            Assert.NotNull(coldVeggiePizza);
            output.WriteLine(logger.Dump());
        }
    }
}
