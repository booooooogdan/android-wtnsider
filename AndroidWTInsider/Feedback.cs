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
        Button buttonSend, buttonReddit, buttonVK, buttonPatreon;
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
            context = Application.Context;
            #endregion

            BottomMenuInitialize();
            BindingInterfaceElementsToCode();

            buttonSend.Click += ButtonSend_Click;
            buttonReddit.Click += ButtonReddit_Click;
            buttonVK.Click += ButtonVK_Click;
            ratingBar.RatingBarChange += RatingBar_RatingBarChange;
            buttonRefWT.Click += ButtonRefWT_Click;
            buttonRefWoT.Click += ButtonRefWoT_Click;
            buttonRefVersus.Click += ButtonRefVersus_Click;
            buttonPatreon.Click += ButtonPatreon_Click;
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
                .Parse("https://play.google.com/store/apps/details?id=com.wtwave.wtinsider")));
        }

        private void ButtonPatreon_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(Intent.ActionView, Android.Net.Uri
    .Parse("https://www.patreon.com/wtversus")));

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
        /// Highlight selected menu item
        /// </summary>
        private void BottomMenuInitialize()
        {
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
            var coloredIcon = navigation.FindViewById<BottomNavigationItemView>(Resource.Id.menu_feedback);
            coloredIcon.SetIconTintList(ColorStateList.ValueOf(Color.ParseColor("#8E24AA")));
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
            buttonPatreon = FindViewById<Button>(Resource.Id.buttonPatreon);
        }
    }
}