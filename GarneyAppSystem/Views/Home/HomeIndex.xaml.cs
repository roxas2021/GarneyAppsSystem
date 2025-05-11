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
    }
}