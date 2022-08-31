using ExamenPGG.Business.Bootup;
using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.PlayerObject;

Bootup boot = new Bootup();
IGame currentGame = boot.CreateGame(new List<IPlayer>());
currentGame.StartGame();