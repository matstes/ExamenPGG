using ExamenPGG.Business.Player;

namespace ExamenPGG.Business.Squares
{
    public interface ISquare
    {
        int ID { get; set; }
        EnumSquareType SquareType { get; set; }

        void HandlePlayer(IPlayer player);
    }
}