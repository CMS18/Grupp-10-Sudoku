using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppUppgift_3
{
    class Worldbuilder
    {
        public void NewGame()
        {
            // Skapa en karaktär ( Player )
            Player player = new Player();
            player.CreateCharacter();

            //skapa ett rum
            Room Kitchen = new Room();
            Kitchen.ShowKitchen();

            Room LivingRoom = new Room();
            LivingRoom.ShowLivingRoom();

            Key key1 = new Key("Key", "Rusty key that seems to unlock... something", null);

            List<Exit> doorExits = new List<Exit>();
            Exit exit1 = new Exit(false, Kitchen, 1);

            player.CurrentPosition = Kitchen;
            while (player.Alive)
            {
                Console.WriteLine(player.CurrentPosition.Description);
                string userInput = Console.ReadLine().ToLower();
                if (userInput.Contains("north"))
                {
                    player.CurrentPosition = LivingRoom;
                    Console.WriteLine($"You are in {LivingRoom.Name}, {LivingRoom.Description}");
                }
                else if (userInput.Contains("pick up") || userInput.Contains("Key"))
                {
                    player.Inventory.Add(key1);
                    Kitchen.roomItems.Remove(key1);
                    Console.WriteLine(key1.Description);
                }



            }

        }

       

    }
}
