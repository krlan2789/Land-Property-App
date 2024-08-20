using Land_Property_App.Database;
using Land_Property_App.Models;
using Land_Property_App.Resources.Strings;
using System.Numerics;
using System.Windows.Input;

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
