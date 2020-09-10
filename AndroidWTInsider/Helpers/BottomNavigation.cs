using Android.Content;
using Android.Support.Design.Internal;
using Android.Support.V7.App;
using Android.Views;

namespace AndroidWTInsider
{
    public class BottomNavigation:AppCompatActivity
    {
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
                    var intentFeedback = new Intent(this, typeof(Feedback));
                    intentFeedback.AddFlags(ActivityFlags.NoAnimation);
                    StartActivity(intentFeedback);
                    return true;
            }
            return false;
        }
    }
}