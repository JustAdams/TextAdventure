using System.Collections.Generic;

namespace TextAdventure.Models
{
    public sealed class Dungeon
    {
        public string Name { get; set; }
        List<Room> Rooms { get; set; }
        public Room StartRoom { get; private set; }

        public Dungeon()
        {
        }

        public Dungeon(string name, List<Room> rooms)
        {
            Name = name;
            Rooms = rooms;
        }

        public void LoadSample()
        {
            Name = "Sample Dungeon";
            Rooms = new List<Room>();
            
            Room entryRoom = new Room()
            {
                Name = "Entry Room",
                Description = "You stand in the entry room."
            };
            Room longHallway = new Room()
            {
                Name = "Long Hallway",
                Description = "You find yourself looking down a long hallway."
            };
            Room theVoid = new Room()
            {
                Name = "The Void",
                Description = "You stand in a big empty void."
            };
            
            entryRoom.Exits.Add(Direction.NORTH, longHallway);
            longHallway.Exits.Add(Direction.SOUTH, entryRoom);
            longHallway.Exits.Add(Direction.NORTH, theVoid);
            theVoid.Exits.Add(Direction.SOUTH, longHallway);

            Weapon sword = new Weapon()
            {
                Name = "Sword",
                Description = "A rusted sword",
                Weight = 2,
                Power = 5
            };
            entryRoom.Items.Add(sword);

            Monster troll = new Monster()
            {
                Name = "Troll",
                Description = "A big ugly troll stands here holding a giant club.",
                Health = 25
            };
            longHallway.Entities.Add(troll);

            Rooms.Add(entryRoom);
            Rooms.Add(longHallway);
            Rooms.Add(theVoid);

            StartRoom = entryRoom;
        }
    }
}