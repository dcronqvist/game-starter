using System;

namespace GameStarter;

public class Program
{
    public static void Main(string[] args)
    {
        var game = new MainGame();
        game.Run(1280, 720, "Game Starter", false, args);
    }
}
