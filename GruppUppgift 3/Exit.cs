using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppUppgift_3
{
    public class Exit
    {
        public bool Locked { get; set; }
        public Room LeadsTo { get; set; }
        private int DoorId { get; set; }

        public Exit(bool locked, Room leadsTo, int doorId)
        {
            LeadsTo = leadsTo;
            Locked = locked;
            DoorId = doorId;
        }
    }
}
