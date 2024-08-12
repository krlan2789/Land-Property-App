using Land_Property_App.Models;
using Land_Property_App.Views;
using System.Diagnostics;
using System.Windows.Input;

namespace Land_Property_App.ViewModels
{
    public class DetailsViewModel : BaseViewModel
    {
        public required Property SelectedProperty { get; set; }
        public required string CurrentImage { get; set; }
        public List<string>? PropertyImages { get; set; }
        public int MoreItems { get; set; }

        public ICommand OnCloseCommand => new Command(() => Application.Current?.MainPage?.Navigation.PopAsync(true));

        public ICommand OnDetailsSpecCommand => new Command(() =>
        {
            Debug.Print("Address: " + SelectedProperty?.Address);
            if (SelectedProperty != null)
            {
                Application.Current?.MainPage?.Navigation.PushAsync(new DetailsSpecPage(SelectedProperty));
            }
        });

        public ICommand OnImageOptionSelect => new Command(obj=>
        {
        });
    }
}
