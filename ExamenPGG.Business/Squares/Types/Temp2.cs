using ExamenPGG.Business.Logging;
using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares.Types
{
    public class Temp2 : Standard, ISquare
    {
        public Temp2(int id, ILogger logger) : base(id, logger)
        {
            ID = id;
            SquareType = SquareType.Temp2;
        }

        public override void HandlePlayer(IPlayer player)
        {
            Console.WriteLine($"Player {player.Name} entered squareID: {ID}");
        }
    }
}