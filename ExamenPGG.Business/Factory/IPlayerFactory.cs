using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares.Factory
{
    public interface IPlayerFactory
    {
        IPlayer CreatePlayer(string name, string iconPath, bool isHuman);
    }
}