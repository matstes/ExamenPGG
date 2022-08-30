using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares
{
    public class Bat : Standard, ISquare
    {
        public Bat(int id) : base(id)
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
