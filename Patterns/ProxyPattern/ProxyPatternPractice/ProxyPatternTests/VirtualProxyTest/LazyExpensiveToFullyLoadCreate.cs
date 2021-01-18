using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualProxy;
using Xunit;
using Xunit.Abstractions;

namespace ProxyPatternTests.VirtualProxyTest
{
    public class LazyExpensiveToFullyLoadCreate
    {
        private readonly ITestOutputHelper output;

        public LazyExpensiveToFullyLoadCreate(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Fact]
        public void LogsConstructionHistory()
        {
            var obj = new LazyExpensiveToFullyLoad();

            Assert.Equal("Constructor called.", obj.History.Last());
            writeHistory(obj);
        }

        [Fact]
        public void LogsCollectionLoadingToHistory()
        {
            var obj = new LazyExpensiveToFullyLoad();
            output.WriteLine("Initial object created history:");
            writeHistory(obj);
            
            var list = obj.HomeEntities;
            Assert.Equal(2, obj.History.Count());
            output.WriteLine("Access HomeEntities. Now history:");
            writeHistory(obj);

            var anotherList = obj.AwayEntities;
            Assert.Equal(3, obj.History.Count());
            output.WriteLine("Access AwayEntities. Now history:");
            writeHistory(obj);
        }
        private void writeHistory(LazyExpensiveToFullyLoad obj)
        {
            obj.History.ForEach(h => output.WriteLine(h));
        }
    }
}
