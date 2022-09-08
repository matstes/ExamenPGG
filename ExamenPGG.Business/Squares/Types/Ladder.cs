using ExamenPGG.Business.Logging;
using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares
{
    public class Ladder : Standard, ISquare
    {
        public Ladder(int id, ILogger logger) : base(id, logger)
        {
            ID = id;
            SquareType = SquareType.Ladder;
        }

        public override void HandlePlayer(IPlayer player)
        {
            _logger.LogSpecialSquare(this, player);
            player.MovePlayer(15-2*(ID-(ID/8)*8));
        }

    }
}