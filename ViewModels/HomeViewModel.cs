using Land_Property_App.Models;
using Land_Property_App.Resources.Strings;
using Land_Property_App.Views;
using System.Windows.Input;

namespace Land_Property_App.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public List<string> Tags => [
            AppResources.TagNewLabel,
            AppResources.TagSaleLabel,
            AppResources.TagRentLabel,
            AppResources.TagSaleCreditLabel,
        ];

        public List<Property> Properties => PropertyRepo.AllPropreties;

        public Property? SelectedProperty { get; set; }

        public ICommand OnPropertySelect => new Command(obj =>
        {
            if (SelectedProperty != null)
            {
                Application.Current?.MainPage?.Navigation.PushAsync(new DetailsPage(SelectedProperty));
            }

            SelectedProperty = null;
        });
    }
}
