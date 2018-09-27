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
        public Room Leadsto { get; set; }   //en dörr leder ju till 2 rum så har en lista på dem två
        public int DoorId { get; set; }
        public string Position { get; set; }

        public Door(bool locked, int doorId, Room Room1, string position )
        {
            
            Leadsto = Room1;
           

            Locked = locked;
            DoorId = doorId;
            Position = position;
        }
    }
}
