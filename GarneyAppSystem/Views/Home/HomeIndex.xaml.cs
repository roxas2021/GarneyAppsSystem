using ApplicationService.EntityModel;
using GarneyAppSystem.ApiService;

namespace GarneyAppSystem.Views.Home;

public partial class HomeIndex : ContentPage
{
    private readonly UserService _userservice = new UserService();

	public HomeIndex()
	{
		InitializeComponent();
        //LoadData();
    }

    public async void LoadData()
    {
        var data = await _userservice.getUserDetail();

        BindingContext = data.user;
    }

	private async void onBtnClickUpload(Object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UploadPage());
    }

    private async void onBtnClickExchange(Object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MarketPage());
    }

    private async void onBtnClickGarbageTrack(Object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GarbageTrackPage());
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        LoadingIndicator.IsVisible = true;
        MainContent.IsVisible = true;

        try
        {
            var user = await _userservice.getUserDetail();
            BindingContext = user.user;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
        finally
        {
            LoadingIndicator.IsVisible = false;
            MainContent.IsVisible = true;
        }

        var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

        if(status != PermissionStatus.Granted)
        {
            status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
        }

        if (status == PermissionStatus.Granted)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(10)
                    });
                }

                if (location == null)
                {
                    bool goToSettings = await DisplayAlert(
                        "Location Required",
                        "Please enable location services in device settings.",
                        "Go to Settings",
                        "Cancel");

                    if (goToSettings)
                    {
                        AppInfo.ShowSettingsUI();
                    }
                }
                else
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}");
                }
            }
            catch (FeatureNotEnabledException)
            {
                bool goToSettings = await DisplayAlert(
                    "Location Disabled",
                    "Please enable location services in device settings.",
                    "Go to Settings",
                    "Cancel");

                if (goToSettings)
                {
                    AppInfo.ShowSettingsUI();
                }
            }
            catch (PermissionException)
            {
                await DisplayAlert("Permission Error", "Location permission is not granted.", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Unable to get location: {ex.Message}", "OK");
            }
        }
        else
        {
            await DisplayAlert("Permission Required", "Please enable location permission.", "OK");
        }
    }
}