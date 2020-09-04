using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System.Reactive.Linq;
using Akavache;
using Plugin.Connectivity;
using Android.Views;
using Android.Content.PM;
using System;
using AndroidWTInsider.XmlHandler;
using Com.Syncfusion.Sfbusyindicator;
using Android.Graphics;

namespace AndroidWTInsider
{
    [Activity(Label = "WT Insider", Theme = "@style/AppTheme", MainLauncher = true, ScreenOrientation=ScreenOrientation.Landscape)]
    public class Startup:AppCompatActivity
    {
        #region Variables

        Context context;
        ArrayOfPlanes arrayOfPlanes;
        ArrayOfTanks arrayOfTanks;
        ArrayOfHelis arrayOfHelis;
        ArrayOfShips arrayOfShips;
        TextView debugTextView;
        #endregion

        /// <summary>
        /// Base Android OnCreate method. Entry point for app
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.StartupLayout);
            context = Application.Context;
            Syncfusion.Licensing.SyncfusionLicenseProvider
               .RegisterLicense("MzExNTgyQDMxMzgyZTMyMmUzMENBYUR1b2xmRHhjZ2tKblVPWlI5Vm9rYTRSSDlwRDhvalQrbUMzaGhqZXM9");

            debugTextView = FindViewById<TextView>(Resource.Id.textViewdebug); //show debug info

