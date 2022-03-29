using TextAdventure.Services;

namespace TextAdventure.Commands
{
    public static class MoveCommand
    {
        static PlayerManager pm = PlayerManager.Instance;
        
        public static void Move(Direction direction)
        {
            if (pm.CurrentRoom.Exits.ContainsKey(direction))
            {
                MessageService.WriteMessage($"You move {direction.ToString().ToLower()}.");
                pm.CurrentRoom = pm.CurrentRoom.Exits[direction];
                MessageService.WriteMessage(pm.CurrentRoom.Name);
                pm.CurrentRoom.Visited = true;
            } else
            {
                MessageService.WriteMessage($"You are unable to move {direction.ToString().ToLower()} from this room");
            }
        }
    }
}