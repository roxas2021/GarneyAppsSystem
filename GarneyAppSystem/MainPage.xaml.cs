using GarneyAppSystem.Views.Home;

namespace GarneyAppSystem
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            #if ANDROID
               var window = Platform.CurrentActivity?.Window;
               if (window != null)
               {
                    window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#4BA734")); // your green color
                    window.DecorView.SystemUiVisibility = (Android.Views.StatusBarVisibility)Android.Views.SystemUiFlags.LightStatusBar; // Optional: dark icons
               }
            #endif

        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            await Navigation.PushAsync(new HomeIndex());
        }
    }

}
