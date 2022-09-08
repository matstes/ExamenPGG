using ExamenPGG.Business.Logging;
using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares
{
    public class Start : Standard, ISquare
    {
        public Start(int id, ILogger logger) : base(id, logger)
        {
            ID = id;
            SquareType = SquareType.Start;
        }

        public override void HandlePlayer(IPlayer player)
        {
            _logger.LogMessage($"Player {player.Name} starts at squareID: {ID}");
        }
    }
}