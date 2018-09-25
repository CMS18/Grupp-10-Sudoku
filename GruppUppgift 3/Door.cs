using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppUppgift_3
{
    public class Door
    {
        public bool Locked { get; set; }
        public List<Room> Leadsto { get; set; }   //en dörr leder ju till 2 rum så har en lista på dem två
        private int DoorId { get; set; }

        public Door(bool locked, int doorId, Room Room1, Room Room2)
        {
            Leadsto.Add(Room1);
            Leadsto.Add(Room2);

            Locked = locked;
            DoorId = doorId;
        }
    }
}
