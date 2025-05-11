
using ApplicationService.Utility;
using GarneyAppSystem.ApiService;

namespace GarneyAppSystem.Views.Profile;

public partial class ProfileIndex : ContentPage
{
    private readonly UserService _userservice = new UserService();

    public ProfileIndex()
    {
        InitializeComponent();
        LoadData();
    }

    private async void LoadData()
    {
        var data = await _userservice.getUserDetail();

        data.user.PasswordHash = EncryptionHelper.Decrypt(data.user.PasswordHash);

        BindingContext = data.user;
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
}