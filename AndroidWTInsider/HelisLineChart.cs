using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Support.Design.Internal;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Gms.Ads;
using Android.Widget;
using AndroidWTInsider.DataArrays;
using AndroidWTInsider.Helpers;
using Com.Syncfusion.Charts;

namespace AndroidWTInsider
{
    [Activity(ScreenOrientation = ScreenOrientation.Landscape)]
    public class HelisLineChart : BottomNavigation, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        SfChart chartView;
        LineChartsInitializer chartsLineInitializer;
        ChartsHeliDataGenerator chartsData;
        Spinner spinner;
        Context context;

        /// <summary>
        /// Base Android OnCreate method. Entry point for app
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            #region Initialization required elements
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HelisLineChart);
            context = Application.Context;
            #endregion

            chartsLineInitializer = new LineChartsInitializer();
            chartView = FindViewById<SfChart>(Resource.Id.sfChartHeli);
            chartsData = new ChartsHeliDataGenerator();

            AdsInitialize();
            SpinnerInitialize();
            BottomMenuInitialize();
        }

        /// <summary>
        /// AdMob banner initialize
        /// </summary>
        private void AdsInitialize()
        {
            MobileAds.Initialize(context);
            var adView = FindViewById<AdView>(Resource.Id.adsHeli);
            //adView.LoadAd(new AdRequest.Builder().Build());
            var requestbuilder = new AdRequest.Builder().AddTestDevice("46CCAB8BBCE5B5FFA79C22BEB98029AC");
            adView.LoadAd(requestbuilder.Build());
        }

        /// <summary>
        /// Set adapter for spinner menu
        /// </summary>
        private void SpinnerInitialize()
        {
            spinner = FindViewById<Spinner>(Resource.Id.spinnerHeli);
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, HelisTaskArray.HeliTasks());
            spinner.Adapter = adapter;
            spinner.ItemSelected += Spinner_ItemSelected;
        }

        /// <summary>
        /// Highlight selected menu item
        /// </summary>
        private void BottomMenuInitialize()
        {
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
            var coloredIcon = navigation.FindViewById<BottomNavigationItemView>(Resource.Id.menu_heli);
            coloredIcon.SetIconTintList(ColorStateList.ValueOf(Color.ParseColor("#FFB300")));
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
    }
}