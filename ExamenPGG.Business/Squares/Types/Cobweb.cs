using ExamenPGG.Business.Logging;
using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares
{
    public class Cobweb : Standard, ISquare
    {
        public Cobweb(int id, ILogger logger) : base(id, logger)
        {
            ID = id;
            SquareType = SquareType.Cobweb;
        }

        public override void HandlePlayer(IPlayer player)
        {
            _logger.LogSpecialSquare(this, player);
            player.InActiveTurns += 1;
        }
    }
}