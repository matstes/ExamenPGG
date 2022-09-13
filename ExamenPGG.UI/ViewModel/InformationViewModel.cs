using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExamenPGG.Business.GameObject;
using ExamenPGG.UI.View;

namespace ExamenPGG.UI.ViewModel
{
    public partial class InformationViewModel : ObservableObject
    {
        [ObservableProperty]
        private IGame game;

        public InformationViewModel(IGame game)
        {
            Game = game;
        }

        [RelayCommand]
        private async Task GoToRules()
        {
            await Shell.Current.GoToAsync($"{nameof(GameRulesView)}");
        }

        [RelayCommand]
        private async Task GoBack()
        {
            //BUGGED: if computer is playing ang you go back - start again - go back ...
            //the game speeds up dramatically each time and eventually crashes.

            //BUGGED: When RAPIDLY pressing go back -> start new game (with bot in test)
            //not only does the game speed up like crazy, it eventually gets completely frozen
            await Shell.Current.GoToAsync($"..");
        }

        [RelayCommand]
        private async Task GoToLeaderBoardAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(LeaderBoardView)}");
        }
    }
}