using TextAdventure.Services;

namespace TextAdventure.Commands
{
    public class HelpCommand
    {
        public static void Help()
        {
            MessageService.WriteMessage("Commands:");
            MessageService.WriteMessage("Look <object>, Inventory, Take <object>, Drop <object>");
        }
    }
}