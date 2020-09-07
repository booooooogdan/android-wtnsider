using System;

namespace AndroidWTInsider.DataArrays
{
    public class PlanesTaskArray
    {
        public static string[] PlaneTasks() => new string[] { "Count of planes", "Max repair cost"
            , "Max speed at sea level", "Max speed at 5000 m", "Min climb time to 5000 m"
            , "Min turn time", "Max engine power", "Min take-off weight"
            , "Max speed of destruction", "Max optimal altitude","Max bomb payload"
            , "Max burst maxx", "First fly year" };
    }
}