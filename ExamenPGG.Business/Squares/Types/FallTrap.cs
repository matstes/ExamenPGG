using ExamenPGG.Business.Logging;
using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares
{
    public class FallTrap : Standard, ISquare
    {
        public FallTrap(int id, ILogger logger) : base(id, logger)
        {
            ID = id;
            SquareType = SquareType.FallTrap;
        }

        public override void HandlePlayer(IPlayer player)
        {
            _logger.LogSpecialSquare(this, player);
            player.MovePlayer(-(15-2*(8-(ID - (ID / 8) * 8 + 1))));
        }
    }
}