using System;
using System.Collections.Generic;
using System.Linq;
using AndroidWTInsider.DataArrays;

namespace AndroidWTInsider.Helpers
{
    class MinMaxValue
    {
        IDataGenerator chartsData;
        List<DataPoint> dataPointsList;

        public double MaximumYValue(IDataGenerator chartsData, string chartTask)
        {
            double max = 0;
            foreach (string nation in NationArray.Nations())
            {
                dataPointsList = chartsData.GetLineDataPoint(nation, chartTask);
                double probably = Convert.ToDouble(dataPointsList.Max(x => x.YValue));
                if (probably > max)
                    max = probably;
            }
            return max;
        }

        public double MinimumYValue(IDataGenerator chartsData, string chartTask)
        {
            double min = double.MaxValue;
            foreach (string nation in NationArray.Nations())
            {
                dataPointsList = chartsData.GetLineDataPoint(nation, chartTask);
                double probably = Convert.ToDouble(dataPointsList.Min(x => x.YValue));
                if (probably < min)
                    min = probably;
            }
            return min;
        }
    }
}