using ExamenPGG.Business._00_Interfaces;
using ExamenPGG.Business._03_Enums;

namespace ExamenPGG.Business._01_Classes._01_Squares
{
    internal class FinalSquare : ISquare
    {
        public int ID { get; set; }
        public SquareType SquareType { get; set; }

        public FinalSquare()
        {
            this.SquareType = SquareType.FinalSquare;
        }

        public void HandlePlayer(IPlayer player)
        {
            Console.WriteLine($"Player {player.Name} reached the EndBoss!");
        }
    }
}
