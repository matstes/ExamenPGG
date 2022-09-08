using ExamenPGG.Business.Logging;
using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares
{
    public class Bat : Standard, ISquare
    {
        public Bat(int id, ILogger logger) : base(id, logger)
        {
            ID = id;
            SquareType = SquareType.Bat;
        }

        public override void HandlePlayer(IPlayer player)
        {
            _logger.LogSpecialSquare(this, player);
            player.MovePlayer(player.LastThrow * player.Direction);
        }
    }
}