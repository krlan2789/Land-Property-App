using Land_Property_App.Resources.Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Land_Property_App.Models
{
    public class Property
    {
        //public required bool AvailableBuy { get; set; }
        public required bool AvailableRent { get; set; }
        public required PropertyType BuildingType { get; set; }
        public string BuildingTypeLabel => BuildingType switch
        {
            PropertyType.House => AppResources.TypeHouseLabel,
            PropertyType.Apartment => AppResources.TypeApartmentLabel,
            PropertyType.ComercialBuilding => AppResources.TypeCommercialBuildingLabel,
            _ => AppResources.TypeHouseLabel,
        };
        public required string DefaultImage { get; set; }
        public required string Address { get; set; }
        public long Price { get; set; }
        public int Bedroom { get; set; }
        public int Bathroom { get; set; }
        public int Floor { get; set; }
        public required float BuildingArea { get; set; }
        public required Vector2 LandArea { get; set; }
        public List<string>? Images { get; set; }
    }
}
