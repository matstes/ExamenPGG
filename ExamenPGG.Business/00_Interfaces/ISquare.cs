using ExamenPGG.Business._03_Enums;

namespace ExamenPGG.Business._00_Interfaces
{
    public interface ISquare
    {
        int ID { get; set; }
        EnumSquareType SquareType { get; set; }

        void HandlePlayer(IPlayer player);
    }
}