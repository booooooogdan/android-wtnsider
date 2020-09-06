using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;
using AndroidWTInsider.XmlHandler;
using AndroidWTInsider.DataArrays;

namespace AndroidWTInsider.Helpers
{
    class ChartsPlaneDataGenerator: IDataGenerator
    {
        ArrayOfPlanes arrayOfPlanes;

        public ChartsPlaneDataGenerator()
        {
            Task.Run(FillListFromCacheAsync).Wait();
        }

        public async Task FillListFromCacheAsync()
        {
            arrayOfPlanes = await BlobCache.UserAccount.GetObject<ArrayOfPlanes>("cachedArrayOfPlanes");
        }

        public List<DataPoint> GetLineDataPoint(string nation, string task)
        {
            var planesAll = arrayOfPlanes.PlanesListApi.Where(x => x.Nation == nation).ToList();
            var datas = new List<DataPoint>();

            switch (task)
            {
                case "count":
                    foreach (double number in BRArray.PlanesBR())
                    {
                        var planesCount = planesAll.Where(x => x.BR == number).Count();
                        datas.Add(new DataPoint(number, planesCount));
                    }
                    break;

                case "repaircost":
                    foreach (double number in BRArray.PlanesBR())
                    {
                        var planesCount = planesAll.Where(x => x.BR == number).Max(x => x.RepairCost);
                        datas.Add(new DataPoint(number, planesCount));
                    }
                    break;

                case "maxspeed":
                    foreach (double number in BRArray.PlanesBR())
                    {
                        var planesCount = planesAll.Where(x => x.BR == number).Max(x => x.MaxSpeedAt0);
                        datas.Add(new DataPoint(number, planesCount));
                    }
                    break;

                case "maxspeedat5000m":
                    foreach (double number in BRArray.PlanesBR())
                    {
                        var planesCount = planesAll.Where(x => x.BR == number).Max(x => x.MaxSpeedAt5000);
                        datas.Add(new DataPoint(number, planesCount));
                    }
                    break;

                case "climb":
                    foreach (double number in BRArray.PlanesBR())
                    {
                        var planesCount = planesAll.Where(x => x.BR == number).Min(x => x.Climb);
                        datas.Add(new DataPoint(number, planesCount));
                    }
                    break;

                case "turntime":
                    foreach (double number in BRArray.PlanesBR())
                    {
                        var planesCount = planesAll.Where(x => x.BR == number).Min(x => x.TurnAt0);
                        datas.Add(new DataPoint(number, planesCount));
                    }
                    break;

                case "burstmass":
                    foreach (double number in BRArray.PlanesBR())
                    {
                        var planesCount = planesAll.Where(x => x.BR == number).Max(x => x.BurstMass);
                        datas.Add(new DataPoint(number, planesCount));
                    }
                    break;
            }
            return datas;
        }
    }
}