using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares.Types
{
    public class Mystery : Standard, ISquare
    {
        public Mystery(int id) : base(id)
        {
            ID = id;
            SquareType = SquareType.Mystery;
        }

        public override void HandlePlayer(IPlayer player)
        {
            _logger.LogSpecialSquare(this, player);
        }
    }
}