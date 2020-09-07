using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;
using AndroidWTInsider.XmlHandler;
using AndroidWTInsider.DataArrays;

namespace AndroidWTInsider.Helpers
{
    class ChartsShipDataGenerator : IDataGenerator
    {
        ArrayOfShips arrayOfShips;

        public ChartsShipDataGenerator()
        {
            Task.Run(FillListFromCacheAsync).Wait();
        }

        public async Task FillListFromCacheAsync()
        {
            arrayOfShips = await BlobCache.UserAccount.GetObject<ArrayOfShips>("cachedArrayOfShips");
        }

        public List<DataPoint> GetLineDataPoint(string nation, string task)
        {
            var shipsAll = arrayOfShips.ShipsListApi.Where(x => x.Nation == nation).ToList();
            var datas = new List<DataPoint>();

            switch (task)
            {
                case "count":
                    foreach (double number in BRArray.ShipsBR())
                    {
                        var shipsCount = shipsAll.Where(x => x.BR == number).Count();
                        datas.Add(new DataPoint(number, shipsCount));
                    }
                    break;

                case "repaircost":
                    foreach (double number in BRArray.ShipsBR())
                    {
                        var shipsCount = shipsAll.Where(x => x.BR == number).Max(x => x.RepairCost);
                        datas.Add(new DataPoint(number, shipsCount));
                    }
                    break;

                case "mc":
                    foreach (double number in BRArray.ShipsBR())
                    {
                        var shipsCount = shipsAll.Where(x => x.BR == number).Min(x => x.MainCaliberSize);
                        datas.Add(new DataPoint(number, shipsCount));
                    }
                    break;

                case "mcreload":
                    foreach (double number in BRArray.ShipsBR())
                    {
                        var shipsCount = shipsAll.Where(x => x.BR == number).Max(x => x.MainCaliberReload);
                        datas.Add(new DataPoint(number, shipsCount));
                    }
                    break;

                case "torpedoitem":
                    foreach (double number in BRArray.ShipsBR())
                    {
                        var shipsCount = shipsAll.Where(x => x.BR == number).Max(x => x.TorpedoItem);
                        datas.Add(new DataPoint(number, shipsCount));
                    }
                    break;

                case "torpedomaxspeed":
                    foreach (double number in BRArray.ShipsBR())
                    {
                        var shipsCount = shipsAll.Where(x => x.BR == number).Max(x => x.TorpedoMaxSpeed);
                        datas.Add(new DataPoint(number, shipsCount));
                    }
                    break;

                case "torpedotnt":
                    foreach (double number in BRArray.ShipsBR())
                    {
                        var shipsCount = shipsAll.Where(x => x.BR == number).Max(x => x.TorpedoTNT);
                        datas.Add(new DataPoint(number, shipsCount));
                    }
                    break;

                case "maxspeed":
                    foreach (double number in BRArray.ShipsBR())
                    {
                        var shipsCount = shipsAll.Where(x => x.BR == number).Max(x => x.MaxSpeed);
                        datas.Add(new DataPoint(number, shipsCount));
                    }
                    break;

                case "brakingtime":
                    foreach (double number in BRArray.ShipsBR())
                    {
                        var shipsCount = shipsAll.Where(x => x.BR == number).Max(x => x.BrakingTime);
                        datas.Add(new DataPoint(number, shipsCount));
                    }
                    break;

                case "turn360":
                    foreach (double number in BRArray.ShipsBR())
                    {
                        var shipsCount = shipsAll.Where(x => x.BR == number).Max(x => x.Turn360);
                        datas.Add(new DataPoint(number, shipsCount));
                    }
                    break;
                   

                case "armortower":
                    foreach (double number in BRArray.ShipsBR())
                    {
                        var shipsCount = shipsAll.Where(x => x.BR == number).Min(x => x.ArmorTower);
                        datas.Add(new DataPoint(number, shipsCount));
                    }
                    break;

                case "armorhull":
                    foreach (double number in BRArray.ShipsBR())
                    {
                        var shipsCount = shipsAll.Where(x => x.BR == number).Max(x => x.ArmorHull);
                        datas.Add(new DataPoint(number, shipsCount));
                    }
                    break;

                case "crewcount":
                    foreach (double number in BRArray.ShipsBR())
                    {
                        var shipsCount = shipsAll.Where(x => x.BR == number).Max(x => x.CrewCount);
                        datas.Add(new DataPoint(number, shipsCount));
                    }
                    break;

                case "displacemet":
                    foreach (double number in BRArray.ShipsBR())
                    {
                        var shipsCount = shipsAll.Where(x => x.BR == number).Min(x => x.Displacement);
                        datas.Add(new DataPoint(number, shipsCount));
                    }
                    break;

                case "firstlaunchyear":
                    foreach (double number in BRArray.ShipsBR())
                    {
                        var shipsCount = shipsAll.Where(x => x.BR == number).Max(x => x.FirstLaunchYear);
                        datas.Add(new DataPoint(number, shipsCount));
                    }
                    break;
            }
            return datas;
        }
    }
}