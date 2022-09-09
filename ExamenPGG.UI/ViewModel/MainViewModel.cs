using ExamenPGG.UI.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExamenPGG.Business.GameObject;

namespace ExamenPGG.UI.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private IGame game;

        public InformationView InformationView { get; set; }
        public GameBoardView GameBoardView { get; set; }
        public GameControlView GameControlView { get; set; }
        public MainViewModel(IGame game, GameControlView gameControlView, InformationView informationView, GameBoardView gameBoardView)
        {
            GameControlView = gameControlView;
            InformationView = informationView;
            GameBoardView = gameBoardView;
            Game = game;
            Game.StartGame();
        }

        [RelayCommand]
        private async Task StartGame()
        {
            Game.StartGame();
            await Shell.Current.GoToAsync($"{nameof(GameBoardView)}");
            
        }
    }
}