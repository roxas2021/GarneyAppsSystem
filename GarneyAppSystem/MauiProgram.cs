using GarneyAppSystem.CustomControls;
using Microsoft.Extensions.Logging;
using GarneyAppSystem.Platforms;
using CommunityToolkit.Maui;

namespace GarneyAppSystem
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Poppins-Regular.ttf", "Poppins");
                    fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
                });

            #if DEBUG
            builder.Logging.AddDebug();
            #endif

            builder.Services.AddSingleton<CurvedHeaderDrawable>();
            Microsoft.Maui.Handlers.ElementHandler.ElementMapper.AppendToMapping("Classic", (handler, view) =>
            {
                if (view is StandardEntry)
                {
                    EntryMapper.Map(handler, view);
                }
            });

            return builder.Build();
        }
    }
}
