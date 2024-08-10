using Land_Property_App.Models;

namespace Land_Property_App.Views;

public partial class DetailsPage : ContentPage
{
	public Property SelectedProperty { get; set; }

	public DetailsPage(Property selectedProperty)
	{
		InitializeComponent();

		SelectedProperty = selectedProperty;
	}
}