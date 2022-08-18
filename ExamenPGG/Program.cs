using ExamenPGG.Business;
using ExamenPGG.Business.Game;


IGameBoard gameBoard = GameBoard.GetInstance();
IDice dice = new Dice();

foreach (var square in gameBoard.Squares)
{
    Console.WriteLine($" ID: {square.ID} \t SquareType: {square.SquareType.ToString()}");
}




