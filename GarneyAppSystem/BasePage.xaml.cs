namespace GarneyAppSystem;
using GarneyAppSystem.Views.Home;
using GarneyAppSystem.Views.Dashboard;
using GarneyAppSystem.Views.Location;
using GarneyAppSystem.Views.Profile;

public partial class BasePage : ContentView
{
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