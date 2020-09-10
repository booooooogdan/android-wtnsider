using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndroidWTInsider.Helpers
{
    interface IDataGenerator
    {
        Task FillListFromCacheAsync();

        List<DataPoint> GetLineDataPoint(string nation, string task);
    }
}