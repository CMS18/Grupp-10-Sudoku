using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppUppgift_3
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Function { get; set; }

        public Item()
        {
            
        }
        

        public Item(string name, string description, string function)
        {
            Name = name;
            Description = description;
            Function = function;
        }
      


        public virtual void UseItem()
        {
            ///heuehueheuhe   
        }
        public virtual void DropItem()
        {
            // Ska droppas i rummet du är i
        }
    }
}
