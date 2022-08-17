using ExamenPGG.Business._00_Interfaces;
using ExamenPGG.Business._03_Enums;

namespace ExamenPGG.Business._01_Classes._01_Squares
{
    public class StartSquare : ISquare
    {
        public int ID { get; set; }
        public SquareType SquareType { get; set; }

        public StartSquare()
        {
            this.SquareType = SquareType.StartSquare;
        }

        public void HandlePlayer(IPlayer player)
        {
            Console.WriteLine($"Player {player.Name} starts at squareID: {this.ID}");
        }
    }
}