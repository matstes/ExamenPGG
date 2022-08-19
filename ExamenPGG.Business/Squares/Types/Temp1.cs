using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares.Types
{
    public class Temp1 : Standard, ISquare
    {
        public Temp1(int id) : base(id)
        {
            ID = id;
            SquareType = SquareType.Temp1;
        }

        public override void HandlePlayer(IPlayer player)
        {
            _logger.LogMessage($"Player {player.Name} entered squareID: {ID}");
        }
    }
}