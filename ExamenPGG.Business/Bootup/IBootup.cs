using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Bootup
{
    public interface IBootup
    {
        string AskPlayerNumber();
        void InitialPlayerNumber();
        string AskPlayerNames();
        void InputPlayerNames();

        IGame CreateGame(List<IPlayer> inputList);
    }
}