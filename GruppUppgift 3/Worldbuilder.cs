using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppUppgift_3
{
    public class Worldbuilder
    {
        public void NewGame()
        {
            // Skapa en karaktär ( Player )
            Player player1 = new Player();

            Console.Write("Give your character a name: ");
            player1.Name = Console.ReadLine();


            //skapa ett rum
            Room Kitchen = new Room("Kitchen", "The flooring is white marble, to the north of you there is a" +
                " vintage-looking mahogany door. On the floor infront of you there is a old key.");


            Room room2 = new Room("Living room", "Dark and fuckery");

            Key key1 = new Key("Key", "Rusty key that seems to unlock... something", null);

            List<Exit> doorExits = new List<Exit>();
            Exit exit1 = new Exit(false, Kitchen, 1);

            player1.CurrentPosition = Kitchen;
            while (player1.Alive)
            {
                Console.WriteLine(player1.CurrentPosition.Description);
                string userInput = Console.ReadLine().ToLower();
                if (userInput.Contains("north"))
                {
                    player1.CurrentPosition = room2;
                    Console.WriteLine($"You are in {room2.Name}, {room2.Description}");
                }
                else if (userInput.Contains("pick up") || userInput.Contains("Key"))
                {
                    player1.Inventory.Add(key1);
                    Kitchen.roomItems.Remove(key1);
                    Console.WriteLine(key1.Description);
                }



            }

        }

    }
}
