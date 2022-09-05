using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares.Factory
{
    public class PlayerFactory : IPlayerFactory
    {
        private IGameBoard _gameBoard;

        public PlayerFactory(IGameBoard gameBoard)
        {
            _gameBoard = gameBoard;
        }

        public IPlayer CreatePlayer(string name, string iconPath, bool isHuman)
        {
            return new Player(name, iconPath, isHuman, _gameBoard);
        }
    }
}
