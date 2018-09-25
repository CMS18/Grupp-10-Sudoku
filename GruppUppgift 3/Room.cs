using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppUppgift_3
{
    public class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> roomItems = new List<Item>();
        public List<Door> Exits { get; set; }

        public Room()
        {
            
        }
        public Room(string name, string description)
        {
            Name = name;
            Description = description;
        }
        //public Room(List<Exit> exits)
        //{

        //    List<Exit> Exits = exits;
        //}
        public void AddExit (Door exit)
        {
            Exits.Add(exit);
        }
       

        public void ShowLivingRoom()
        {
            Name = "Living room";
            Description = "Dark and fuckery";

        }
    }
}
