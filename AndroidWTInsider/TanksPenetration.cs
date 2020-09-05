using Android.App;
using Android.Content;
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
    public class TanksPenetration : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {

        SfChart chartView;
        ChartsLineInitializer chartsLineInitializer;
        ChartsDataPoints chartsData;
        Spinner spinner;

        /// <summary>
        /// Base Android OnCreate method. Entry point for app
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            #region Initialization required elements
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TanksCount);
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
            #endregion

            chartView = FindViewById<SfChart>(Resource.Id.sfChart1);
            chartsLineInitializer = new ChartsLineInitializer();
            chartsData = new ChartsDataPoints();

            SpinnerInitialization();
            chartsLineInitializer.ChartLineBinding(chartView, chartsData);
        }

        private void SpinnerInitialization()
        {
            spinner = FindViewById<Spinner>(Resource.Id.spinnerCount);
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, TanksTaskArray.TankTasks());
            spinner.Adapter = adapter;
            spinner.ItemSelected += Spinner_ItemSelected;
        }

        private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            spinner.SetSelection(0);
            switch (e.Position)
            {
                case 1:
                    var intentStatistics = new Intent(this, typeof(TanksPenetration));
                    intentStatistics.AddFlags(ActivityFlags.NoAnimation);
                    StartActivity(intentStatistics);
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
                    //var intentStatistics = new Intent(this, typeof(TanksPenetration));
                    //intentStatistics.AddFlags(ActivityFlags.NoAnimation);
                    //StartActivity(intentStatistics);
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