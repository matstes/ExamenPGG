using ExamenPGG.Business.Bootup;
using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.PlayerObject;

//GAMESTATE = BOOT
Bootup boot = new Bootup();
IGame currentGame = boot.CreateGame(new List<IPlayer>());

//GAMESTATE = MAIN LOOP


//GAMESTATE = FINALIZE
//TODO