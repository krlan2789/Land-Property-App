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
            CurrentImage = selectedProperty.DefaultImage,
            MoreItems = 0,
            PropertyImages = selectedProperty?.Images ?? [],
        };

        if (selectedProperty?.Images?.Count > 2)
        {
            viewModel.PropertyImages = selectedProperty.Images.Take(2).ToList();
            viewModel.MoreItems = selectedProperty.Images.Count - 2;
        }
        else
        {
            ThumbnailFooterView.IsVisible = false;
        }

        TitleLabelView.IsVisible = !string.IsNullOrEmpty(selectedProperty?.Title);
        AddressLabelView.IsVisible = !string.IsNullOrEmpty(selectedProperty?.Address);

        this.BindingContext = viewModel;

        SetViewPositions();

        Loaded += PlayAnimationOnLoaded;
    }

    private void SetViewPositions()
    {
        FloatingBackButton.TranslationX = -200;
        FloatingBackButton.Opacity = 0;

        DetailsBtn.TranslationX = 200;
        DetailsBtn.Opacity = 0;

        ImagesView.TranslationX = 200;
        ImagesView.Opacity = 0;

        addressView.TranslationX = -30;
        addressView.TranslationY = -30;
        addressView.Opacity = 0;

        BuyBtn.Opacity = 0;
        BuyBtn.Scale = 0.2;

        PopView.TranslationY = 300;
        PopView.Opacity = 0.5;
    }

    private void PlayAnimationOnLoaded(Object? sender, EventArgs? e)
    {
        SimpleAnimation.FadeAndTranslate(FloatingBackButton);
        SimpleAnimation.FadeAndTranslate(DetailsBtn);
        SimpleAnimation.FadeAndTranslate(ImagesView);

        Task.Delay(200);

        SimpleAnimation.FadeAndTranslate(PopView, 500, 500);
        SimpleAnimation.FadeAndTranslate(addressView, 500, 500);
        SimpleAnimation.FadeAndScale(BuyBtn, 500, 500);
    }
}
