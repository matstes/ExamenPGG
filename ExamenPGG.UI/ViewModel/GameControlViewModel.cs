using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.Logging;

namespace ExamenPGG.UI.ViewModel
{
    public partial class GameControlViewModel : ObservableObject
    {
        [ObservableProperty]
        private IGame game;
        [ObservableProperty]
        private ILogger logger;
        
        public GameControlViewModel(IGame game, ILogger logger)
        {
            Game   = game;
            Logger = logger;
        }

        [RelayCommand]
        private void RollDice()
        {
            Game.ExecuteDiceRoll();
        }
    }
}
