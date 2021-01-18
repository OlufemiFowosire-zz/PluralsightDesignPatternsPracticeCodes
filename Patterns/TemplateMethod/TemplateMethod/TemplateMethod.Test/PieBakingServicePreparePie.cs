using Xunit;
using Xunit.Abstractions;

namespace TemplateMethod.Test
{
    public class PieBakingServicePreparePie
    {
        private readonly ITestOutputHelper output;

        public PieBakingServicePreparePie(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ReturnsAPie()
        {
            var logger = new LoggerAdapter();
            var service = new PieBakingService(logger);

            Pie pie = service.Prepare();

            Assert.NotNull(pie);
            output.WriteLine(logger.Dump());
        }
    }
}
