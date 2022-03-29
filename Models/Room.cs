using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextAdventure.Models
{
    public class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<Direction, Room> Exits { get; set; }
        public List<Item> Items { get; set; }
        public List<IEntity> Entities { get; set; }
        public bool Visited { get; set; }


        public Room()
        {
            Name = "Unnamed Room";
            Description = "This is an empty room";
            Exits = new Dictionary<Direction, Room>();
            Items = new List<Item>();
            Visited = false;
            Entities = new List<IEntity>();
        }

        public Room(string name, string description, Dictionary<Direction, Room> exits)
        {
            Name = name;
            Description = description;
            Exits = exits;
        }
    }
}