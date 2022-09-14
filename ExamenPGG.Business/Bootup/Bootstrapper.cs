using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Bootup
{
    // This was only used for the console application
    public class Bootstrapper : IBootstrapper
    {
        private IBootup _boot;

        public Bootstrapper(IBootup bootup)
        {
            _boot = bootup;
        }

        public void Run()
        {
            IGame currentGame = _boot.CreateGame(new List<IPlayer>());
            currentGame.StartGame();
        }
    }
}