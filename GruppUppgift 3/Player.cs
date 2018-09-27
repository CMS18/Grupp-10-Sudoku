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


        public void ChangePosition (Room NewRoom)
        {
            CurrentPosition = NewRoom;
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

    }
}
