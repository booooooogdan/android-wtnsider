﻿using Android.App;
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
    public class TanksLineChart : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {

        SfChart chartView;
        LineChartsInitializer chartsLineInitializer;
        ChartsTankDataGenerator chartsData;
        Spinner spinner;

        /// <summary>
        /// Base Android OnCreate method. Entry point for app
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            #region Initialization required elements
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TanksLineChart);
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
            #endregion

            chartsLineInitializer = new LineChartsInitializer();
            chartView = FindViewById<SfChart>(Resource.Id.sfChartTank);
            chartsData = new ChartsTankDataGenerator();

            SpinnerInitialization();
        }

        private void SpinnerInitialization()
        {
            spinner = FindViewById<Spinner>(Resource.Id.spinnerTank);
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, TanksTaskArray.TankTasks());
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
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "maxspeedatroad");
                    spinner.SetSelection(3);
                    break;
                case 4:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "maxspeedreverse");
                    spinner.SetSelection(4);
                    break;
                case 5:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "enginepower");
                    spinner.SetSelection(5);
                    break;
                case 6:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "weight");
                    spinner.SetSelection(6);
                    break;
                case 7:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "penetration");
                    spinner.SetSelection(7);
                    break;
                case 8:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "reload");
                    spinner.SetSelection(8);
                    break;
                case 9:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "turretarmor");
                    spinner.SetSelection(9);
                    break;
                case 10:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "toparmor");
                    spinner.SetSelection(10);
                    break;
                case 11:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "bottomarmor");
                    spinner.SetSelection(11);
                    break;               
                case 12:
                    chartsLineInitializer.ChartLineInit(chartView, chartsData, "firstrideyear");
                    spinner.SetSelection(12);
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
                    var intentPlane = new Intent(this, typeof(PlanesLineChart));
                    intentPlane.AddFlags(ActivityFlags.NoAnimation);
                    StartActivity(intentPlane);
                    return true;
                case Resource.Id.menu_tank:
                    var intentTank = new Intent(this, typeof(TanksLineChart));
                    intentTank.AddFlags(ActivityFlags.NoAnimation);
                    StartActivity(intentTank);
                    return true;
                case Resource.Id.menu_heli:
                    var intentHeli = new Intent(this, typeof(HelisLineChart));
                    intentHeli.AddFlags(ActivityFlags.NoAnimation);
                    StartActivity(intentHeli);
                    return true;
                case Resource.Id.menu_ship:
                    var intentShip = new Intent(this, typeof(ShipsLineChart));
                    intentShip.AddFlags(ActivityFlags.NoAnimation);
                    StartActivity(intentShip);
                    return true;
                case Resource.Id.menu_feedback:
                    return true;
            }
            return false;
        }
    }
}