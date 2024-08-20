using Land_Property_App.Animators;
using Land_Property_App.Resources.Strings;
using Land_Property_App.ViewModels;
using System.ComponentModel;
using System.Diagnostics;

namespace Land_Property_App.Views;

public partial class HomePage : ContentPage, INotifyPropertyChanged
{
    private HomeViewModel VM => (HomeViewModel)BindingContext;

    public HomePage(HomeViewModel viewModel)
    {
        InitializeComponent();

        viewModel.CurrentTag = viewModel.Tags[0] ?? AppResources.TagNewLabel;
        viewModel.OnLocationSelect = OnLocationSelect;
        viewModel.GetLastLocation();
        viewModel.Update(viewModel.CurrentTag);
        BindingContext = viewModel;

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

        TagSelectionView.TranslationX = 500;

        ColView.TranslationY = 500;
        ColView.Opacity = 0.5;
        ColView.Scale = 5;
    }

    private void PlayAnimationOnLoaded(object? sender, EventArgs? e)
    {
        Task.Delay(250);

        SimpleAnimation.FadeAndTranslate(GreetingView, translateLength: 750);
        SimpleAnimation.FadeAndScale(GreetingView, scaleLength: 750);

        SimpleAnimation.FadeAndTranslate(LocationView, translateLength: 750);
        SimpleAnimation.FadeAndScale(LocationView, scaleLength: 750);

        Task.Delay(200);

        SimpleAnimation.FadeAndTranslate(TagSelectionView, translateLength: 750);

        SimpleAnimation.FadeAndTranslate(ColView, translateLength: 750);
        SimpleAnimation.FadeAndScale(ColView, scaleLength: 750);
    }

    public void OnTagCheckedChanged(object sender, CheckedChangedEventArgs args)
    {
        if (args.Value)
        {
            RadioButton rb = (RadioButton)sender;

            Trace.WriteLine($"{rb.Value}::{args.Value}");

            VM.Update((string)rb.Value);
        }
    }
    
    public void OnLocationSelect(object source, Placemark placemark)
    {
        Debug.WriteLine("Location: {0}", placemark.ToString());
        LocationValue.Text = placemark.SubAdminArea;
        VM.Update("" + VM.CurrentTag);
    }
}