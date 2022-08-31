using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares
{
    public class Mystery : Standard, ISquare
    {
        private IDice MysteryDice;

        public Mystery(int id, IDice mysteryDice) : base(id)
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
            int random = success.Next(1, 2);
            int rollAmount = 0;

            if (random == 1)
            {
                player.MoveToSquare(0);
            }
            else
            {
                rollAmount = MysteryDice.RollDice(1);
                _logger.LogDiceRoll(player, rollAmount);
                player.MovePlayer(rollAmount);

            }

        }
    }
}