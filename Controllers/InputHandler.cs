using System;
using TextAdventure.Services;
using TextAdventure.Commands;

namespace TextAdventure
{

    public class InputHandler
    {
        GameManager gm;
        PlayerManager pm;

        public InputHandler()
        {
            gm = GameManager.Instance;
            pm = PlayerManager.Instance;
        }

        public void ProcessInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) { return; }
            var parsedInput = input.ToLower().Split(' ');
            string firstVal = parsedInput[0];

            if (firstVal == "q" || firstVal == "quit") 
            {
                gm.SetGameOver();
                MessageService.WriteMessage("Good-bye!");
            }
            else if (firstVal == "look")
            {
                if (parsedInput.Length == 1 || parsedInput[1] == "room")
                {
                    LookCommand.LookRoom();
                } else if (parsedInput.Length > 1) 
                { 
                    LookCommand.LookTarget(parsedInput[1]); 
                }
            }
            // Player attempts to move in a given direction
            else if (Enum.IsDefined(typeof(Direction), firstVal.ToUpper()))
            {
                Direction direction;
                Enum.TryParse(input.ToUpper(), out direction);
                MoveCommand.Move(direction);
            }
            else if (firstVal == "help")
            {
                HelpCommand.Help();
            }
            else if (firstVal == "inventory" || firstVal == "i")
            {
                pm.DisplayInventory();
            }
            else if (firstVal == "take")
            {
                if (parsedInput.Length > 1) { pm.TakeItem(parsedInput[1]); }
                else { MessageService.WriteMessage("Take what?"); }
            }
            else if (firstVal == "drop")
            {
                if (parsedInput.Length > 1) { pm.DropItem(parsedInput[1]); }
                else { MessageService.WriteMessage("drop what?"); }
            }
            else
            {
                MessageService.WriteMessage($"I don't know what {input} means.");
            }

        }
    }
}