using Land_Property_App.Animators;
using Land_Property_App.Models;
using Land_Property_App.ViewModels;

namespace Land_Property_App.Views;

public partial class DetailsSpecPage : ContentPage
{
    public DetailsSpecPage(Property selectedProperty)
    {
        InitializeComponent();

        var viewModel = new DetailsSpecViewModel()
        {
            SelectedProperty = selectedProperty,
        };

        this.BindingContext = viewModel;

        SetViewPositions();

        Loaded += PlayAnimationOnLoaded;
    }

    private void SetViewPositions()
    {
        FloatingBackButton.TranslationX = -200;
        FloatingBackButton.Opacity = 0;
    }

    private void PlayAnimationOnLoaded(Object? sender, EventArgs? e)
    {
        SimpleAnimation.FadeAndTranslate(FloatingBackButton);
    }
}