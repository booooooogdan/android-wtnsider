using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Syncfusion.Charts;
using Android.Graphics;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidWTInsider.Helpers
{
    public class DataPoint
    {
        public DataPoint(object xVal, object yVal)
        {
            XValue = xVal;
            YValue = yVal;
        }
        public object XValue { get; set; }
        public object YValue { get; set; }

    }
}