using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares
{
    public class Standard : BaseSquare, ISquare
    {
        public Standard(int id) : base(id)
        {
            ID = id;
            SquareType = SquareType.Standard;
        }

        public override void HandlePlayer(IPlayer player)
        {
            _logger.LogMessage($"Player {player.Name} entered squareID: {ID}");
        }
    }
}