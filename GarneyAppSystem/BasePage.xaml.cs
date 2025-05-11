namespace GarneyAppSystem;
using GarneyAppSystem.Views.Home;
using GarneyAppSystem.Views.Dashboard;
using GarneyAppSystem.Views.Location;
using GarneyAppSystem.Views.Profile;
using GarneyAppSystem.ApiService;

public partial class BasePage : ContentView
{
    private readonly UserService _userService;

	public BasePage()
	{
		InitializeComponent();
        //ContentPlaceHolder.Content = new HomeIndex();
    }
    //public async void SetContent(View content)
    //{
    //    await Navigation.PushAsync(new HomeIndex());
    //}

    public View PageContent
    {
        get => ContentPlaceHolder.Content;
        set => ContentPlaceHolder.Content = value;
    }

    private async void OnBtnClickedHome(object sender, EventArgs e)
    {
        var image = (Image)sender;

        await image.ScaleTo(0.95, 100, Easing.CubicIn);

        await image.ScaleTo(1, 100, Easing.CubicOut);

        //string authToken = Preferences.Get("authToken", string.Empty);
        //int userId = Preferences.Get("uid", defaultValue: 0);

        //var data = await _userService.getUserDetail(userId, authToken);

        await Navigation.PushAsync(new HomeIndex());
    }

    private async void OnBtnClickeddashboard(object sender, EventArgs e)
    {
        var image = (Image)sender;

        await image.ScaleTo(0.95, 100, Easing.CubicIn);

        await image.ScaleTo(1, 100, Easing.CubicOut);

        await Navigation.PushAsync(new DashboardBase());
    }

    private async void OnBtnClickedprofile(object sender, EventArgs e)
    {
        var image = (Image)sender;

        await image.ScaleTo(0.95, 100, Easing.CubicIn);

        await image.ScaleTo(1, 100, Easing.CubicOut);

        await Navigation.PushAsync(new ProfileIndex());
    }

    private async void OnBtnClickedLocation(object sender, EventArgs e)
    {
        var image = (Image)sender;

        await image.ScaleTo(0.95, 100, Easing.CubicIn);

        await image.ScaleTo(1, 100, Easing.CubicOut);

        await Navigation.PushAsync(new GarbageTrackPage());
    }
}