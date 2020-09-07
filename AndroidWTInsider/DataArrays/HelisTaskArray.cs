using System;

namespace AndroidWTInsider.DataArrays
{
    public class HelisTaskArray
    {
        public static string[] HeliTasks() => new string[] { "Count of helicopters", "Max repair cost"
            , "Max speed at sea level", "Min climb time to 1000 m", "Min take-off weight"
            , "Max ATGM count" , "Max ATGM range","Max unguided missile count"
            , "First fly year"};
    }
}