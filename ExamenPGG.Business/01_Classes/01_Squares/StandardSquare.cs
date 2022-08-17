using ExamenPGG.Business._00_Interfaces;
using ExamenPGG.Business._03_Enums;

namespace ExamenPGG.Business._01_Classes._01_Squares
{
    internal class StandardSquare : ISquare
    {
        public int ID { get; set; }
        public SquareType SquareType { get; set; }

        public StandardSquare()
        {
            this.SquareType = SquareType.StandardSquare;
        }

        public void HandlePlayer(IPlayer player)
        {
            Console.WriteLine($"Player { player.Name } entered squareID: {this.ID}");
        }
    }
}
