using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppUppgift_3
{
    public class Player
    {
        public string Name { get; set; }
        public List<Item> Inventory { get; set; } = new List<Item>();
        public bool Alive { get; set; } = true;
        public Room CurrentPosition { get; set; }
        public bool exitMenu = true;

        public void ChangePosition(Room NewRoom)
        {
            CurrentPosition = NewRoom;
        }
        public string GetCurrentPosition(Player player1)
        {
            return player1.CurrentPosition.Name;
        }
        public void CheckInventory()
        {
            if (Inventory.Count == 0)
            {
                Console.WriteLine("Your inventory is empty.");
            }
            else
            {
                foreach (var item in Inventory)
                {
                    Console.WriteLine("1. " + item.Name);
                }
            }
        }
        //public void CreateCharacter()
        //{
        //    Console.WriteLine("*******************************");          
        //    Console.WriteLine("*Welcome to the Text Adventure*");            
        //    Console.WriteLine("*******************************");
        //    Console.WriteLine();
        //    Console.Write("Give your character a name: ");
        //     player = Console.ReadLine();
        //    Console.WriteLine();
        //    Console.WriteLine($"{name}, are you ready? y/n");
        //    string svar = Console.ReadLine().ToLower();
        //    if (svar == "y")
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Be careful, be silent and dont make any mistakes.");


        //        Console.ReadLine();
        //    }
        //    else if (svar == "n")
        //    {
        //        for (int i = 0; i < 50000; i++)
        //        {
        //            Console.WriteLine("Coward");
        //        }


        //    }







        //}
        //public void PickUpItem(Item item)
        //{
        //    Inventory.Add(item);//typ
        //}
        //public void DropItem(Item item)
        //{
        //    Inventory.Remove(item);
        //    //Add item to roominventory typ 
        //}
        //public void UseItem()
        //{

        //}
        public void helpMenu()
        {
            while (exitMenu)
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("|" + "\t\t\t\t\t\t|");
                Console.WriteLine("|" + "\t\t***COMMANDS***" + "\t\t\t|");
                Console.WriteLine("|" + "\t\t\t\t\t\t|");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Move north: \"go north\"");
                Console.WriteLine("Move west: \"go west\"");
                Console.WriteLine("Move east: \"go east\"");
                Console.WriteLine("Move south: \"go south\"");
                Console.WriteLine("Pick up item: \"take + \"itemName\" ");
                Console.WriteLine("Drop item: \"drop\" + \"itemName\" ");
                Console.WriteLine("Use item: \"use\" + \"itemName\" ");
                Console.WriteLine("End game: \"end\"");
                Console.WriteLine("***");
                Console.WriteLine("Exit menu: \"exit\"");
                var svar = Console.ReadLine();
                if (svar == "exit")
                {
                    exitMenu = false;
                }
            }

        }
    }
}
