namespace ExamenPGG.Business._00_Interfaces
{
    public interface ILogger
    {
        void LogGame(IGame game);
        void LogSpecialSquare(ISquare squareHit);
        void LogMessage(string message);
    }
}