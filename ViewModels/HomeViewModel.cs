using CommunityToolkit.Maui;
using Land_Property_App.Database;
using Land_Property_App.Models;
using Land_Property_App.Resources.Strings;
using Land_Property_App.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Land_Property_App.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public string? CurrentTag { get; set; }
        public List<string> Tags => [
            AppResources.TagNewLabel,
            AppResources.TagSaleLabel,
            AppResources.TagRentLabel,
            AppResources.TagSaleCreditLabel,
        ];

        public required ObservableCollection<Property> Properties { get; set; }

        public Property? SelectedProperty { get; set; }

        public ICommand OnPropertySelect => new Command(obj =>
        {
            if (SelectedProperty != null)
            {
                Application.Current?.MainPage?.Navigation.PushAsync(new DetailsPage(_context, SelectedProperty));
            }

            SelectedProperty = null;
        });

        public HomeViewModel(DatabaseContext context)
        {
            _context = context;
            Properties = [];
        }

        public void Update(string name)
        {
            CurrentTag = name;

            Properties.Clear();

            foreach (var property in PropertyRepo.AllPropreties)
            {
                if (CurrentTag?.Replace(" ", "") == AppResources.TagNewLabel.Replace(" ", "") || 
                    CurrentTag?.ToLower().Replace(" ", "") == property.AdsTypeLabel.ToLower().Replace(" ", ""))
                {
                    Properties.Add(property);
                }
            }

            //SemanticScreenReader.Announce("" + CurrentTag);
        }
    }
}
