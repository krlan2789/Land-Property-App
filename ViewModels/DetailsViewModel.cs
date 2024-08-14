using Land_Property_App.Database;
using Land_Property_App.Models;
using Land_Property_App.Views;
using System.Diagnostics;
using System.Windows.Input;

namespace Land_Property_App.ViewModels
{
    public class DetailsViewModel : BaseViewModel
    {
        public Property? SelectedProperty { get; set; }
        public string CurrentImage { get; set; }
        public List<string>? PropertyImages { get; set; }
        public int MoreItems { get; set; }

        public ICommand OnCloseCommand => new Command(() => Application.Current?.MainPage?.Navigation.PopAsync(true));

        public ICommand OnDetailsSpecCommand => new Command(() =>
        {
            Debug.Print("Address: " + SelectedProperty?.Address);
            if (SelectedProperty != null)
            {
                Application.Current?.MainPage?.Navigation.PushAsync(new DetailsSpecPage(_context, SelectedProperty));
            }
        });

        public ICommand OnImageOptionSelect => new Command(obj=> {});

        public DetailsViewModel(DatabaseContext context, Property property)
        {
            _context = context;
            SelectedProperty = property;

            SelectedProperty = SelectedProperty;
            CurrentImage = SelectedProperty.DefaultImage;
            MoreItems = 0;
            PropertyImages = SelectedProperty?.Images ?? [];

            if (SelectedProperty?.Images?.Count > 2)
            {
                PropertyImages = SelectedProperty.Images.Take(2).ToList();
                MoreItems = SelectedProperty.Images.Count - 2;
            }
        }
    }
}
