using Land_Property_App.Models;
using Land_Property_App.Resources.Strings;
using System.Numerics;
using System.Windows.Input;

namespace Land_Property_App.ViewModels
{
    public class DetailsSpecViewModel : BaseViewModel
    {
        public Property? SelectedProperty { get; set; }

        public ICommand OnCloseCommand => new Command(() => Application.Current?.MainPage?.Navigation.PopAsync(true));

        //public IList<PropertySpecItem> PropertySpecs
        //{
        //    get
        //    {
        //        IList<PropertySpecItem> specs = [];

        //        if (SelectedProperty != null)
        //        {
        //            if (SelectedProperty.Bedroom > 0) specs.Add(new PropertySpecItem()
        //            {
        //                Name = AppResources.PropertiSpecBedroomLabel, 
        //                Value = "" + SelectedProperty.Bedroom,
        //            });
        //            if (SelectedProperty.Bathroom> 0) specs.Add(new PropertySpecItem()
        //            {
        //                Name = AppResources.PropertiSpecBathroomLabel,
        //                Value = "" + SelectedProperty.Bathroom,
        //            });
        //            if (SelectedProperty.LandArea != Vector2.Zero) specs.Add(new PropertySpecItem()
        //            {
        //                Name = AppResources.PropertiSpecLandAreaLabel,
        //                Value = $"{SelectedProperty.LandArea.LengthSquared()} m²",
        //            });
        //            if (SelectedProperty.BuildingArea > 0) specs.Add(new PropertySpecItem()
        //            {
        //                Name = AppResources.PropertiSpecBuildingAreaLabel,
        //                Value = $"{SelectedProperty.BuildingArea} m²",
        //            });
        //        }

        //        return specs;
        //    }
        //}
    }
}
