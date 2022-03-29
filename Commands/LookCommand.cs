using System.Text;
using TextAdventure.Services;

namespace TextAdventure.Commands
{
    public class LookCommand
    {
        static PlayerManager pm = PlayerManager.Instance;

        public static void LookRoom()
        {
            MessageService.WriteMessage($"\n{pm.CurrentRoom.Name}");
            MessageService.WriteMessage(pm.CurrentRoom.Description);

            // Display entities
            if (pm.CurrentRoom.Entities.Count > 0)
            {
                foreach (var item in pm.CurrentRoom.Entities)
                {
                    MessageService.WriteMessage($"{item.Name} is here.");
                }
            }

            // Display items
            if (pm.CurrentRoom.Items.Count > 0)
            {
                MessageService.WriteMessage("The room contains:");
                foreach (var item in pm.CurrentRoom.Items)
                {
                    MessageService.WriteMessage(item.Name);
                }
            }
            // Display exits
            if (pm.CurrentRoom.Exits.Count > 0)
            {
                StringBuilder sb = new StringBuilder("Exits:");
                foreach (var exit in pm.CurrentRoom.Exits)
                {
                    sb.Append($" {exit.Key},");
                }
                MessageService.WriteMessage(sb.ToString().Trim(','));
            }
        }

        
        public static void LookTarget(string input)
        {
            foreach (var entity in pm.CurrentRoom.Entities)
            {
                if (input == entity.Name.ToLower())
                {
                    MessageService.WriteMessage(entity.Description);
                    return;
                }
            }
            foreach (var item in pm.CurrentRoom.Items)
            {
                if (input == item.Name.ToLower())
                {
                    MessageService.WriteMessage(item.Description);
                    return;
                }
            }
            foreach (var item in pm.Inventory)
            {
                if (input == item.Name.ToLower())
                {
                    MessageService.WriteMessage(item.Description);
                    return;
                }
            }
            MessageService.WriteMessage($"You don't see a {input}.");
        }
    }
}