using GarneyAppSystem.ApiService;
using GarneyAppSystem.Views.Home;
//using Android.OS;

namespace GarneyAppSystem
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private readonly LoginService _loginservice = new LoginService();

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "Email and Password are required.", "OK");
                return;
            }

            try
            {
                var result = await _loginservice.LoginAccountAsync(email, password);

                if (result != null && !string.IsNullOrWhiteSpace(result.apiResult?.token))
                {
                    Preferences.Set("authToken", result.apiResult.token);
                    Preferences.Set("uid", result.user.Id);

                    await Navigation.PushAsync(new HomeIndex());
                }
                else
                {
                    await DisplayAlert("Login Failed", "Invalid email or password.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    }

}
