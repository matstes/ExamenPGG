using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares.Factory
{
    public interface IPlayerFactory
    {
        IPlayer CreatePlayer(string name, bool isHuman);
    }
}