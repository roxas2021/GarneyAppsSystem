using Microsoft.Maui.Handlers;

namespace GarneyAppSystem
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            {
            #if ANDROID
                            handler.PlatformView.Background = null; // Removes underline on Android
            #elif IOS
                            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None; // Removes border on iOS
            #endif
                        });

                        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
                        {
            #if ANDROID
                            handler.PlatformView.Background = null; // Removes underline on Android
            #elif IOS
                            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None; // Removes border on iOS
            #endif
                        });

                        RadioButtonHandler.Mapper.AppendToMapping(nameof(RadioButton), (handler, view) =>
                        {
            #if ANDROID
                            if (handler.PlatformView is Android.Widget.RadioButton nativeRadioButton)
                            {
                                nativeRadioButton.ButtonTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Gray);
                            }
            #endif
                        });

                        Microsoft.Maui.Handlers.EditorHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
                        {
            #if ANDROID
                            handler.PlatformView.Background = null; // Removes underline on Android
            #elif IOS
                            handler.PlatformView.Layer.BorderWidth = 0; // Removes the border for iOS
                            handler.PlatformView.Layer.BorderColor = UIKit.UIColor.Clear.CGColor; // Ensures no visible border
            #endif
                        });
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}