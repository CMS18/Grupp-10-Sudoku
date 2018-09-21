using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppUppgift_3
{
    class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> roomItems = new List<Item>();
        public List<Exit> Exits { get; set; }

        public Room(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public Room(List<Exit> exits)
        {
           
            List<Exit> Ëxits = exits;
        }
        
    }
}
