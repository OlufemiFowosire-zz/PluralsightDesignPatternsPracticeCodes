using SingletonExample.LoggingService;
using SingletonNaiveApproach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
[assembly: CollectionBehavior(CollectionBehavior.CollectionPerClass, DisableTestParallelization = true)]

namespace SingletonTest
{
    public class SingletonTest
    {
        private ITestOutputHelper output;
        public SingletonTest(ITestOutputHelper output)
        {
            this.output = output;
            SingletonTestHelpers.Reset(typeof(Singleton));
            Logger.Clear();
        }
        [Fact]
        public void ReturnsNonNullsSingletonInstance()
        {
            Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<Singleton>());
            var result = Singleton.Instance;
            Assert.NotNull(result);
            Assert.IsType<Singleton>(result);
            
            Logger.Output().ToList().ForEach(h => output.WriteLine(h));
        }
        [Fact]
        public void OnlyCallsConstructorOnceGivenThreeInstanceCalls()
        {
            Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<Singleton>());

            var one = Singleton.Instance;
            var two = Singleton.Instance;
            var three = Singleton.Instance;

            var log = Logger.Output();
            Assert.Equal(1, log.Count(log => log.Contains("Constructor")));
            Assert.Equal(3, log.Count(log => log.Contains("Instance")));

            Logger.Output().ToList().ForEach(h => output.WriteLine(h));
        }
        [Fact]
        public void CallsConstructorMultipleTimesGivenThreeParallelInstanceCalls()
        {
            Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<Singleton>());
            Logger.DelayMilliseconds = 50;

            var strings = new List<string>{"one", "two", "three" };
            var instances = new List<Singleton>();
            var options = new ParallelOptions() { MaxDegreeOfParallelism = 3};
            Parallel.ForEach(strings, options, instance =>
            {
                instances.Add(Singleton.Instance);
            });
            var log = Logger.Output();
            try
            {
                Assert.True(log.Count(log => log.Contains("Constructor")) > 1);
                Assert.Equal(3, log.Count(log => log.Contains("Instance")));
            }
            finally
            {
                Logger.Output().ToList().ForEach(h => output.WriteLine(h));
            }
        }
    }
}
