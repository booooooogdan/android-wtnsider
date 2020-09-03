using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;
using System.Collections.ObjectModel;
using Android.Graphics;
using Android.Content;
using AndroidWTInsider.XmlHandler;
using System.Collections.Generic;
using AndroidWTInsider.Models;
using Akavache;
using System.Reactive.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace AndroidWTInsider
{
    [Activity]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        #region Initialization non View values

        Context context;
        ArrayOfPlanes arrayOfPlanes;
        List<Plane> planesAll;
        SfChart chart;
        #endregion

        /// <summary>
        /// Base Android OnCreate method. Entry point for app
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            #region Initialization required elements
            Syncfusion.Licensing.SyncfusionLicenseProvider
                .RegisterLicense("MzExNTgyQDMxMzgyZTMyMmUzMENBYUR1b2xmRHhjZ2tKblVPWlI5Vm9rYTRSSDlwRDhvalQrbUMzaGhqZXM9");
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            context = ApplicationContext;
            #endregion

            FillListFromCacheAsync().ConfigureAwait(false);
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);

            //ChartInitialization();
            ChartInitialization2();
        }

        private async Task FillListFromCacheAsync()
        {
            arrayOfPlanes = await BlobCache.UserAccount.GetObject<ArrayOfPlanes>("cachedArrayOfPlanes");
        }

        private void ChartInitialization()
        {
            chart = FindViewById<SfChart>(Resource.Id.sfChart1);
            chart.Title.Text = "Chart";
            chart.SetBackgroundColor(Color.White);

            //Initializing primary axis
            CategoryAxis primaryAxis = new CategoryAxis();
            primaryAxis.Title.Text = "Name";
            chart.PrimaryAxis = primaryAxis;

            //Initializing secondary Axis
            NumericalAxis secondaryAxis = new NumericalAxis();
            secondaryAxis.Title.Text = "Height (in cm)";
            chart.SecondaryAxis = secondaryAxis;

            ObservableCollection<ChartData> data = new ObservableCollection<ChartData>()
            {
                new ChartData { Name = "David", Height = 180 },
                new ChartData { Name = "Michael", Height = 170 },
                new ChartData { Name = "Steve", Height = 160 },
                new ChartData { Name = "Joel", Height = 182 }
            };

            //Initializing column series
            ColumnSeries series = new ColumnSeries();
            series.ItemsSource = data;
            series.XBindingPath = "Name";
            series.YBindingPath = "Height";

            series.DataMarker.ShowLabel = true;
            series.Label = "Heights";
            series.TooltipEnabled = true;
            chart.Legend.Visibility = Visibility.Visible;
            chart.Series.Add(series);
        }

        private void ChartInitialization2()
        {
            chart = FindViewById<SfChart>(Resource.Id.sfChart1);

            chart.Title.Text = "Monthly Expenses of a Family";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.DockPosition = ChartDock.Bottom;
            chart.Legend.IconHeight = 14;
            chart.Legend.IconWidth = 14;
            chart.Legend.ToggleSeriesVisibility = true;

            CategoryAxis categoryaxis = new CategoryAxis();
            categoryaxis.LabelPlacement = LabelPlacement.BetweenTicks;
            categoryaxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            categoryaxis.ShowMajorGridLines = false;
            categoryaxis.AxisLineOffset = 10;
            categoryaxis.PlotOffset = 10;
            categoryaxis.MajorTickStyle.TickSize = 10;
            chart.PrimaryAxis = categoryaxis;

            NumericalAxis numericalaxis = new NumericalAxis();
            numericalaxis.Minimum = 0;
            numericalaxis.Maximum = 100;
            numericalaxis.Interval = 10;
            numericalaxis.LineStyle.StrokeWidth = 0;
            numericalaxis.MajorTickStyle.TickSize = 0;
            numericalaxis.LabelStyle.LabelFormat = "'$'#";
            chart.SecondaryAxis = numericalaxis;

            StackingLineSeries stackingline1 = new StackingLineSeries();
            stackingline1.ItemsSource = GetStackingLineData1();
            stackingline1.XBindingPath = "XValue";
            stackingline1.YBindingPath = "YValue";
            stackingline1.DataMarker.ShowMarker = true;
            stackingline1.DataMarker.MarkerColor = Color.White;
            stackingline1.DataMarker.MarkerWidth = 10;
            stackingline1.DataMarker.MarkerHeight = 10;
            stackingline1.DataMarker.MarkerStrokeColor = Color.ParseColor("#00bdae");
            stackingline1.DataMarker.MarkerStrokeWidth = 2;
            stackingline1.Label = "Daughter";
            stackingline1.StrokeWidth = 3;
            stackingline1.TooltipEnabled = true;

            //StackingLineSeries stackingline2 = new StackingLineSeries();
            //stackingline2.ItemsSource = GetStackingLineData2();
            //stackingline2.XBindingPath = "XValue";
            //stackingline2.YBindingPath = "YValue";
            //stackingline2.Label = "Son";
            //stackingline2.DataMarker.ShowMarker = true;
            //stackingline2.DataMarker.MarkerColor = Color.White;
            //stackingline2.DataMarker.MarkerWidth = 10;
            //stackingline2.DataMarker.MarkerHeight = 10;
            //stackingline2.DataMarker.MarkerStrokeColor = Color.ParseColor("#404041");
            //stackingline2.DataMarker.MarkerStrokeWidth = 2;
            //stackingline2.StrokeWidth = 3;
            //stackingline2.TooltipEnabled = true;

            //StackingLineSeries stackingline3 = new StackingLineSeries();
            //stackingline3.ItemsSource = GetStackingLineData3();
            //stackingline3.XBindingPath = "XValue";
            //stackingline3.YBindingPath = "YValue";
            //stackingline3.DataMarker.ShowMarker = true;
            //stackingline3.DataMarker.MarkerColor = Color.White;
            //stackingline3.DataMarker.MarkerWidth = 10;
            //stackingline3.DataMarker.MarkerHeight = 10;
            //stackingline3.DataMarker.MarkerStrokeColor = Color.ParseColor("#357cd2");
            //stackingline3.DataMarker.MarkerStrokeWidth = 2;
            //stackingline3.Label = "Mother";
            //stackingline3.StrokeWidth = 3;
            //stackingline3.TooltipEnabled = true;

            //StackingLineSeries stackingline4 = new StackingLineSeries();
            //stackingline4.ItemsSource = GetStackingLineData4();
            //stackingline4.XBindingPath = "XValue";
            //stackingline4.YBindingPath = "YValue";
            //stackingline4.Label = "Father";
            //stackingline4.DataMarker.ShowMarker = true;
            //stackingline4.DataMarker.MarkerColor = Color.White;
            //stackingline4.DataMarker.MarkerWidth = 10;
            //stackingline4.DataMarker.MarkerHeight = 10;
            //stackingline4.DataMarker.MarkerStrokeColor = Color.ParseColor("#e56590");
            //stackingline4.DataMarker.MarkerStrokeWidth = 2;
            //stackingline4.StrokeWidth = 3;
            //stackingline4.TooltipEnabled = true;

            stackingline1.EnableAnimation = true;
            //stackingline2.EnableAnimation = true;
            //stackingline3.EnableAnimation = true;
            //stackingline4.EnableAnimation = true;

            chart.Series.Add(stackingline1);
            //chart.Series.Add(stackingline2);
            //chart.Series.Add(stackingline3);
            //chart.Series.Add(stackingline4);

        }


        public List<DataPoint> GetStackingLineData1()
        {
            double[] numbers = new double[] { 1.0, 1.3, 1.7, 2.0, 2.3, 2.7, 3.0, 3.3, 3.7, 4.0, 4.3, 4.7, 5.0, 5.3, 5.7, 6.0, 6.3, 6.7, 7.0, 7.3, 7.7, 8.0, 8.3, 8.7, 9.0, 9.3, 9.7, 10.0, 10.3 };
            planesAll = arrayOfPlanes.PlanesListApi;
         //   planesAll = planesAll.Where(x => x.Nation == "USA").ToList();
            var datas = new List<DataPoint>();
            foreach (double number in numbers)
            {
                datas.Add(new DataPoint(number, 55));
            }
            return datas;
        }



        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    //var intentStatistics = new Intent(this, typeof(StatisticsActivity));
                    //intentStatistics.AddFlags(ActivityFlags.NoAnimation);
                    //StartActivity(intentStatistics);
                    return true;
                case Resource.Id.navigation_dashboard:
                    return true;
                case Resource.Id.navigation_notifications:
                    return true;
            }
            return false;
        }
    }
}

