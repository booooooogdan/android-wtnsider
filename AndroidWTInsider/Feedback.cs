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
using Android.Webkit;
using Android.Widget;
using System;

namespace AndroidWTInsider
{
    [Activity(ScreenOrientation = ScreenOrientation.Landscape)]
    public class Feedback : BottomNavigation, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        Context context;
        EditText editMessage;
        Button buttonSend, buttonReddit, buttonVK;
        ImageButton buttonRefWT, buttonRefWoT, buttonRefVersus;
        RatingBar ratingBar;

        /// <summary>
        /// Base Android OnCreate method. Entry point for app
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            #region Initialization required elements
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Feedback);
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
            var coloredIcon = navigation.FindViewById<BottomNavigationItemView>(Resource.Id.menu_feedback);
            coloredIcon.SetIconTintList(ColorStateList.ValueOf(Color.ParseColor("#8E24AA")));
            context = Application.Context;
            #endregion

            #region Ads initializer
            //MobileAds.Initialize(context);
            //var adView = FindViewById<AdView>(Resource.Id.adViewFeedback);
            //adView.LoadAd(new AdRequest.Builder().Build());
            //var requestbuilder = new AdRequest.Builder().AddTestDevice("46CCAB8BBCE5B5FFA79C22BEB98029AC");
            //adView.LoadAd(requestbuilder.Build());
            #endregion

            BindingInterfaceElementsToCode();
            buttonSend.Click += ButtonSend_Click;
            buttonReddit.Click += ButtonReddit_Click;
            buttonVK.Click += ButtonVK_Click;
            ratingBar.RatingBarChange += RatingBar_RatingBarChange;
            buttonRefWT.Click += ButtonRefWT_Click;
            buttonRefWoT.Click += ButtonRefWoT_Click;
            buttonRefVersus.Click += ButtonRefVersus_Click; ;
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            Intent email = new Intent(Intent.ActionSend);
            email.PutExtra(Intent.ExtraEmail, new string[] { "waveappfeedback@gmail.com" });
            email.PutExtra(Intent.ExtraSubject, "From Android Insider");
            email.PutExtra(Intent.ExtraText, editMessage.Text.ToString());
            email.SetType("message/rfc822");
            StartActivity(Intent.CreateChooser(email, context.Resources.GetString(Resource.String.chooseEmailClient)));
        }

        private void ButtonVK_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(Intent.ActionView, Android.Net.Uri
                .Parse("https://www.vk.com/waveapp/")));
        }

        private void ButtonReddit_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(Intent.ActionView, Android.Net.Uri
                 .Parse("https://www.reddit.com/r/wave_app/")));
        }

        private void RatingBar_RatingBarChange(object sender, RatingBar.RatingBarChangeEventArgs e)
        {
            StartActivity(new Intent(Intent.ActionView, Android.Net.Uri
                .Parse("https://play.google.com/store/apps/details?id=com.wave.wtinsider")));
        }

        private void ButtonRefWT_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(Intent.ActionView, Android.Net.Uri
              .Parse("https://play.google.com/store/apps/details?id=com.wave.wtquiz")));
        }

        private void ButtonRefWoT_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(Intent.ActionView, Android.Net.Uri
              .Parse("https://play.google.com/store/apps/details?id=com.wave.wotquiz")));
        }

        private void ButtonRefVersus_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(Intent.ActionView, Android.Net.Uri
              .Parse("https://play.google.com/store/apps/details?id=com.wave.wtversus")));
        }

        /// <summary>
        /// Binding view elements to code
        /// </summary>
        private void BindingInterfaceElementsToCode()
        {
            editMessage = FindViewById<EditText>(Resource.Id.editMessage);
            buttonSend = FindViewById<Button>(Resource.Id.buttonSend);
            buttonReddit = FindViewById<Button>(Resource.Id.buttonReddit);
            buttonVK = FindViewById<Button>(Resource.Id.buttonVK);
            ratingBar = FindViewById<RatingBar>(Resource.Id.ratingBar);
            buttonRefWT = FindViewById<ImageButton>(Resource.Id.buttonRefWT);
            buttonRefWoT = FindViewById<ImageButton>(Resource.Id.buttonRefWoT);
            buttonRefVersus = FindViewById<ImageButton>(Resource.Id.buttonRefVersus);
        }
    }
}