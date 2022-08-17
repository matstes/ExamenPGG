using ExamenPGG.Business.Player;

namespace ExamenPGG.Business.Squares
{
    public class StartSquare : ISquare
    {
        public int ID { get; set; }
        public SquareType SquareType { get; set; }

        public StartSquare(int id)
        {
            ID = id;
            SquareType = SquareType.Start;
        }

        public void HandlePlayer(IPlayer player)
        {
            Console.WriteLine($"Player {player.Name} starts at squareID: {ID}");
        }
    }
}