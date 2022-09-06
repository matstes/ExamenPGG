using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExamenPGG.Business.GameObject;

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
        private void StartGame()
        {
            Game.StartGame();
        }
    }
}