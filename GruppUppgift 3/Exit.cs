using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppUppgift_3
{
    class Exit
    {
        public bool IsLocked { get; set; }
        public Room LeadsTo { get; set; }
        private int Id { get; set; }
        
    }
}
