using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppUppgift_3
{
    class Key : Item
    {
        private string Name { get; set; }
        private string Description { get; set; }
        private Exit OpenExits { get; set; }

        public Key(string name, string description, Exit openExits)
        {
            Name = name;
            Description = description;
            OpenExits = openExits;
        }

        

    }
}
