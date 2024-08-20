using Land_Property_App.Database;
using Land_Property_App.Models;

namespace Land_Property_App.ViewModels
{
    public class DetailsSpecViewModel : BaseViewModel
    {
        public Property? SelectedProperty { get; set; }

        public DetailsSpecViewModel(DatabaseContext context, Property property)
        {
            _context = context;
            SelectedProperty = property;
        }
    }
}
