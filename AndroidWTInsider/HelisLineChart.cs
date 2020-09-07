using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using AndroidWTInsider.DataArrays;
using AndroidWTInsider.Helpers;
using Com.Syncfusion.Charts;

namespace AndroidWTInsider
{
    [Activity(ScreenOrientation = ScreenOrientation.Landscape)]
    public class HelisLineChart : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        SfChart chartView;
        LineChartsInitializer chartsLineInitializer;
        ChartsHeliDataGenerator chartsData;
        Spinner spinner;

        /// <summary>
        /// Base Android OnCreate method. Entry point for app
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            #region Initialization required elements
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HelisLineChart);
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
            #endregion

            chartsLineInitializer = new LineChartsInitializer();
            chartView = FindViewById<SfChart>(Resource.Id.sfChartHeli);
            chartsData = new ChartsHeliDataGenerator();

            SpinnerInitialization();
        }

        private void SpinnerInitialization()
        {
            spinner = FindViewById<Spinner>(Resource.Id.spinnerHeli);
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, HelisTaskArray.HeliTasks());
            spinner.Adapter = adapter;
            spinner.ItemSelected += Spinner_ItemSelected;
        }

        private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            spinner.SetSelection(0);
            switch (e.Position)
            {
                case 0:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "count");
                    spinner.SetSelection(0);
                    break;
                case 1:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "repaircost");
                    spinner.SetSelection(1);
                    break;
                case 2:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "maxspeed");
                    spinner.SetSelection(2);
                    break;
                case 3:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "climbto1000");
                    spinner.SetSelection(3);
                    break;
                case 4:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "weight");
                    spinner.SetSelection(4);
                    break;
                case 5:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "agmcount");
                    spinner.SetSelection(5);
                    break;
                case 6:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "agmrange");
                    spinner.SetSelection(6);
                    break;
                case 7:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "asmcount");
                    spinner.SetSelection(7);
                    break;
                case 8:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "firstflyyear");
                    spinner.SetSelection(8);
                    break;
            }
        }

        /// <summary>
        /// Menu navigation method
        /// </summary>
        /// <param name="item">Menu item</param>
        /// <returns></returns>
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_plane:
                    //    var intentStatistics = new Intent(this, typeof(HelisPenetration));
                    //    intentStatistics.AddFlags(ActivityFlags.NoAnimation);
                    //    StartActivity(intentStatistics);
                    return true;
                case Resource.Id.menu_tank:
                    return true;
                case Resource.Id.menu_heli:
                    return true;
                case Resource.Id.menu_ship:
                    return true;
                case Resource.Id.menu_feedback:
                    return true;
            }
            return false;
        }
    }
}