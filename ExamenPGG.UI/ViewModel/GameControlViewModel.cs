using ExamenPGG.Business.GameObject;

namespace ExamenPGG.UI.ViewModel
{
    public class GameControlViewModel : BaseViewModel
    {
        public Game Game { get; set; }
        public GameControlViewModel(Game game)
        {
            Game = game;
        }
    }
}
