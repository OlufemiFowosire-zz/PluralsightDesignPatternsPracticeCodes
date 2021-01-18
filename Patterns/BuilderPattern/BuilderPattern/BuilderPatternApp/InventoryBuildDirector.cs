using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternApp
{
    public class InventoryBuildDirector
    {
        private readonly IFurnitureInventoryBuilder builder;

        public InventoryBuildDirector(IFurnitureInventoryBuilder builder)
        {
            this.builder = builder;
        }

        public InventoryReport BuildCompleteReport()
        {
            return 
                builder
                .AddTitle()
                .AddDimensions()
                .AddLogistics(DateTime.Now)
                .GetDailyReport();
        }
    }
}
