using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares
{
    public class Cobweb : Standard, ISquare
    {
        public Cobweb(int id) : base(id)
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