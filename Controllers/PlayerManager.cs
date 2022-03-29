using System.Collections.Generic;
using TextAdventure.Models;
using TextAdventure.Services;

namespace TextAdventure
{
    public sealed class PlayerManager
    {
        private static PlayerManager instance;
        public static PlayerManager Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new PlayerManager();
                }
                return instance;
            }
        }

        public MessageService ms = new MessageService();

        public Room CurrentRoom { get; set; }
        public List<Item> Inventory { get; set; }

        public PlayerManager()
        {
            CurrentRoom = GameManager.Instance.Dungeon.StartRoom;
            Inventory = DUMMY_ITEMS;
        }

        public void TakeItem(string input)
        {
            foreach (var item in CurrentRoom.Items)
            {
                if (input == item.Name.ToLower())
                {
                    Inventory.Add(item);
                    CurrentRoom.Items.Remove(item);
                    MessageService.WriteMessage($"You take the {item.Name}.");
                    return;
                }
            }
            MessageService.WriteMessage($"You don't see a {input} to take!\n");
        }

        public void DropItem(string input)
        {
            foreach (var item in Inventory)
            {
                if (input == item.Name.ToLower())
                {
                    Inventory.Remove(item);
                    CurrentRoom.Items.Add(item);
                    MessageService.WriteMessage($"You drop the {item.Name}.");
                    return;
                }
            }           
            MessageService.WriteMessage($"You don't have a {input} to drop!\n");
        }
        
        public void DisplayInventory()
        {
            MessageService.WriteMessage("\nInventory:");
            foreach (var i in Inventory)
            {
                MessageService.WriteMessage(i.Name);
            }
            MessageService.WriteMessage("");
        }

        private List<Item> DUMMY_ITEMS = new List<Item>
        {
            new Item
            {
                Name = "Lantern",
                Description = "A worn bronze lantern. It shines dimly through the dirty glass.",
                Weight = 10
            }
        };

        public void Move(Direction direction)
        {
            if (CurrentRoom.Exits.ContainsKey(direction))
            {
                MessageService.WriteMessage($"You move {direction.ToString().ToLower()}.");
                CurrentRoom = CurrentRoom.Exits[direction];
                MessageService.WriteMessage(CurrentRoom.Name);
            } else
            {
                MessageService.WriteMessage($"You are unable to move {direction.ToString().ToLower()} from this room");
            }
        }
    }
}