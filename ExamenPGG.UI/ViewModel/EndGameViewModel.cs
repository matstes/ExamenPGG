using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExamenPGG.Business.GameObject;
using ExamenPGG.UI.View;

namespace ExamenPGG.UI.ViewModel
{
    public partial class EndGameViewModel : ObservableObject
    {
        //BUGGED: need to click twice to exit game and go back to start
        //This also causes the music to glitch on new game start (after a previous game has ended)

        [ObservableProperty]
        private IGame currentGame;

        public EndGameViewModel(IGame game)
        {
            CurrentGame = game;
        }

        [RelayCommand]
        private async Task GoToStartViewAsync()
        {
            await Shell.Current.GoToAsync("../../..");
        }
    }
}