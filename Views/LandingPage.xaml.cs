using Land_Property_App.Animators;
using Land_Property_App.ViewModels;

namespace Land_Property_App.Views;

public partial class LandingPage : ContentPage
{
	public LandingPage()
	{
		InitializeComponent();

		this.BindingContext = new LandingViewModel();
        ((RadioButton)SectionList.Children[0]).IsChecked = true;

        SetViewPositions();

        Loaded += PlayAnimationOnLoaded;
    }

    private void SetViewPositions()
    {
        greetingView.TranslationY = -300;
        greetingView.Scale = 5;

        locationView.TranslationY = -300;
        locationView.Scale = 5;

        categoryView.TranslationX = 500;
        
        colView.TranslationY = 500;
        colView.Opacity = 0.5;
        colView.Scale = 5;
    }

    private void PlayAnimationOnLoaded(Object? sender, EventArgs? e)
    {
        Task.Delay(250);
        
        SimpleAnimation.FadeAndTranslate(greetingView, translateLength: 750);
        SimpleAnimation.FadeAndScale(greetingView, scaleLength: 750);

        SimpleAnimation.FadeAndTranslate(locationView, translateLength: 750);
        SimpleAnimation.FadeAndScale(locationView, scaleLength: 750);

        Task.Delay(200);
        
        SimpleAnimation.FadeAndTranslate(categoryView, translateLength: 750);
        
        SimpleAnimation.FadeAndTranslate(colView, translateLength: 750);
        SimpleAnimation.FadeAndScale(colView, scaleLength: 750);
    }
}