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

        public Room()
        {
            
        }
        public Room(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public Room(List<Exit> exits)
        {

            List<Exit> Ëxits = exits;
        }

        public void ShowKitchen()
        {
            Name = "Kitchen";
            Description = "The flooring is white marble, to the north of you there is a" +
                          " vintage-looking mahogany door. On the floor infront of you there is a old key.";
        }

        public void ShowLivingRoom()
        {
            Name = "Living room";
            Description = "Dark and fuckery";

        }
    }
}
