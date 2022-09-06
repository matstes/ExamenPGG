using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExamenPGG.Business.GameObject;
using ExamenPGG.UI.View;

namespace ExamenPGG.UI.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private IGame game;

        public MainViewModel(IGame game)
        {
            Game = game;
        }

        [RelayCommand]
        private async Task StartGame()
        {
            Game.StartGame();
            await Shell.Current.GoToAsync($"{nameof(GameBoardView)}");
            
        }
    }
}