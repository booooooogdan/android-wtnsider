using Akavache;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using AndroidWTInsider.XmlHandler;
using Com.Syncfusion.Charts;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace AndroidWTInsider
{
    [Activity]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        #region Initialization non View values

        Context context;
        ArrayOfTanks arrayOfTanks;
        double[] numbers;
        SfChart chart;
        #endregion

        /// <summary>
        /// Base Android OnCreate method. Entry point for app
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            #region Initialization required elements
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            context = Application.Context;
            #endregion

            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);

            FillListFromCacheAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Load cached List of tanks
        /// </summary>
        private async Task FillListFromCacheAsync()
        {
            arrayOfTanks = await BlobCache.UserAccount.GetObject<ArrayOfTanks>("cachedArrayOfTanks");
            ChartInitialization();
        }

        private void ChartInitialization()
        {
            chart = FindViewById<SfChart>(Resource.Id.sfChart1);
            numbers = new double[] { 1.0, 1.3, 1.7, 2.0, 2.3, 2.7, 3.0, 3.3, 3.7, 4.0, 4.3, 4.7, 5.0, 5.3, 5.7, 6.0, 6.3, 6.7, 7.0, 7.3, 7.7, 8.0, 8.3, 8.7, 9.0, 9.3, 9.7, 10.0, 10.3, 10.7 };

            chart.Title.Text = "Count of vehicle";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            ChartTrackballBehavior trackballBehavior = new ChartTrackballBehavior();
            trackballBehavior.ShowLabel = true;
            trackballBehavior.ShowLine = true;
            trackballBehavior.ActivationMode = ChartTrackballActivationMode.TouchMove;
            chart.Behaviors.Add(trackballBehavior);

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
            numericalaxis.Maximum = 15;
            numericalaxis.Interval = 1;
            numericalaxis.LineStyle.StrokeWidth = 0;
            numericalaxis.MajorTickStyle.TickSize = 0;
            //numericalaxis.LabelStyle.LabelFormat = "'$'#";
            chart.SecondaryAxis = numericalaxis;

            LineSeries lineUsa = new LineSeries();
           lineUsa.ItemsSource = GetStackingLineUSA();
           lineUsa.XBindingPath = "XValue";
           lineUsa.YBindingPath = "YValue";
           lineUsa.Label = "USA";
           lineUsa.Color = Color.ParseColor("#64b5f6");
           lineUsa.StrokeWidth = 2;
           lineUsa.TooltipEnabled = true;

            LineSeries lineGermany = new LineSeries();
           lineGermany.ItemsSource = GetStackingLineGermany();
           lineGermany.XBindingPath = "XValue";
           lineGermany.YBindingPath = "YValue";
           lineGermany.Label = "Germany";
           lineGermany.Visibility = Visibility.Gone;
           lineGermany.Color = Color.ParseColor("#455a64");
           lineGermany.StrokeWidth = 2;
           lineGermany.TooltipEnabled = true;

            LineSeries lineUSSR = new LineSeries();
           lineUSSR.ItemsSource = GetStackingLineUSSR();
           lineUSSR.XBindingPath = "XValue";
           lineUSSR.YBindingPath = "YValue";
           lineUSSR.Label = "USSR";
           lineUSSR.Color = Color.ParseColor("#d50000");
           lineUSSR.StrokeWidth = 2;
           lineUSSR.TooltipEnabled = true;

            LineSeries lineBritain = new LineSeries();
            lineBritain.ItemsSource = GetStackingLineBritain();
            lineBritain.XBindingPath = "XValue";
            lineBritain.YBindingPath = "YValue";
            lineBritain.Label = "Britain";
            lineBritain.Visibility = Visibility.Gone;
            lineBritain.Color = Color.ParseColor("#8e24aa");
            lineBritain.StrokeWidth = 2;
            lineBritain.TooltipEnabled = true;

            LineSeries lineJapan = new LineSeries();
            lineJapan.ItemsSource = GetStackingLineJapan();
            lineJapan.XBindingPath = "XValue";
            lineJapan.YBindingPath = "YValue";
            lineJapan.Label = "Japan";
            lineJapan.Visibility = Visibility.Gone;
            lineJapan.Color = Color.ParseColor("#f06292");
            lineJapan.StrokeWidth = 2;
            lineJapan.TooltipEnabled = true;

            LineSeries lineItaly = new LineSeries();
            lineItaly.ItemsSource = GetStackingLineItaly();
            lineItaly.XBindingPath = "XValue";
            lineItaly.YBindingPath = "YValue";
            lineItaly.Label = "Italy";
            lineItaly.Color = Color.ParseColor("#7cb342");
            lineItaly.StrokeWidth = 2;
            lineItaly.TooltipEnabled = true;

            LineSeries lineFrance = new LineSeries();
            lineFrance.ItemsSource = GetStackingLineFrance();
            lineFrance.XBindingPath = "XValue";
            lineFrance.YBindingPath = "YValue";
            lineFrance.Label = "France";
            lineFrance.Visibility = Visibility.Gone;
            lineFrance.Color = Color.ParseColor("#3f51b5");
            lineFrance.StrokeWidth = 2;
            lineFrance.TooltipEnabled = true;

            LineSeries lineChina = new LineSeries();
            lineChina.ItemsSource = GetStackingLineChina();
            lineChina.XBindingPath = "XValue";
            lineChina.YBindingPath = "YValue";
            lineChina.Label = "China";
            lineChina.Visibility = Visibility.Gone;
            lineChina.Color = Color.ParseColor("#f57c00");
            lineChina.StrokeWidth = 2;
            lineChina.TooltipEnabled = true;

            LineSeries lineSweden = new LineSeries();
            lineSweden.ItemsSource = GetStackingLineSweden();
            lineSweden.XBindingPath = "XValue";
            lineSweden.YBindingPath = "YValue";
            lineSweden.Label = "Sweden";
            lineSweden.Visibility = Visibility.Gone;
            lineSweden.Color = Color.ParseColor("#ffeb3b");
            lineSweden.StrokeWidth = 2;
            lineSweden.TooltipEnabled = true;

            lineUsa.EnableAnimation = true;
            lineGermany.EnableAnimation = true;
            lineUSSR.EnableAnimation = true;
            lineBritain.EnableAnimation = true;
            lineJapan.EnableAnimation = true;
            lineItaly.EnableAnimation = true;
            lineFrance.EnableAnimation = true;
            lineChina.EnableAnimation = true;
            lineSweden.EnableAnimation = true;

            chart.Series.Add(lineUsa);
            chart.Series.Add(lineGermany);
            chart.Series.Add(lineUSSR); 
            chart.Series.Add(lineBritain);
            chart.Series.Add(lineJapan);
            chart.Series.Add(lineItaly);
            chart.Series.Add(lineFrance);
            chart.Series.Add(lineChina);
            chart.Series.Add(lineSweden);

        }


        public List<DataPoint> GetStackingLineUSA()
        {
            var tanksAll = arrayOfTanks.TanksListApi.Where(x => x.Nation == "USA").ToList();
            var datas = new List<DataPoint>();
            foreach (double number in numbers)
            {
                var tanksCount = tanksAll.Where(x => x.BR == number).Count();
                datas.Add(new DataPoint(number, tanksCount));
            }
            return datas;
        }

        public List<DataPoint> GetStackingLineGermany()
        {
            var tanksAll = arrayOfTanks.TanksListApi.Where(x => x.Nation == "Germany").ToList();
            var datas = new List<DataPoint>();
            foreach (double number in numbers)
            {
                var tanksCount = tanksAll.Where(x => x.BR == number).Count();
                datas.Add(new DataPoint(number, tanksCount));
            }
            return datas;
        }

        public List<DataPoint> GetStackingLineUSSR()
        {
            var tanksAll = arrayOfTanks.TanksListApi.Where(x => x.Nation == "USSR").ToList();
            var datas = new List<DataPoint>();
            foreach (double number in numbers)
            {
                var tanksCount = tanksAll.Where(x => x.BR == number).Count();
                datas.Add(new DataPoint(number, tanksCount));
            }
            return datas;
        }

        public List<DataPoint> GetStackingLineBritain()
        {
            var tanksAll = arrayOfTanks.TanksListApi.Where(x => x.Nation == "Britain").ToList();
            var datas = new List<DataPoint>();
            foreach (double number in numbers)
            {
                var tanksCount = tanksAll.Where(x => x.BR == number).Count();
                datas.Add(new DataPoint(number, tanksCount));
            }
            return datas;
        }

        public List<DataPoint> GetStackingLineJapan()
        {
            var tanksAll = arrayOfTanks.TanksListApi.Where(x => x.Nation == "Japan").ToList();
            var datas = new List<DataPoint>();
            foreach (double number in numbers)
            {
                var tanksCount = tanksAll.Where(x => x.BR == number).Count();
                datas.Add(new DataPoint(number, tanksCount));
            }
            return datas;
        }

        public List<DataPoint> GetStackingLineItaly()
        {
            var tanksAll = arrayOfTanks.TanksListApi.Where(x => x.Nation == "Italy").ToList();
            var datas = new List<DataPoint>();
            foreach (double number in numbers)
            {
                var tanksCount = tanksAll.Where(x => x.BR == number).Count();
                datas.Add(new DataPoint(number, tanksCount));
            }
            return datas;
        }

        public List<DataPoint> GetStackingLineFrance()
        {
            var tanksAll = arrayOfTanks.TanksListApi.Where(x => x.Nation == "France").ToList();
            var datas = new List<DataPoint>();
            foreach (double number in numbers)
            {
                var tanksCount = tanksAll.Where(x => x.BR == number).Count();
                datas.Add(new DataPoint(number, tanksCount));
            }
            return datas;
        }

        public List<DataPoint> GetStackingLineChina()
        {
            var tanksAll = arrayOfTanks.TanksListApi.Where(x => x.Nation == "China").ToList();
            var datas = new List<DataPoint>();
            foreach (double number in numbers)
            {
                var tanksCount = tanksAll.Where(x => x.BR == number).Count();
                datas.Add(new DataPoint(number, tanksCount));
            }
            return datas;
        }

        public List<DataPoint> GetStackingLineSweden()
        {
            var tanksAll = arrayOfTanks.TanksListApi.Where(x => x.Nation == "Sweden").ToList();
            var datas = new List<DataPoint>();
            foreach (double number in numbers)
            {
                var tanksCount = tanksAll.Where(x => x.BR == number).Count();
                datas.Add(new DataPoint(number, tanksCount));
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

