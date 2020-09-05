using System.Collections.Generic;
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;
using Android.App;
using Android.Content;
using AndroidWTInsider.XmlHandler;
using AndroidWTInsider.DataArrays;

namespace AndroidWTInsider.Helpers
{
    class ChartsDataPoints
    {
        Context context;
        ArrayOfTanks arrayOfTanks;

        public ChartsDataPoints()
        {
            context = Application.Context;
            Task.Run(FillListFromCacheAsync).Wait();
        }

        private async Task FillListFromCacheAsync()
        {
            arrayOfTanks = await BlobCache.UserAccount.GetObject<ArrayOfTanks>("cachedArrayOfTanks");
        }

        public List<DataPoint> GetLineDataPoint(string nation)
        {
            var tanksAll = arrayOfTanks.TanksListApi.Where(x => x.Nation == nation).ToList();
            var datas = new List<DataPoint>();
            foreach (double number in BRArray.TanksBR())
            {
                var tanksCount = tanksAll.Where(x => x.BR == number).Count();
                datas.Add(new DataPoint(number, tanksCount));
            }
            return datas;
        }
    }
}