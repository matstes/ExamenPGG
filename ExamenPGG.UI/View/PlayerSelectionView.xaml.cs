using ExamenPGG.UI.ViewModel;
using Plugin.Maui.Audio;

namespace ExamenPGG.UI.View;

public partial class PlayerSelectionView : ContentPage
{
    private readonly IAudioManager audioManager;
    public bool isPlayingMusic = false;

    public PlayerSelectionView(PlayerSelectionViewModel vm, IAudioManager audioManager)
    {
        InitializeComponent();
        BindingContext = vm;

        this.audioManager = audioManager;
    }

    public async void StartMusic(object sender, EventArgs e)
    {
        //BUGGED: ONLY AFTER END SCREEN HAS BEEN SEEN: game gets played twice and overlaps on new game
       if (isPlayingMusic == false)
       {
           var playerMusic = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("luigismansion.wav"));
           isPlayingMusic = true;
           playerMusic.Play();
           playerMusic.Loop = true;
       }
    }
}