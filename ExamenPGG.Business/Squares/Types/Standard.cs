using ExamenPGG.Business.Logging;
using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares
{
    public class Standard : ISquare
    {
        public int ID { get; set; }
        public SquareType SquareType { get; set; }

        protected ILogger _logger;

        public Standard(int id, ILogger logger)
        {
            ID = id;
            _logger = logger;
            SquareType = SquareType.Standard;
        }

        public virtual void HandlePlayer(IPlayer player)
        {
            _logger.LogSpecialSquare(this, player);
        }
    }
}