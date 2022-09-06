using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExamenPGG.Business.GameObject;

namespace ExamenPGG.UI.ViewModel
{
    public partial class GameControlViewModel : ObservableObject
    {
        public IGame Game { get; set; }
        public GameControlViewModel(IGame game)
        {
            Game = game;
        }

        [RelayCommand]
        private void RollDice()
        {
            // CurrentPlayer.RollDice
        }
    }
}
