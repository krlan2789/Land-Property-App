using Land_Property_App.Database;
using Land_Property_App.ViewModels;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System.Diagnostics;

namespace Land_Property_App.Views;

public delegate void OnLocationSelectEventHandler(object source, Placemark placemark);

public partial class MapsPage : ContentPage
{
    public event OnLocationSelectEventHandler? OnLocationSelect;

    private MapsViewModel VM => (MapsViewModel)BindingContext;

    public MapsPage(DatabaseContext context)
	{
		InitializeComponent();

		var viewModel = new MapsViewModel();
        viewModel.OnLocationSelect = (object sender, Placemark placemark) =>
        {
            OnLocationSelect?.Invoke(sender, placemark);
        };
        viewModel.OnStopListening = OnStopListening;
		BindingContext = viewModel;

        //MapView.IsZoomEnabled = false;

        OnStartListening();
    }

    private async void OnStartListening()
    {
        try
        {
            Location? location = await Geolocation.Default.GetLastKnownLocationAsync();
            MapView.MoveToRegion(MapSpan.FromCenterAndRadius(location ?? VM.Coordinate, Distance.FromKilometers(1)));

            Geolocation.LocationChanged += Geolocation_LocationChanged;
            var request = new GeolocationListeningRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(8));
            var success = await Geolocation.StartListeningForegroundAsync(request);

            string status = success
                ? "Started listening for foreground location updates"
                : "Couldn't start listening";
            SemanticScreenReader.Announce(status);
        }
        catch (Exception ex)
        {
            // Unable to start listening for location changes
            Trace.WriteLine(ex.Message, "Exception");

            SemanticScreenReader.Announce(ex.Message);
        }
    }

    private void Geolocation_LocationChanged(object? sender, GeolocationLocationChangedEventArgs e)
    {
        // Process e.Location to get the new location
        VM.Coordinate = e.Location;
        //var pin = new Pin
        //{
        //    Label = "Your location",
        //    Location = VM.Coordinate,
        //};
        //MapView.Pins.Clear();
        //MapView.Pins.Add(pin);
        MapView.MoveToRegion(MapSpan.FromCenterAndRadius(VM.Coordinate, Distance.FromKilometers(20)));
    }

    private void OnStopListening()
    {
        try
        {
            Geolocation.LocationChanged -= Geolocation_LocationChanged;
            Geolocation.StopListeningForeground();

            var center = MapView.VisibleRegion?.Center;
            if (center != null && VM.Coordinate.CalculateDistance(center, DistanceUnits.Kilometers) > 0.01)
            {
                VM.Coordinate = center;
            }

            string status = "Stopped listening for foreground location updates";
            SemanticScreenReader.Announce(status);
        } catch (Exception ex)
        {
            // Unable to stop listening for location changes
            Trace.WriteLine(ex.Message, "Exception");

            SemanticScreenReader.Announce(ex.Message);
        }
    }

    public static async Task CheckMock()
    {
        GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium);
        Location? location = await Geolocation.Default.GetLocationAsync(request);

        if (location != null && location.IsFromMockProvider)
        {
            // location is from a mock provider
            string message = "Fake location has been detected!";
            Trace.WriteLine(message, "Warning");

            SemanticScreenReader.Announce(message);
        }
    }

    private void OnCenterButtonClicked(object sender, EventArgs args)
    {
        MapView.MoveToRegion(MapSpan.FromCenterAndRadius(VM.Coordinate, Distance.FromKilometers(1)));
    }

    private void OnMapPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
    {
        string message = $"{e.Status} | ScaleOrigin: {e.ScaleOrigin} | MapView.Scale: {MapView.Scale}";
        Trace.WriteLine(message, "OnMapPinchUpdated");
        SemanticScreenReader.Announce(message);
    }
}