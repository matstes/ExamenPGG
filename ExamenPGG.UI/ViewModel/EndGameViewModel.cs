using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExamenPGG.Business.GameObject;
using ExamenPGG.UI.View;

namespace ExamenPGG.UI.ViewModel
{
    public partial class EndGameViewModel : ObservableObject
    {
        [ObservableProperty]
        private IGame currentGame;

        public EndGameViewModel(IGame game)
        {
            CurrentGame = game;
        }

        [RelayCommand]
        private void GoToPlayerSelection()
        {
            // Async Navigation Causes Strange behaviour and crashes
            Shell.Current.GoToAsync("PlayerSelectionView");
        }
    }
}