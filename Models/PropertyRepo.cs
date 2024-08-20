using Land_Property_App.Database;
using SQLite;
using System.Numerics;

namespace Land_Property_App.Models
{
    public class PropertyRepo : BaseRepo
    {
        public static List<Property> AllPropreties => [
            new Property {
                Title = "Rumah 2 lantai di Kenjeran",
                AvailableRent = false,
                BuildingType = PropertyType.HOUSE,
                AdsType = AdvertisementType.SALE,
                PhoneNumber = "628",
                BuildingArea = 120.0f,
                LandArea = new Vector2(20, 8),
                Floor = 2,
                Address = "Kenjeran, Surabaya",
                Price = 1_250_000_000,
                Images = [
                    "https://cdn.pixabay.com/photo/2017/04/10/22/28/residence-2219972_1280.jpg",
                    "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                    "https://cdn.pixabay.com/photo/2021/06/13/19/22/room-6334131_640.jpg",
                    "https://cdn.pixabay.com/photo/2021/12/05/02/32/interior-design-6846350_640.jpg",
                ],
            },
            new Property {
                Title = "",
                AvailableRent = false,
                BuildingType = PropertyType.HOUSE,
                AdsType = AdvertisementType.SALE,
                PhoneNumber = "628",
                BuildingArea = 150.0f,
                LandArea = new Vector2(15, 9),
                Floor = 3,
                Address = "Cipenjo, Kabupaten Bogor",
                Price = 575_000_000,
                Images = [
                    "https://cdn.pixabay.com/photo/2017/07/08/02/16/house-2483336_1280.jpg",
                    "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                    "https://cdn.pixabay.com/photo/2021/06/13/19/22/room-6334131_640.jpg",
                    "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                    "https://cdn.pixabay.com/photo/2021/06/13/19/22/room-6334131_640.jpg",
                    "https://cdn.pixabay.com/photo/2021/12/05/02/32/interior-design-6846350_640.jpg",
                ],
            },
            new Property {
                Title = "",
                AvailableRent = false,
                BuildingType = PropertyType.HOUSE,
                AdsType = AdvertisementType.SALE,
                PhoneNumber = "628",
                BuildingArea = 100.0f,
                LandArea = new Vector2(14, 10),
                Floor = 1,
                Address = "GKB, Kabupaten Gresik",
                Price = 650_000_000,
                Images = [
                    "https://cdn.pixabay.com/photo/2018/04/30/13/33/house-3362676_1280.jpg",
                    "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                    "https://cdn.pixabay.com/photo/2021/06/13/19/22/room-6334131_640.jpg",
                    "https://cdn.pixabay.com/photo/2021/12/05/02/32/interior-design-6846350_640.jpg",
                    "https://cdn.pixabay.com/photo/2021/06/13/19/22/room-6334131_640.jpg",
                ],
            },
            new Property {
                Title = "",
                AvailableRent = false,
                BuildingType = PropertyType.HOUSE,
                AdsType = AdvertisementType.RENT,
                PhoneNumber = "628",
                BuildingArea = 84.0f,
                LandArea = new Vector2(14, 8),
                Floor = 2,
                Address = "Cibubur, Jakarta Selatan",
                Price = 120_000_000,
                Images = [
                    "https://cdn.pixabay.com/photo/2016/08/05/17/32/new-1572747_1280.jpg",
                    "https://cdn.pixabay.com/photo/2021/12/05/02/32/interior-design-6846350_640.jpg",
                    "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                    "https://cdn.pixabay.com/photo/2021/06/13/19/22/room-6334131_640.jpg",
                    "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                ],
            },
            new Property {
                Title = "",
                AvailableRent = false,
                BuildingType = PropertyType.HOUSE,
                AdsType = AdvertisementType.SALE,
                PhoneNumber = "628",
                BuildingArea = 140.0f,
                LandArea = new Vector2(12, 12),
                Floor = 2,
                Address = "Bintaro, Tanggerang Selatan",
                Price = 850_000_000,
                Images = [
                    "https://cdn.pixabay.com/photo/2016/08/05/17/32/new-1572747_1280.jpg",
                    "https://cdn.pixabay.com/photo/2021/12/05/02/32/interior-design-6846350_640.jpg",
                    "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                    "https://cdn.pixabay.com/photo/2021/06/13/19/22/room-6334131_640.jpg",
                    "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                ],
            },
            new Property {
                Title = "",
                AvailableRent = false,
                BuildingType = PropertyType.HOUSE,
                AdsType = AdvertisementType.SALE,
                PhoneNumber = "628",
                BuildingArea = 88.0f,
                LandArea = new Vector2(20, 8),
                Floor = 1,
                Address = "Waru, Kabupaten Sidoarjo",
                Price = 800_000_000,
                Images = [
                    "https://cdn.pixabay.com/photo/2018/04/30/13/33/house-3362676_1280.jpg",
                    "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                    "https://cdn.pixabay.com/photo/2021/12/05/02/32/interior-design-6846350_640.jpg",
                    "https://cdn.pixabay.com/photo/2021/06/13/19/22/room-6334131_640.jpg",
                ],
            },
            new Property {
                Title = "",
                AvailableRent = false,
                BuildingType = PropertyType.APARTMENT,
                AdsType = AdvertisementType.RENT,
                PhoneNumber = "628",
                BuildingArea = 40.0f,
                LandArea = new Vector2(8, 5),
                Floor = 10,
                Address = "Kebon Jeruk, Jakarta Barat",
                Price = 35_000_000,
                Images = [
                    "https://cdn.pixabay.com/photo/2021/12/05/02/32/interior-design-6846350_640.jpg",
                    "https://cdn.pixabay.com/photo/2021/12/05/02/32/interior-design-6846350_640.jpg",
                    "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                    "https://cdn.pixabay.com/photo/2021/06/13/19/22/room-6334131_640.jpg",
                ],
            },
            new Property {
                Title = "",
                AvailableRent = false,
                BuildingType = PropertyType.APARTMENT,
                AdsType = AdvertisementType.RENT,
                PhoneNumber = "628",
                BuildingArea = 36.0f,
                LandArea = new Vector2(6, 6),
                Floor = 13,
                Address = "Cengkareng, Jakarta Barat",
                Price = 28_000_000,
                Images = [
                    "https://cdn.pixabay.com/photo/2021/06/13/19/22/room-6334131_640.jpg",
                    "https://cdn.pixabay.com/photo/2021/06/13/19/22/room-6334131_640.jpg",
                    "https://cdn.pixabay.com/photo/2021/12/05/02/32/interior-design-6846350_640.jpg",
                    "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                ],
            },
            new Property {
                Title = "",
                AvailableRent = false,
                BuildingType = PropertyType.APARTMENT,
                AdsType = AdvertisementType.RENT,
                PhoneNumber = "628",
                BuildingArea = 56.0f,
                LandArea = new Vector2(7, 8),
                Floor = 18,
                Address = "Tunjungan, Surabaya",
                Price = 96_000_000,
                Images = [
                    "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                    "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                    "https://cdn.pixabay.com/photo/2021/06/13/19/22/room-6334131_640.jpg",
                    "https://cdn.pixabay.com/photo/2021/12/05/02/32/interior-design-6846350_640.jpg",
                ],
            },
        ];

        public string StatusMessage { get; set; }

        public PropertyRepo(string dbPath)
        {
            Init(dbPath);
            StatusMessage = "";
        }
    }
}
