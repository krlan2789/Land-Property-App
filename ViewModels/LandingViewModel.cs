using Land_Property_App.Models;
using Land_Property_App.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Land_Property_App.ViewModels
{
    public class LandingViewModel : BaseViewModel
    {
        public List<string> Sections => ["Trending", "Popular", "Buy", "Rent"];
        public List<Property> Properties => PropertyRepo.AllPropreties;

        public Property? SelectedProperty { get; set; }

        public ICommand OnPropertySelect => new Command(obj => {
            if (SelectedProperty != null)
            {
                Application.Current?.MainPage?.Navigation.PushAsync(new DetailsPage(SelectedProperty));
            }

            SelectedProperty = null;
        });
    }
}
