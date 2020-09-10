using Android.App;
using Android.Content;
using System.Collections.Generic;

namespace AndroidWTInsider.DataArrays
{
    public class HelisTaskArray
    {
        /// <summary>
        /// Static localized list of helicopters taskk
        /// </summary>
        /// <returns>List of helicopters task</returns>
        public static List<string> HeliTasks()
        {
            Context context = Application.Context;

            List<string> heliTasks = new List<string>
            {
                context.Resources.GetString(Resource.String.taskCountOfHelis),
                context.Resources.GetString(Resource.String.taskMaxRepairCost),
                context.Resources.GetString(Resource.String.taskMaxSpeedAtSeaLevel),
                context.Resources.GetString(Resource.String.taskClimb1000),
                context.Resources.GetString(Resource.String.taskWeight),
                context.Resources.GetString(Resource.String.taskATGMCount),
                context.Resources.GetString(Resource.String.taskATGMRange),
                context.Resources.GetString(Resource.String.taskASMCount),
                context.Resources.GetString(Resource.String.taskFirstFly),
            };
            return heliTasks;
        }
    }
}