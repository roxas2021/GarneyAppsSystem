namespace GarneyAppSystem.Views.Layout;

public partial class LoadingView : ContentView
{
	public LoadingView()
	{
		InitializeComponent();
    }

    public void Show()
    {
        Root.IsVisible = true;
    }

    public void Hide()
    {
        Root.IsVisible = false;
    }
}