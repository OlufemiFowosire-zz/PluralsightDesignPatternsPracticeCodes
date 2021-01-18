using System;
using System.Collections.Generic;

namespace VirtualProxy
{
    public class ExpensiveDataSource
    {
        public static IEnumerable<ExpensiveEntity> GetEntities(BaseClassWithHistory owner)
        {
            var list = new List<ExpensiveEntity>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new ExpensiveEntity { Id = 1 });
            }
            owner.History.Add("Got expensive entities from source.");
            return list;
        }
    }
}