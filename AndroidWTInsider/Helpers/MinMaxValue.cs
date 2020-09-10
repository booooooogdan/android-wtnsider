using System;
using System.Collections.Generic;
using System.Linq;
using AndroidWTInsider.DataArrays;

namespace AndroidWTInsider.Helpers
{
    class MinMaxValue
    {
        List<DataPoint> dataPointsList;

        /// <summary>
        /// Find maximum value for charts
        /// </summary>
        /// <param name="chartsData">Data provider</param>
        /// <param name="chartTask">Case of task</param>
        /// <returns>Max value from List</returns>
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

        /// <summary>
        /// Find minimum value for charts
        /// </summary>
        /// <param name="chartsData">Data provider</param>
        /// <param name="chartTask">Case of task</param>
        /// <returns>Min value from List</returns>
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