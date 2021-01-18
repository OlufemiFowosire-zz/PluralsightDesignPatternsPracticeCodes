using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualProxy
{
    public class LazyExpensiveToFullyLoad : BaseClassWithHistory
    {
        private Lazy<IEnumerable<ExpensiveEntity>> homeEntities;
        private Lazy<IEnumerable<ExpensiveEntity>> awayEntities;

        public IEnumerable<ExpensiveEntity> HomeEntities => homeEntities.Value;
        public IEnumerable<ExpensiveEntity> AwayEntities => awayEntities.Value;

        public LazyExpensiveToFullyLoad()
        {
            History.Add("Constructor called.");
            homeEntities = new Lazy<IEnumerable<ExpensiveEntity>>(
                () => ExpensiveDataSource.GetEntities(this)
            );
            awayEntities = new Lazy<IEnumerable<ExpensiveEntity>>(
                () => ExpensiveDataSource.GetEntities(this)
            );
        }
    }
}
