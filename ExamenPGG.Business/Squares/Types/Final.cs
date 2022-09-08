using ExamenPGG.Business.Logging;
using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares
{
    public class Final : Standard, ISquare
    {
        public Final(int id, ILogger logger) : base(id, logger)
        {
            ID = id;
            SquareType = SquareType.Final;
        }

        public override void HandlePlayer(IPlayer player)
        {
            _logger.LogMessage($"Player {player.Name} reached the EndBoss!");
        }
    }
}