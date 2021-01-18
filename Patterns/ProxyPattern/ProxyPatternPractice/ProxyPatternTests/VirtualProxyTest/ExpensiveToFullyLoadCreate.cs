using System;
using System.Linq;
using VirtualProxy;
using Xunit;

namespace ProxyPatternTests.VirtualProxyTest
{
    public class ExpensiveToFullyLoadCreate
    {
        [Fact]
        public void LogsConstructionHistory()
        {
            var obj = ExpensiveToFullyLoad.Create();

            Assert.Equal("Constructor called.", obj.History.Last());
        }

        [Fact]
        public void LogsCollectionLoadingToHistory()
        {
            var obj = ExpensiveToFullyLoad.Create();
            var list = obj.HomeEntities;

            Assert.Equal(2, obj.History.Count());

            var anotherList = obj.AwayEntities;
            Assert.Equal(3, obj.History.Count());
        }
    }
}
