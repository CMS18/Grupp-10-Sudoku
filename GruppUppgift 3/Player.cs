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
        public bool Alive { get; set; } = true;
        public Room CurrentPosition { get; set; }

        public void CreateCharacter()
        {
            Console.Write("Give your character a name: ");
            string player = Console.ReadLine();
        }
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
