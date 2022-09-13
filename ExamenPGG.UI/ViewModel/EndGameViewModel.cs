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
        private async Task GoToStartViewAsync()
        {
            await Shell.Current.GoToAsync("../../..");
        }
    }
}