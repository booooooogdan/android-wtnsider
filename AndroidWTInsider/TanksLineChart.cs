using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.Gms.Ads;
using Android.Graphics;
using Android.OS;
using Android.Preferences;
using Android.Support.Design.Internal;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using AndroidWTInsider.DataArrays;
using AndroidWTInsider.Helpers;
using Com.Syncfusion.Charts;
using System;

namespace AndroidWTInsider
{
    [Activity(ScreenOrientation = ScreenOrientation.Landscape)]
    public class TanksLineChart : BottomNavigation, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        SfChart chartView;
        LineChartsInitializer chartsLineInitializer;
        ChartsTankDataGenerator chartsData;
        Spinner spinner;
        Context context;
        Android.App.AlertDialog alertDialogAndroid;

        /// <summary>
        /// Base Android OnCreate method. Entry point for app
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            #region Initialization required elements
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TanksLineChart);
            context = Application.Context;
            #endregion

            chartsLineInitializer = new LineChartsInitializer();
            chartView = FindViewById<SfChart>(Resource.Id.sfChartTank);
            chartsData = new ChartsTankDataGenerator();

            AdsInitialize();
            SpinnerInitialize();
            BottomMenuInitialize();
            RateApp();
        }

        /// <summary>
        /// AdMob banner initialize
        /// </summary>
        private void AdsInitialize()
        {
            MobileAds.Initialize(context);
            var adView = FindViewById<AdView>(Resource.Id.adsTank);
            adView.LoadAd(new AdRequest.Builder().Build());
            //var requestbuilder = new AdRequest.Builder().AddTestDevice("46CCAB8BBCE5B5FFA79C22BEB98029AC");
            //adView.LoadAd(requestbuilder.Build());
        }

        /// <summary>
        /// Set adapter for spinner menu
        /// </summary>
        private void SpinnerInitialize()
        {
            spinner = FindViewById<Spinner>(Resource.Id.spinnerTank);
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, TanksTaskArray.TankTasks());
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
            var coloredIcon = navigation.FindViewById<BottomNavigationItemView>(Resource.Id.menu_tank);
            coloredIcon.SetIconTintList(ColorStateList.ValueOf(Color.ParseColor("#43A047")));
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

        private void RateApp()
        {
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            ISharedPreferencesEditor editor = prefs.Edit();

            var showRateAlert = prefs.GetInt("rateAlert", 1);
            showRateAlert++;
            editor.PutInt("rateAlert", showRateAlert);
            editor.Apply();

            if (showRateAlert == 7 || showRateAlert == 15)
            CallAlert();
        }

        private void CallAlert()
        {
            var layoutInflater = LayoutInflater.From(this);
            var mview = layoutInflater.Inflate(Resource.Layout._alertRateAppDialog, null);
            var alertDialogBuilder = new Android.App.AlertDialog.Builder(this);
            alertDialogBuilder.SetView(mview);
            alertDialogAndroid = alertDialogBuilder.Create();
            alertDialogAndroid.Show();
            alertDialogAndroid.SetCanceledOnTouchOutside(false);
            alertDialogAndroid.SetCancelable(false);
            var rateButtonYes = mview.FindViewById<Button>(Resource.Id.buttonYes);
            var rateButtonNo = mview.FindViewById<Button>(Resource.Id.buttonNo);
            rateButtonNo.Click += (s, e) => alertDialogAndroid.Dismiss();
            rateButtonYes.Click += RateButtonYes_Click;
        }

        private void RateButtonYes_Click(object sender, EventArgs e)
        {
            alertDialogAndroid.Dismiss();
            StartActivity(new Intent(Intent.ActionView, Android.Net.Uri
                .Parse("https://play.google.com/store/apps/details?id=com.wtwave.wtinsider")));
        }

    }
}