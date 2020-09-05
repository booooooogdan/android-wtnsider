using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidWTInsider.DataArrays;

namespace AndroidWTInsider.Helpers
{
    class MinMaxValue
    {
        ChartsDataPoints chartsDataPoints;
        List<DataPoint> dataPoints;

        public double MaximumYValue()
        {
            chartsDataPoints = new ChartsDataPoints();
            double max = 0;
            foreach (string nation in NationArray.Nations())
            {
                dataPoints = chartsDataPoints.GetLineDataPoint(nation);
                double probably = Convert.ToDouble(dataPoints.Max(x => x.YValue));
                if (probably > max)
                    max = probably;
            }
            return max;
        }

        public double MinimumYValue()
        {
            chartsDataPoints = new ChartsDataPoints();
            double min = 1000000;
            foreach (string nation in NationArray.Nations())
            {
                dataPoints = chartsDataPoints.GetLineDataPoint(nation);
                double probably = Convert.ToDouble(dataPoints.Min(x => x.YValue));
                if (probably < min)
                    min = probably;
            }
            return min;
        }
    }
}