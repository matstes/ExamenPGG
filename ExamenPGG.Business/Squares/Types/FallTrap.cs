using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares.Types
{
    public class FallTrap : Standard, ISquare
    {
        public FallTrap(int id) : base(id)
        {
            ID = id;
            SquareType = SquareType.FallTrap;
        }

        public override void HandlePlayer(IPlayer player)
        {
            _logger.LogSpecialSquare(this, player);
        }
    }
}