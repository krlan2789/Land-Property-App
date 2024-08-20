using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Land_Property_App.ViewModels
{
    public class MapsViewModel : BaseViewModel
    {
        public Location Coordinate { get; set; }

        public Action<object, Placemark>? OnLocationSelect;
        public Action? OnStopListening;

        public ICommand OnSelectCommand => new Command(OnSelectingLocation);

        public MapsViewModel() {
            Coordinate = new Location(0, 0);
        }

        private async void OnSelectingLocation()
        {
            OnStopListening?.Invoke();

            IEnumerable<Placemark> placemarks = await Geocoding.Default.GetPlacemarksAsync(Coordinate.Latitude, Coordinate.Longitude);

            Placemark? placemark = placemarks?.FirstOrDefault();

            if (placemark != null)
            {
                Trace.WriteLine($"" +
                    $"\nplacemark.CountryName: {placemark.CountryName}" +
                    $"\nplacemark.FeatureName: {placemark.FeatureName}" +
                    $"\nplacemark.Locality: {placemark.Locality}" +
                    $"\nplacemark.SubLocality: {placemark.SubLocality}" +
                    $"\nplacemark.AdminArea: {placemark.AdminArea}" +
                    $"\nplacemark.SubAdminArea: {placemark.SubAdminArea}" +
                    $"\nplacemark.Thoroughfare: {placemark.Thoroughfare}" +
                    $"\nplacemark.SubThoroughfare: {placemark.SubThoroughfare}" +
                    $"");

                /*
                    placemark.CountryName: Indonesia
                    placemark.AdminArea: Jawa Timur
                    placemark.SubAdminArea: Surabaya
                    placemark.Locality: Kecamatan Kenjeran
                    placemark.SubLocality: Tanah Kali Kedinding
                    placemark.Thoroughfare: Jalan Kalilom Lor Timur II
                    placemark.SubThoroughfare: 25
                    placemark.FeatureName: 25
                */

                OnLocationSelect?.Invoke(this, placemark);
            }

            Application.Current?.MainPage?.Navigation.PopAsync(true);
        }
    }
}
