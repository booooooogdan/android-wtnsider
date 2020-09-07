using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;
using AndroidWTInsider.XmlHandler;
using AndroidWTInsider.DataArrays;

namespace AndroidWTInsider.Helpers
{
    class ChartsTankDataGenerator : IDataGenerator
    {
        ArrayOfTanks arrayOfTanks;

        public ChartsTankDataGenerator()
        {
            Task.Run(FillListFromCacheAsync).Wait();
        }

        public async Task FillListFromCacheAsync()
        {
            arrayOfTanks = await BlobCache.UserAccount.GetObject<ArrayOfTanks>("cachedArrayOfTanks");
        }

        public List<DataPoint> GetLineDataPoint(string nation, string task)
        {
            var tanksAll = arrayOfTanks.TanksListApi.Where(x => x.Nation == nation).ToList();
            var datas = new List<DataPoint>();

            switch (task)
            {
                case "count":
                    foreach (double number in BRArray.TanksBR())
                    {
                        var tanksCount = tanksAll.Where(x => x.BR == number).Count();
                        datas.Add(new DataPoint(number, tanksCount));
                    }
                    break;

                case "repaircost":
                    foreach (double number in BRArray.TanksBR())
                    {
                        var tanksCount = tanksAll.Where(x => x.BR == number).Max(x => x.RepairCost);
                        datas.Add(new DataPoint(number, tanksCount));
                    }
                    break;

                case "maxspeed":
                    foreach (double number in BRArray.TanksBR())
                    {
                        var tanksCount = tanksAll.Where(x => x.BR == number).Max(x => x.MaxSpeedAtTerrain);
                        datas.Add(new DataPoint(number, tanksCount));
                    }
                    break;

                case "maxspeedatroad":
                    foreach (double number in BRArray.TanksBR())
                    {
                        var tanksCount = tanksAll.Where(x => x.BR == number).Max(x => x.MaxSpeedAtRoad);
                        datas.Add(new DataPoint(number, tanksCount));
                    }
                    break;

                case "maxspeedreverse":
                    foreach (double number in BRArray.TanksBR())
                    {
                        var tanksCount = tanksAll.Where(x => x.BR == number).Max(x => x.MaxReverseSpeed);
                        datas.Add(new DataPoint(number, tanksCount));
                    }
                    break;
                case "enginepower":
                    foreach (double number in BRArray.TanksBR())
                    {
                        var tanksCount = tanksAll.Where(x => x.BR == number).Max(x => x.EnginePower);
                        datas.Add(new DataPoint(number, tanksCount));
                    }
                    break;

                case "weight":
                    foreach (double number in BRArray.TanksBR())
                    {
                        var tanksCount = tanksAll.Where(x => x.BR == number).Min(x => x.Weight);
                        datas.Add(new DataPoint(number, tanksCount));
                    }
                    break;

                case "penetration":
                    foreach (double number in BRArray.TanksBR())
                    {
                        var tanksCount = tanksAll.Where(x => x.BR == number).Max(x => x.Penetration);
                        datas.Add(new DataPoint(number, tanksCount));
                    }
                    break;

                case "reload":
                    foreach (double number in BRArray.TanksBR())
                    {
                        var tanksCount = tanksAll.Where(x => x.BR == number).Min(x => x.ReloadTime);
                        datas.Add(new DataPoint(number, tanksCount));
                    }
                    break;

                case "turretarmor":
                    foreach (double number in BRArray.TanksBR())
                    {
                        var tanksCount = tanksAll.Where(x => x.BR == number).Max(x => x.ReducedArmorFrontTurret);
                        datas.Add(new DataPoint(number, tanksCount));
                    }
                    break;

                case "toparmor":
                    foreach (double number in BRArray.TanksBR())
                    {
                        var tanksCount = tanksAll.Where(x => x.BR == number).Max(x => x.ReducedArmorTopSheet);
                        datas.Add(new DataPoint(number, tanksCount));
                    }
                    break;           
                
                case "bottomarmor":
                    foreach (double number in BRArray.TanksBR())
                    {
                        var tanksCount = tanksAll.Where(x => x.BR == number).Max(x => x.ReducedArmorBottomSheet);
                        datas.Add(new DataPoint(number, tanksCount));
                    }
                    break;

                case "firstrideyear":
                    foreach (double number in BRArray.TanksBR())
                    {
                        var tanksCount = tanksAll.Where(x => x.BR == number).Max(x => x.FirstRideYear);
                        datas.Add(new DataPoint(number, tanksCount));
                    }
                    break;
            }
            return datas;
        }
    }
}