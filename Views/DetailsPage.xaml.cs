using Land_Property_App.Animators;
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

		SetViewPositions();

		Loaded += PlayAnimationOnLoaded;
    }

	private void SetViewPositions()
	{
		detailsBtn.Opacity = 0;
		detailsBtn.Scale = 0.2;

		imagesView.TranslationX = 200;
		imagesView.Opacity = 0;

		addressView.TranslationX = -30;
		addressView.TranslationY = -30;
		addressView.Opacity = 0;

		buyBtn.Opacity = 0;
		buyBtn.Scale = 0.2;

		popView.TranslationY = 300;
		popView.Opacity = 0.5;
	}

	private void PlayAnimationOnLoaded(Object? sender, EventArgs? e)
    {
        SimpleAnimation.FadeAndScale(detailsBtn);
        SimpleAnimation.FadeAndTranslate(imagesView);

        Task.Delay(200);

        SimpleAnimation.FadeAndTranslate(popView, 500, 500);
        SimpleAnimation.FadeAndTranslate(addressView, 500, 500);
        SimpleAnimation.FadeAndScale(buyBtn, 500, 500);
    }
}
