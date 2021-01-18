using System;
using System.Collections.Generic;
using System.Linq;

namespace BuilderPatternApp
{
    public class DailyReportBuilder : IFurnitureInventoryBuilder
    {
        private InventoryReport report;
        private readonly IEnumerable<FurnitureItem> items;

        public DailyReportBuilder(IEnumerable<FurnitureItem> items)
        {
            Reset();
            this.items = items;
        }

        // Essential for defensive coding
        public void Reset()
        {
            report = new InventoryReport();
        }
        public IFurnitureInventoryBuilder AddDimensions()
        {
            report.DimensionsSection = string.Join(Environment.NewLine, items.Select(item =>
            $"Product: {item.Name}\n" +
            $"Price: {item.Price}\n" +
            $"Height: {item.Height} x Width: {item.Width} -> Weight: {item.Height} lbs\n"));

            return this;
        }

        public IFurnitureInventoryBuilder AddLogistics(DateTime dateTime)
        {
            report.LogisticsSection = $"\nReport generated on {dateTime}";

            return this;
        }

        public IFurnitureInventoryBuilder AddTitle()
        {
            report.TitleSection = "----------------- Daily Inventory Report ------------------\n\n";

            return this;
        }

        public InventoryReport GetDailyReport()
        {
            InventoryReport finishedReport = report;
            Reset();

            return finishedReport;
        }
    }
}
