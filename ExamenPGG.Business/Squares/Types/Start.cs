using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares
{
    public class Start : Standard, ISquare
    {
        public Start(int id) : base(id)
        {
            ID = id;
            SquareType = SquareType.Start;
        }

        public override void HandlePlayer(IPlayer player)
        {
            _logger.LogMessage($"Player {player.Name} starts at squareID: {ID}");
        }
    }
}