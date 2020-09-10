using Android.App;
using Android.Content;
using System.Collections.Generic;

namespace AndroidWTInsider.DataArrays
{
    public class ShipsTaskArray
    {
        public static List<string> ShipTasks()
        {
            Context context = Application.Context;

            List<string> shipTasks = new List<string>
            {
                context.Resources.GetString(Resource.String.taskCountOfShips),
                context.Resources.GetString(Resource.String.taskMaxRepairCost),
                context.Resources.GetString(Resource.String.taskMcSize),
                context.Resources.GetString(Resource.String.taskMCReload),
                context.Resources.GetString(Resource.String.taskTorpedoCount),
                context.Resources.GetString(Resource.String.taskTorpedoSpeed),
                context.Resources.GetString(Resource.String.taskTorpedoTNT),
                context.Resources.GetString(Resource.String.taskMaxSpeed),
                context.Resources.GetString(Resource.String.taskBracking),          
                context.Resources.GetString(Resource.String.taskTurn360ship),
                context.Resources.GetString(Resource.String.taskTowerArmorShip),
                context.Resources.GetString(Resource.String.taskHullArmor),
                context.Resources.GetString(Resource.String.taskCrewCount),
                context.Resources.GetString(Resource.String.taskDisplacement),
                context.Resources.GetString(Resource.String.taskLaunchedYear),
            };
            return shipTasks;
        }
    }
}