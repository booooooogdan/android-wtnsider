using System.Collections.Generic;
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;
using Android.App;
using Android.Content;
using AndroidWTInsider.XmlHandler;

namespace AndroidWTInsider.Helpers
{
    public class ChartsDataPoints
    {
        Context context;
        ArrayOfTanks arrayOfTanks;
        BRArray brArray;
        double[] br;

        public ChartsDataPoints()
        {
            context = Application.Context;
            brArray = new BRArray();
            br = brArray.TanksBR();
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
            foreach (double number in br)
            {
                var tanksCount = tanksAll.Where(x => x.BR == number).Count();
                datas.Add(new DataPoint(number, tanksCount));
            }
            return datas;
        }
    }
}