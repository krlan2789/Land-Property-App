using Land_Property_App.Resources.Strings;
using System.Numerics;

namespace Land_Property_App.Models
{
    public class Property
    {
        public required string Title { get; set; }
        //public required bool AvailableBuy { get; set; }
        public required bool AvailableRent { get; set; }
        public required PropertyType BuildingType { get; set; }
        public required AdvertisementType AdsType { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required float BuildingArea { get; set; }
        public required Vector2 LandArea { get; set; }

        public long Price { get; set; }
        public int Bedroom { get; set; }
        public int Bathroom { get; set; }
        public int Floor { get; set; }
        
        public string? Description { get; set; }
        public List<string>? Images { get; set; }

        public string BuildingTypeLabel => BuildingType switch
        {
            PropertyType.HOUSE => AppResources.TypeHouseLabel,
            PropertyType.APARTMENT => AppResources.TypeApartmentLabel,
            PropertyType.COMMERCIAL_BUILDING => AppResources.TypeCommercialBuildingLabel,
            PropertyType.OFFICE => AppResources.TypeOfficeLabel,
            _ => AppResources.TypeHouseLabel,
        };
        public string AdsTypeLabel => AdsType switch
        {
            AdvertisementType.SALE => AppResources.TagSaleLabel,
            AdvertisementType.SALE_CREDIT => AppResources.TagSaleCreditLabel,
            AdvertisementType.RENT => AppResources.TagRentLabel,
            _ => AppResources.TagSaleLabel,
        };
        public string WhatsAppLink => $"https://api.whatsapp.com/send?phone={PhoneNumber}";
        public string DefaultImage => Images?.Count > 0 ? Images[0] : "";
        public IList<PropertySpecItem> PropertySpecs
        {
            get
            {
                IList<PropertySpecItem> specs = [];

                if (Bedroom > 0) specs.Add(new PropertySpecItem()
                {
                    Name = AppResources.PropertySpecBedroomLabel,
                    Value = "" + Bedroom,
                });

                if (Bathroom > 0) specs.Add(new PropertySpecItem()
                {
                    Name = AppResources.PropertySpecBathroomLabel,
                    Value = "" + Bathroom,
                });

                if (LandArea != Vector2.Zero) specs.Add(new PropertySpecItem()
                {
                    Name = AppResources.PropertySpecLandAreaLabel,
                    Value = $"{LandArea.LengthSquared()} m²",
                });

                if (BuildingArea > 0) specs.Add(new PropertySpecItem()
                {
                    Name = AppResources.PropertySpecBuildingAreaLabel,
                    Value = $"{BuildingArea} m²",
                });

                specs.Add(new PropertySpecItem()
                {
                    Name = AppResources.PropertySpecPropertyTypeLabel,
                    Value = BuildingTypeLabel,
                });

                return specs;
            }
        }
    }
}
