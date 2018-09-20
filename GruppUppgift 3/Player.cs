using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppUppgift_3
{
    class Player
    {
        public string Name { get; set; }
        public List<Item> Inventory { get; set; }
        public bool Alive { get; set; }

        public void PickUpItem(Item item)
        {
            Inventory.Add(item);//typ
        }
        public void DropItem(Item item)
        {
            Inventory.Remove(item);
            //Add item to roominventory typ 
        }
        public void UseItem()
        {

        }
    }
}
