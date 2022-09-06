using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.UI.ViewModel
{
    public class InformationViewModel : BaseViewModel
    {
        public IList<IPlayer> playerList { get; set; }

        public Game Game { get; set; }
        public InformationViewModel(Game game)
        {
            Game = game;
        }
    }
}
