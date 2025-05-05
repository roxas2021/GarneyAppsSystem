namespace GarneyAppSystem.Views.Home;
using GarneyAppSystem.Views.Home;
using GarneyAppSystem.Views.Dashboard;
using GarneyAppSystem.Views.Location;
using GarneyAppSystem.Views.Profile;

public partial class HomeBase : ContentPage
{
	public HomeBase()
	{
		InitializeComponent();

        //ContentPlaceHolder.Content = new HomeIndex();
    }
    //public async void SetContent(View content)
    //{
    //    ContentPlaceHolder.Content = new HomeIndex();
    //}

    private async void OnBtnClickedHome(object sender, EventArgs e)
    {
        var image = (Image)sender;

        await image.ScaleTo(0.95, 100, Easing.CubicIn);

        await image.ScaleTo(1, 100, Easing.CubicOut);

        await Navigation.PushAsync(new HomeBase());
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

        await Navigation.PushAsync(new LocationIndex());
    }
}