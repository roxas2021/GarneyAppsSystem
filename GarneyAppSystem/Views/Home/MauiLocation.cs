





namespace GarneyAppSystem.Views.Home
{
    internal class MauiLocation : Microsoft.Maui.Devices.Sensors.Location
    {
        public MauiLocation(double latitude, double longitude) : base(latitude, longitude)
        {
        }
    }
}