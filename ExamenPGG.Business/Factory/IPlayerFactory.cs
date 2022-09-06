using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Factory
{
    public interface IPlayerFactory
    {
        IPlayer CreatePlayer(string name, string iconPath, bool isHuman);
    }
}