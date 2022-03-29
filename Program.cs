using System;
using TextAdventure.Commands;
using TextAdventure.Services;

namespace TextAdventure
{
    class Program
    {

        static void Main(string[] args)
        {
            PlayGame();
        }

        static void PlayGame()
        {
            Console.WriteLine("Initializing Game...");
            var gm = GameManager.Instance;
            gm.Dungeon.LoadSample();
            InputHandler ih = new InputHandler();
            MessageService.WriteMessage("Game Loaded");
            LookCommand.LookRoom();
            while (!gm.GameOver)
            {
                Console.Write("\n>");
                string input = Console.ReadLine();

                ih.ProcessInput(input);
            }
        }
    }
}