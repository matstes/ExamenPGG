using ExamenPGG.UI.ViewModel;
using Plugin.Maui.Audio;

namespace ExamenPGG.UI.View;

public partial class PlayerSelectionView : ContentPage
{
    private readonly IAudioManager audioManager;
    private bool isPlayingMusic = false;

    public PlayerSelectionView(PlayerSelectionViewModel vm, IAudioManager audioManager)
    {
        InitializeComponent();
        BindingContext = vm;

        this.audioManager = audioManager;
    }

    private async void StartMusic(object sender, EventArgs e)
    {
        var playerMusic = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("luigismansion.wav"));
        if (isPlayingMusic == false)
        {
            isPlayingMusic = true;
            playerMusic.Play();
            playerMusic.Loop = true;
        }
    }
}