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

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            //if (count == 1)
            //    CounterBtn.Text = $"Clicked {count} time";
            //else
            //    CounterBtn.Text = $"Clicked {count} times";

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
