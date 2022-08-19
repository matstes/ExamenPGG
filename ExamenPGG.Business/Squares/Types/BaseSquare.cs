using ExamenPGG.Business.Logging;
using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares
{
    public abstract class BaseSquare : ISquare
    {
        public int ID { get; set; }
        public SquareType SquareType { get; set; }

        public ILogger _logger = new Logger();
        // TODO Inject loggger

        public BaseSquare(int id)
        {
            ID = id;
            SquareType = SquareType.Standard;
        }

        public virtual void HandlePlayer(IPlayer player)
        {
            _logger.LogMessage($"Player {player.Name} entered squareID: {ID}");
        }
    }
}