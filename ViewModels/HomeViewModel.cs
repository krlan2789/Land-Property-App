﻿using Land_Property_App.Database;
using Land_Property_App.Models;
using Land_Property_App.Resources.Strings;
using Land_Property_App.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Land_Property_App.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public string? CurrentTag { get; set; }
        public string? CurrentLocation { get; set; }

        public List<string> Tags => [
            AppResources.TagNewLabel,
            AppResources.TagSaleLabel,
            AppResources.TagRentLabel,
            AppResources.TagSaleCreditLabel,
        ];

        public required ObservableCollection<Property> Properties { get; set; }

        public Property? SelectedProperty { get; set; }
        public Placemark? Placemark { get; set; }


        public Action<object, Placemark>? OnLocationSelect;

        public ICommand OnPropertySelect => new Command(obj =>
        {
            if (SelectedProperty != null)
            {
                Application.Current?.MainPage?.Navigation.PushAsync(new DetailsPage(_context, SelectedProperty));
            }

            SelectedProperty = null;
        });
        public ICommand OpenMapsPage => new Command(obj =>
        {
            var mapsPage = new MapsPage(_context);
            mapsPage.OnLocationSelect += (object sender, Placemark placemark) => {
                this.Placemark = placemark;
                OnLocationSelect?.Invoke(sender, placemark);
            };
            Application.Current?.MainPage?.Navigation.PushAsync(mapsPage);
        });

        public HomeViewModel(DatabaseContext context)
        {
            _context = context;
            Properties = [];
        }

        public async void GetLastLocation()
        {
            Location? location = await Geolocation.Default.GetLastKnownLocationAsync();
            if (location != null)
            {
                IEnumerable<Placemark> placemarks = await Geocoding.Default.GetPlacemarksAsync(location.Latitude, location.Longitude);
                Placemark = placemarks?.FirstOrDefault();
            }

            if (Placemark == null) 
            {
                Placemark = new Placemark()
                {
                    CountryName = "Indonesia",
                    AdminArea = "DKI Jakarta",
                    SubAdminArea = "Jakarta Pusat",
                };
            }

            CurrentLocation = Placemark.SubAdminArea;
            OnLocationSelect?.Invoke(this, Placemark);
        }

        public void Update(string name)
        {
            CurrentTag = name;

            Properties.Clear();

            foreach (var property in PropertyRepo.AllPropreties)
            {
                if (
                    (CurrentTag?.Replace(" ", "") == AppResources.TagNewLabel.Replace(" ", "") || 
                    CurrentTag?.ToLower().Replace(" ", "") == property.AdsTypeLabel.ToLower().Replace(" ", "")) &&
                    IsCurrentLocation(property.Address)
                ) {
                    Properties.Add(property);
                }
            }

            //SemanticScreenReader.Announce("" + CurrentTag);
        }

        public bool IsCurrentLocation(string address)
        {
            if (Placemark == null) return true;

            foreach (string loc in address.Replace(", ", ",").Split(','))
            {
                string area = loc.ToLower().Replace("kabupaten ", "");
                area = area.Replace("kabupaten ", "");
                area = area.Replace("kecamatan ", "");
                area = area.Replace("kelurahan ", "");
                area = area.Replace("ibukota ", "");
                area = area.Replace("ibu kota ", "");
                area = area.Replace("kota ", "");
                area = area.Replace("kab ", "");
                area = area.Replace("kec ", "");
                area = area.Replace("kel ", "");

                bool status = Placemark.CountryCode.Contains(area, StringComparison.CurrentCultureIgnoreCase);
                status = status || Placemark.AdminArea.Contains(area, StringComparison.CurrentCultureIgnoreCase);
                status = status || Placemark.SubAdminArea.Contains(area, StringComparison.CurrentCultureIgnoreCase);
                status = status || Placemark.Locality.Contains(area, StringComparison.CurrentCultureIgnoreCase);
                status = status || Placemark.SubLocality.Contains(area, StringComparison.CurrentCultureIgnoreCase);

                if (status) return true;
            }

            return false;
        }
    }
}