            CheckInternetConnection();
        }

        /// <summary>
        /// Check if internet on
        /// </summary>
        private void CheckInternetConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                debugTextView.SetText("no internet", TextView.BufferType.Normal);
                AlertDialogWhenNoInternet();
            }
            else
            {
                Task.Run(() => CheckIfDBCached().Wait());
            }
        }

        /// <summary>
        /// Alert dialog initializer. Shows when no internet
        /// </summary>
        private void AlertDialogWhenNoInternet()
        {
            string title = context.Resources.GetString(Resource.String.alertDialogConnectTitle);
            string message = context.Resources.GetString(Resource.String.alertDialogConnectMessage);
            string retry = context.Resources.GetString(Resource.String.alertDialogConnectRetry);

            Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);
            alert.SetTitle(title);
            alert.SetMessage(message);
            alert.SetCancelable(false);
            alert.SetPositiveButton(retry, (senderAlert, args) =>
            {
                CheckInternetConnection();
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }

        /// <summary>
        /// Check if cache have saved data. If have, then start to default main activity
        /// </summary>
        /// <returns>Task</returns>
        private async Task CheckIfDBCached()
        {
            try
            {
                RunOnUiThread(() => {
                    debugTextView.SetText("check cache", TextView.BufferType.Normal);
                });
                Registrations.Start("WTIAkavacheCache");
                var arrayOfPlanesCached = await BlobCache.UserAccount.GetObject<ArrayOfPlanes>("cachedArrayOfPlanes");
                var arrayOfTanksCached = await BlobCache.UserAccount.GetObject<ArrayOfPlanes>("cachedArrayOfTanks");
                var arrayOfHelisCached = await BlobCache.UserAccount.GetObject<ArrayOfPlanes>("cachedArrayOfHelis");
                var arrayOfShipsCached = await BlobCache.UserAccount.GetObject<ArrayOfPlanes>("cachedArrayOfShips");

                MoveToNextActivity();
            }
            catch (KeyNotFoundException ex)
            {
                RunOnUiThread(() => {
                    debugTextView.SetText("cache failed", TextView.BufferType.Normal);
                    AlertDialogWhenDataLoading();
                });
                await Task.Run(() => GetPlanesListFromApiAsync());
                await Task.Run(() => GetTanksListFromApiAsync());
                await Task.Run(() => GetHelisListFromApiAsync());
                await Task.Run(() => GetShipsListFromApiAsync());
                Task.WaitAll();
                MoveToNextActivity();

            }
        }

        /// <summary>
        /// Connect to API, load planes and add to cache
        /// </summary>
        /// <returns>Task</returns>
        private async Task GetPlanesListFromApiAsync()
        {
            RunOnUiThread(() => {
                debugTextView.SetText("loading planes", TextView.BufferType.Normal);
            });
            string URL = context.Resources.GetString(Resource.String.apiPlanesUrl);
            ApiXmlReaderInitial initial = new ApiXmlReaderInitial();
            XmlReader xReader = initial.ApiXmlReader(URL);
            XmlSerializer serializer = new XmlSerializer(typeof(ArrayOfPlanes));
            arrayOfPlanes = (ArrayOfPlanes)serializer.Deserialize(xReader);

            await BlobCache.UserAccount.InsertObject("cachedArrayOfPlanes", arrayOfPlanes, TimeSpan.FromDays(7));
        }

        /// <summary>
        /// Connect to API, load tanks and add to cache
        /// </summary>
        /// <returns>Task</returns>
        private async Task GetTanksListFromApiAsync()
        {
            RunOnUiThread(() => {
                debugTextView.SetText("loading tanks", TextView.BufferType.Normal);
            });
            string URL = context.Resources.GetString(Resource.String.apiTanksUrl);
            ApiXmlReaderInitial initial = new ApiXmlReaderInitial();
            XmlReader xReader = initial.ApiXmlReader(URL);
            XmlSerializer serializer = new XmlSerializer(typeof(ArrayOfTanks));
            arrayOfTanks = (ArrayOfTanks)serializer.Deserialize(xReader);

            await BlobCache.UserAccount.InsertObject("cachedArrayOfTanks", arrayOfTanks, TimeSpan.FromDays(7));
        }

        /// <summary>
        /// Connect to API, load helis and add to cache
        /// </summary>
        /// <returns>Task</returns>
        private async Task GetHelisListFromApiAsync()
        {
            RunOnUiThread(() => {
                debugTextView.SetText("loading helis", TextView.BufferType.Normal);
            });
            string URL = context.Resources.GetString(Resource.String.apiHelisUrl);
            ApiXmlReaderInitial initial = new ApiXmlReaderInitial();
            XmlReader xReader = initial.ApiXmlReader(URL);
            XmlSerializer serializer = new XmlSerializer(typeof(ArrayOfHelis));
            arrayOfHelis = (ArrayOfHelis)serializer.Deserialize(xReader);

            await BlobCache.UserAccount.InsertObject("cachedArrayOfHelis", arrayOfHelis, TimeSpan.FromDays(7));
        }

        /// <summary>
        /// Connect to API, load ships and add to cache
        /// </summary>
        /// <returns>Task</returns>
        private async Task GetShipsListFromApiAsync()
        {
            RunOnUiThread(() => {
                debugTextView.SetText("loading your mom", TextView.BufferType.Normal);
            });
            string URL = context.Resources.GetString(Resource.String.apiShipsUrl);
            ApiXmlReaderInitial initial = new ApiXmlReaderInitial();
            XmlReader xReader = initial.ApiXmlReader(URL);
            XmlSerializer serializer = new XmlSerializer(typeof(ArrayOfShips));
            arrayOfShips = (ArrayOfShips)serializer.Deserialize(xReader);

            await BlobCache.UserAccount.InsertObject("cachedArrayOfShips", arrayOfShips, TimeSpan.FromDays(7));
        }

        /// <summary>
        /// Alert dialog initializer. Shows during app load data from API
        /// </summary>
        private void AlertDialogWhenDataLoading()
        {
            string title = context.Resources.GetString(Resource.String.alertDialogLoadingTitle);

            LayoutInflater layoutInflater = LayoutInflater.From(this);
            View mview = layoutInflater.Inflate(Resource.Layout._alertDialogLoading, null);
            Android.App.AlertDialog.Builder alertDialogBuilder = new Android.App.AlertDialog.Builder(this);
            alertDialogBuilder.SetView(mview);
            Android.App.AlertDialog alertDialogAndroid = alertDialogBuilder.Create();
            alertDialogAndroid.SetCancelable(false);

            SfBusyIndicator busyIndicator = mview.FindViewById<SfBusyIndicator>(Resource.Id.sfBusyIndicator);
            busyIndicator.AnimationType = Com.Syncfusion.Sfbusyindicator.Enums.AnimationTypes.DoubleCircle;
            busyIndicator.Title = title;
            busyIndicator.TextColor = Color.DarkGray;
            busyIndicator.ViewBoxHeight = 60;
            busyIndicator.ViewBoxWidth = 60;
            busyIndicator.IsBusy = true;

            alertDialogAndroid.Show();           
        }

        /// <summary>
        /// Open default activity when all data loaded. Remove animation between activity 
        /// </summary>
        private void MoveToNextActivity()
        {
            var intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.NoAnimation);
            StartActivity(intent);
            Finish();
        }
    }
}