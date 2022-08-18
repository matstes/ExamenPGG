using ExamenPGG.Business.Logging;
using ExamenPGG.Business.Player;

namespace ExamenPGG.Business.Squares
{
    public class Standard : ISquare
    {
        public int ID { get; set; }
        public SquareType SquareType { get; set; }
        // DI Add Logger 

        public Standard(int id)
        {
            ID = id;
            SquareType = SquareType.Standard;
           // _logger = logger;
        }

        public void HandlePlayer(IPlayer player)
        {
            Console.WriteLine($"Player {player.Name} entered squareID: {ID}");
        }
    }
}
