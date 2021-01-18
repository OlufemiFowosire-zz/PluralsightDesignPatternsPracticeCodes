using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternApp
{
    public interface IFurnitureInventoryBuilder
    {
        IFurnitureInventoryBuilder AddTitle();
        IFurnitureInventoryBuilder AddDimensions();
        IFurnitureInventoryBuilder AddLogistics(DateTime dateTime);
        InventoryReport GetDailyReport();
    }
}
