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

        public IPlayer CreatePlayer(string name, bool isHuman)
        {
            return new Player(name, isHuman, _gameBoard);
        }
    }
}
