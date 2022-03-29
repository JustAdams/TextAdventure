using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextAdventure.Models
{
    public abstract class Entity : IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}