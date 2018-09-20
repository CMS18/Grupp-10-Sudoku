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
        //public List<"items">
        public List<Exit> Exits { get; set; }
    }
}
