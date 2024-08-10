using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Land_Property_App.Models
{
    public class PropertyRepo
    {
        public static List<Property> AllPropreties => [
            new Property {
                Address = "Kenjeran, Surabaya",
                Price = 1_250_000_000,
                DefaultImage = "https://cdn.pixabay.com/photo/2017/04/10/22/28/residence-2219972_1280.jpg",
                Images = [
                    "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                    "https://cdn.pixabay.com/photo/2021/06/13/19/22/room-6334131_640.jpg",
                    "https://cdn.pixabay.com/photo/2021/12/05/02/32/interior-design-6846350_640.jpg",
                ],
            },
            new Property {
                Address = "Cipenjo, Bogor Regency",
                Price = 575_000_000,
                DefaultImage = "https://cdn.pixabay.com/photo/2017/07/08/02/16/house-2483336_1280.jpg",
                Images = [
                    "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                    "https://cdn.pixabay.com/photo/2021/06/13/19/22/room-6334131_640.jpg",
                    "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                    "https://cdn.pixabay.com/photo/2021/06/13/19/22/room-6334131_640.jpg",
                    "https://cdn.pixabay.com/photo/2021/12/05/02/32/interior-design-6846350_640.jpg",
                ],
            },
            new Property {
                Address = "GKB, Gresik Regency",
                Price = 750_000_000,
                DefaultImage = "https://cdn.pixabay.com/photo/2018/04/30/13/33/house-3362676_1280.jpg",
                Images = [
                    "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                    "https://cdn.pixabay.com/photo/2021/06/13/19/22/room-6334131_640.jpg",
                    "https://cdn.pixabay.com/photo/2021/12/05/02/32/interior-design-6846350_640.jpg",
                    "https://cdn.pixabay.com/photo/2021/06/13/19/22/room-6334131_640.jpg",
                ],
            },
            new Property {
                Address = "Cibubur, South Jakarta",
                Price = 1_400_000_000,
                DefaultImage = "https://cdn.pixabay.com/photo/2016/08/05/17/32/new-1572747_1280.jpg",
                Images = [
                    "https://cdn.pixabay.com/photo/2021/12/05/02/32/interior-design-6846350_640.jpg",
                    "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                    "https://cdn.pixabay.com/photo/2021/06/13/19/22/room-6334131_640.jpg",
                    "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                ],
            },
        ];
    }
}
