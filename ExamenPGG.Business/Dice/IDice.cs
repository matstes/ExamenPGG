namespace ExamenPGG.Business.DiceObject
{
    public interface IDice
    {
        Random dice { get; set; }

        int RollDice();
    }
}