
using ApplicationService.EntityModel;
using ApplicationService.Utility;
using GarneyAppSystem.ApiService;

namespace GarneyAppSystem.Views.Profile;

public partial class ProfileIndex : ContentPage
{
    private readonly UserService _userservice = new UserService();

    public ProfileIndex()
    {
        InitializeComponent();
    }

    private async void OnClickEditProfileDetails(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditProfile());
    }

    private async void OnClickLogoutProfileDetails(object sender, EventArgs e)
    {
        var result = await DisplayAlert("Logout", "Are you sure you want to logout?", "Yes", "No");

        if (result)
        {
            Preferences.Set("uid", 0);
            Preferences.Set("authToken", string.Empty);
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
    }

    private async void OnEditImageTapped(object sender, EventArgs e)
    {
        user _user = BindingContext as user;

        await Navigation.PushAsync(new EditProfilePicture(_user));
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        LoadingIndicator.IsVisible = true;
        MainContent.IsVisible = true;

        try
        {
            var data = await _userservice.getUserDetail();

            string imagedir = string.Empty;

            #if DEBUG
                //imagedir = "http://192.168.2.75:5166/profileuploads/";
                imagedir = "http://pinoypride-001-site1.ntempurl.com/profileuploads/";
            #else
                imagedir = "http://pinoypride-001-site1.ntempurl.com/profileuploads/";
            #endif

            data.user.imageDIR = data.user.imageDIR != "profile4.png" ? imagedir + data.user.imageDIR : data.user.imageDIR;
            data.user.PasswordHash = EncryptionHelper.Decrypt(data.user.PasswordHash);

            BindingContext = data.user;
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
    }
}