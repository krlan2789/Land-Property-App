using Land_Property_App.Models;
using Land_Property_App.ViewModels;

namespace Land_Property_App.Views;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(Property selectedProperty)
	{
		InitializeComponent();

        var viewModel = new DetailsViewModel()
		{
			SelectedProperty = selectedProperty,
			MoreItems = 0,
            PropertyImages = selectedProperty?.Images ?? [],
		};

		if (selectedProperty?.Images?.Count > 2)
		{
			viewModel.PropertyImages = selectedProperty.Images.Take(2).ToList();
			viewModel.MoreItems = selectedProperty.Images.Count - 2;
		}

		this.BindingContext = viewModel;
    }
}