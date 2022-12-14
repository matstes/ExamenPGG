using ExamenPGG.Business.DiceObject;
using ExamenPGG.Business.Logging;
using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares
{
    public class Mystery : Standard, ISquare
    {
        private IDice MysteryDice;

        public Mystery(int id, IDice mysteryDice, ILogger logger) : base(id, logger)
        {
            ID = id;
            MysteryDice = mysteryDice;
            SquareType = SquareType.Mystery;
        }

        public override void HandlePlayer(IPlayer player)
        {
            _logger.LogSpecialSquare(this, player);

            //20% death square, 80% extra dobbelsteen

            Random success = new Random();
            int random = success.Next(1, 6);
            int rollAmount = 0;

            if (random == 1)
            {
                player.MoveToSquare(0);
                _logger.LogMysteryDeath(player);
            }
            else
            {
                rollAmount = MysteryDice.RollDice();
                _logger.LogMysteryMove(player, rollAmount);
                player.MovePlayer(rollAmount);
            }
        }
    }
}