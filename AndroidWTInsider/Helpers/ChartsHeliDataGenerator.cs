using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;
using AndroidWTInsider.XmlHandler;
using AndroidWTInsider.DataArrays;

namespace AndroidWTInsider.Helpers
{
    class ChartsHeliDataGenerator: IDataGenerator
    {
        ArrayOfHelis arrayOfHelis;

        public ChartsHeliDataGenerator()
        {
            Task.Run(FillListFromCacheAsync).Wait();
        }

        public async Task FillListFromCacheAsync()
        {
            arrayOfHelis = await BlobCache.UserAccount.GetObject<ArrayOfHelis>("cachedArrayOfHelis");
        }

        public List<DataPoint> GetLineDataPoint(string nation, string task)
        {
            var helisAll = arrayOfHelis.HelisListApi.Where(x => x.Nation == nation).ToList();
            var datas = new List<DataPoint>();

            switch (task)
            {
                case "count":
                    foreach (double number in BRArray.HelisBR())
                    {
                        var helisCount = helisAll.Where(x => x.BR == number).Count();
                        datas.Add(new DataPoint(number, helisCount));
                    }
                    break;

                case "repaircost":
                    foreach (double number in BRArray.HelisBR())
                    {
                        var helisCount = helisAll.Where(x => x.BR == number).Max(x => x.RepairCost);
                        datas.Add(new DataPoint(number, helisCount));
                    }
                    break;

                case "maxspeed":
                    foreach (double number in BRArray.HelisBR())
                    {
                        var helisCount = helisAll.Where(x => x.BR == number).Max(x => x.MaxSpeed);
                        datas.Add(new DataPoint(number, helisCount));
                    }
                    break;

                case "climbto1000":
                    foreach (double number in BRArray.HelisBR())
                    {
                        var helisCount = helisAll.Where(x => x.BR == number).Min(x => x.ClimbTo1000);
                        datas.Add(new DataPoint(number, helisCount));
                    }
                    break;

                case "weight":
                    foreach (double number in BRArray.HelisBR())
                    {
                        var helisCount = helisAll.Where(x => x.BR == number).Max(x => x.Weight);
                        datas.Add(new DataPoint(number, helisCount));
                    }
                    break;

                case "agmcount":
                    foreach (double number in BRArray.HelisBR())
                    {
                        var helisCount = helisAll.Where(x => x.BR == number).Max(x => x.AGMCount);
                        datas.Add(new DataPoint(number, helisCount));
                    }
                    break;

                case "agmrange":
                    foreach (double number in BRArray.HelisBR())
                    {
                        var helisCount = helisAll.Where(x => x.BR == number).Max(x => x.AGMRange);
                        datas.Add(new DataPoint(number, helisCount));
                    }
                    break;

                case "asmcount":
                    foreach (double number in BRArray.HelisBR())
                    {
                        var helisCount = helisAll.Where(x => x.BR == number).Max(x => x.ASMCount);
                        datas.Add(new DataPoint(number, helisCount));
                    }
                    break;

                case "firstflyyear":
                    foreach (double number in BRArray.HelisBR())
                    {
                        var helisCount = helisAll.Where(x => x.BR == number).Max(x => x.FirstFlyYear);
                        datas.Add(new DataPoint(number, helisCount));
                    }
                    break;

            }
            return datas;
        }
    }
}