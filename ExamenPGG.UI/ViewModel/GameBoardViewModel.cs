using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.PlayerObject;
using ExamenPGG.UI.View;

namespace ExamenPGG.UI.ViewModel
{
    public partial class GameBoardViewModel : ObservableObject
    {
        [ObservableProperty]
        private IGame currentGame;

        private IPlayer WinningPlayer;

        public GameBoardViewModel(IGame game)
        {
            CurrentGame = game;

        }
        //[RelayCommand]
        //private async Task GoToEndGameAsync()
        //{
        //    await Shell.Current.GoToAsync($"{nameof(EndGameView)}");
        //}
    }
}