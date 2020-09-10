using Android.App;
using Android.Content;
using System.Collections.Generic;

namespace AndroidWTInsider.DataArrays
{
    public static class TanksTaskArray
    {
        /// <summary>
        /// Static localized list of tanks taskk
        /// </summary>
        /// <returns>List of tanks task</returns>
        public static List<string> TankTasks()
        {
            Context context = Application.Context;

            List<string> tankTasks = new List<string>
            {
                context.Resources.GetString(Resource.String.taskCountOfTanks),
                context.Resources.GetString(Resource.String.taskMaxRepairCost),
                context.Resources.GetString(Resource.String.taskMaxSpeedTerrain),
                context.Resources.GetString(Resource.String.taskMaxSpeedRoad),
                context.Resources.GetString(Resource.String.taskReverse),
                context.Resources.GetString(Resource.String.taskEnginePower),
                context.Resources.GetString(Resource.String.taskWeight),
                context.Resources.GetString(Resource.String.taskPenetration),
                context.Resources.GetString(Resource.String.taskMinReload),
                context.Resources.GetString(Resource.String.taskTurretArmor),
                context.Resources.GetString(Resource.String.taskUpperArmor),
                context.Resources.GetString(Resource.String.taskLowerArmor),
                context.Resources.GetString(Resource.String.taskFirstRide)
            };
            return tankTasks;
        }
    }
}
