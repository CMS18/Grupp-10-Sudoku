using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppUppgift_3
{
    public class Bureau:Item
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public List<Item> bureauItems { get; set; } = new List<Item>();

        public Bureau(string description,string name)
        {
            Name = name;
            Description = description;
        }
    }
}
