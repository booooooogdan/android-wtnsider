using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Support.Design.Internal;
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
    public class ShipsLineChart : BottomNavigation, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        SfChart chartView;
        LineChartsInitializer chartsLineInitializer;
        ChartsShipDataGenerator chartsData;
        Spinner spinner;

        /// <summary>
        /// Base Android OnCreate method. Entry point for app
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            #region Initialization required elements
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ShipsLineChart);
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
            var coloredIcon = navigation.FindViewById<BottomNavigationItemView>(Resource.Id.menu_ship);
            coloredIcon.SetIconTintList(ColorStateList.ValueOf(Color.ParseColor("#00ACC1")));
            #endregion

            chartsLineInitializer = new LineChartsInitializer();
            chartView = FindViewById<SfChart>(Resource.Id.sfChartShip);
            chartsData = new ChartsShipDataGenerator();

            SpinnerInitialization();
        }

        private void SpinnerInitialization()
        {
            spinner = FindViewById<Spinner>(Resource.Id.spinnerShip);
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, ShipsTaskArray.ShipTasks());
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
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "mc");
                    spinner.SetSelection(2);
                    break;
                case 3:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "mcreload");
                    spinner.SetSelection(3);
                    break;
                case 4:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "torpedoitem");
                    spinner.SetSelection(4);
                    break;
                case 5:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "torpedomaxspeed");
                    spinner.SetSelection(5);
                    break;
                case 6:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "torpedotnt");
                    spinner.SetSelection(6);
                    break;
                case 7:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "maxspeed");
                    spinner.SetSelection(7);
                    break;
                case 8:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "brakingtime");
                    spinner.SetSelection(8);
                    break;
                case 9:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "turn360");
                    spinner.SetSelection(9);
                    break;
                case 10:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "armortower");
                    spinner.SetSelection(10);
                    break;
                case 11:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "armorhull");
                    spinner.SetSelection(11);
                    break;
                case 12:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "crewcount");
                    spinner.SetSelection(12);
                    break;      
                case 13:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "displacemet");
                    spinner.SetSelection(13);
                    break;
                case 14:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "firstlaunchyear");
                    spinner.SetSelection(14);
                    break;
            }
        }
    }
}