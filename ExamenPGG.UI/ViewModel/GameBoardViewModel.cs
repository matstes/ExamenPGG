using CommunityToolkit.Mvvm.ComponentModel;
using ExamenPGG.Business.GameObject;

namespace ExamenPGG.UI.ViewModel
{
    public partial class GameBoardViewModel:ObservableObject
    {
        [ObservableProperty]
        private IGame currentGame;

        public GameBoardViewModel(IGame game)
        {
            CurrentGame = game;
        }
    }
}
