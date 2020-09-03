using AndroidWTInsider.Models;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AndroidWTInsider.XmlHandler
{
    [XmlRoot(ElementName = "ArrayOfTanks", Namespace = "http://schemas.datacontract.org/2004/07/VehicleDataAccess")]
    public class ArrayOfTanks
    {
        [XmlElement(ElementName = "Tanks", Namespace = "http://schemas.datacontract.org/2004/07/VehicleDataAccess")]
        public List<Tank> TanksListApi { get; set; }
    }
}