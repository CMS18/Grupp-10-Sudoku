using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppUppgift_3
{
    public class Container:Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> containerItems { get; set; } = new List<Item>();

        public Container(string name,string description)
        {
            Name = name;
            Description = description;
        }
    }
}
