using ExamenPGG.UI.ViewModel;
using Plugin.Maui.Audio;

namespace ExamenPGG.UI.View;

public partial class GameControlView : ContentView
{
    private bool isPlayingEffect = false;
    private readonly IAudioManager audioManager;

    public GameControlView(GameControlViewModel gcVM, IAudioManager audioManager)
	{
		InitializeComponent();
		BindingContext    = gcVM;
        this.audioManager = audioManager;
    }

	private void ScrollView_SizeChanged(object sender, EventArgs e)
	{
		logScreenScrollView.ScrollToAsync(0, 10000, true);
	}
    private async void GiveBloop(object sender, EventArgs e)
    {
        var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("bloop.wav"));

        if (isPlayingEffect == false)
        {
            player.Play();
            player.Volume = 0.5;
        }
    }
}