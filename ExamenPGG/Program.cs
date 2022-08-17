using ExamenPGG.Business._00_Interfaces;
using ExamenPGG.Business._01_Classes;


ISquareFactory squareFactory = new SquareFactory();
IGameBoard gameBoard = new GameBoard(squareFactory);
gameBoard.Squares = gameBoard.FillBoard();

foreach (var square in gameBoard.Squares)
{
    Console.WriteLine($" ID: {square.ID} \t SquareType: {square.SquareType.ToString()}");
}

