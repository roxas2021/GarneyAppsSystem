
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Maps;
using Map = Microsoft.Maui.Controls.Maps.Map;
namespace GarneyAppSystem.Views.Home;


public partial class GarbageTrackPage : ContentPage
{
    public GarbageTrackPage()
    {
        InitializeComponent();
        SetUserLocationAsync();
    }

    private async Task SetUserLocationAsync()
    {
        //try
        //{
        //    var request = new GeolocationRequest(GeolocationAccuracy.High);
        //    var location = await Geolocation.GetLocationAsync(request);

        //    if (location != null)
        //    {
        //        var userPosition = new Position(location.Latitude, location.Longitude);

        //        if (googleMap != null)
        //        {
        //            googleMap.MoveToRegion(MapSpan.FromCenterAndRadius(userPosition, Distance.FromMiles(1)));
        //        }
        //        else
        //        {
        //            Console.WriteLine("Error: googleMap is not initialized.");
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"Error getting location: {ex.Message}");
        //}
    }

}
