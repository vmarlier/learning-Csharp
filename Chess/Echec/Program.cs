using System;
using System.Collections.Generic;


namespace Echec
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Game game = new Game();
            Console.Write("Hi, Welcome to C#ess");
            game.StartGame();
        }
    }
}