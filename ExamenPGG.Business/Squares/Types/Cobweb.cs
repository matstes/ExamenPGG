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
            player.MoveToSquare(39);
            _logger.LogSpecialSquare(this, player);
        }
    }
}