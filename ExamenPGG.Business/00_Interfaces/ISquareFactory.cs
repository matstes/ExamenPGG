using ExamenPGG.Business._03_Enums;

namespace ExamenPGG.Business._00_Interfaces
{
    public interface ISquareFactory
    {
        ISquare CreateSquare(int ID, EnumSquareType SquareType);
    }
}