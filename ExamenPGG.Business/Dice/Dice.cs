namespace ExamenPGG.Business.DiceObject
{
    public class Dice : IDice
    {
        public Random dice { get; set; }

        public Dice()
        {
            dice = new Random();
        }

        public int RollDice()
        {
            return dice.Next(1, 7);
        }
    }
}