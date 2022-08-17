using ExamenPGG.Business._00_Interfaces;
using ExamenPGG.Business._03_Enums;

namespace ExamenPGG.Business._01_Classes._01_Squares
{
    internal class Square : ISquare
    {
        public int ID { get; set; }
        public SquareType SquareType { get; set; }

        public void HandlePlayer(IPlayer player)
        {
            throw new NotImplementedException();
        }
    }
}
