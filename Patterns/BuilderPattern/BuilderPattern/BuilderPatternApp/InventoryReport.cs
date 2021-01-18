using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternApp
{
    public class InventoryReport
    {
        public string TitleSection;
        public string DimensionsSection;
        public string LogisticsSection;

        public string Debug()
        {
            return new StringBuilder()
                .AppendLine(TitleSection)
                .AppendLine(DimensionsSection)
                .AppendLine(LogisticsSection)
                .ToString();
        }
    }
}
