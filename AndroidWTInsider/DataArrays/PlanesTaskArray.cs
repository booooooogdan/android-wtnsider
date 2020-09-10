using Android.App;
using Android.Content;
using System.Collections.Generic;

namespace AndroidWTInsider.DataArrays
{
    public class PlanesTaskArray
    {
        public static List<string> PlaneTask()
        {
            Context context = Application.Context;

            List<string> planeTasks = new List<string>
            {
                context.Resources.GetString(Resource.String.taskCountOfPlanes),
                context.Resources.GetString(Resource.String.taskMaxRepairCost),
                context.Resources.GetString(Resource.String.taskMaxSpeedAtSeaLevel),
                context.Resources.GetString(Resource.String.taskMaxSpeedAt5000m),
                context.Resources.GetString(Resource.String.taskClimb),
                context.Resources.GetString(Resource.String.taskTurnTime),
                context.Resources.GetString(Resource.String.taskEnginePower),
                context.Resources.GetString(Resource.String.taskWeight),
                context.Resources.GetString(Resource.String.taskFlutter),
                context.Resources.GetString(Resource.String.taskOptimalAltitude),
                context.Resources.GetString(Resource.String.taskPayload),
                context.Resources.GetString(Resource.String.taskBurstTime),
                context.Resources.GetString(Resource.String.taskFirstFly)
            };
            return planeTasks;
        }
    }
}