using Land_Property_App.Animators;
using Land_Property_App.ViewModels;

namespace Land_Property_App.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();

        this.BindingContext = new HomeViewModel();
        ((RadioButton)TagsList.Children[0]).IsChecked = true;

        SetViewPositions();

        Loaded += PlayAnimationOnLoaded;
    }

    private void SetViewPositions()
    {
        GreetingView.TranslationY = -300;
        GreetingView.Scale = 5;

        LocationView.TranslationY = -300;
        LocationView.Scale = 5;

        CategoryView.TranslationX = 500;

        ColView.TranslationY = 500;
        ColView.Opacity = 0.5;
        ColView.Scale = 5;
    }

    private void PlayAnimationOnLoaded(Object? sender, EventArgs? e)
    {
        Task.Delay(250);

        SimpleAnimation.FadeAndTranslate(GreetingView, translateLength: 750);
        SimpleAnimation.FadeAndScale(GreetingView, scaleLength: 750);

        SimpleAnimation.FadeAndTranslate(LocationView, translateLength: 750);
        SimpleAnimation.FadeAndScale(LocationView, scaleLength: 750);

        Task.Delay(200);

        SimpleAnimation.FadeAndTranslate(CategoryView, translateLength: 750);

        SimpleAnimation.FadeAndTranslate(ColView, translateLength: 750);
        SimpleAnimation.FadeAndScale(ColView, scaleLength: 750);
    }
}