using Land_Property_App.ViewModels;

namespace Land_Property_App.Views;

public partial class LandingPage : ContentPage
{
	public LandingPage()
	{
		InitializeComponent();

		this.BindingContext = new LandingViewModel();
        ((RadioButton)SectionList.Children[0]).IsChecked = true;
	}
}