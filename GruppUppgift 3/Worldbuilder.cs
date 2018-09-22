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
            /*
                Jag skulle vilja ha en class där vi bara skriver historien, skulle vara enklare att strukturera upp

            */

            // Skapa en karaktär ( Player )
            Player player = new Player();
            player.CreateCharacter();

            //skapa ett rum
                        
            Room livingRoom = new Room("Living room", "Dark and fuckery");
            Room kitchen = new Room("Kitchen", "The flooring is white marble, to the north of you there is a" +
            " vintage-looking mahogany door. On the floor infront of you there is a old key.");

            //Skapar nycklar
            Key key1 = new Key("Rusty key", "Opens nothing", "Useless", false);
            Key key2 = new Key("Golden key", "Shiny", "Opens chest in the oven", true);
           

            List<Exit> doorExits = new List<Exit>();
            Exit exit1 = new Exit(false, kitchen, 1);

            //TODO: Skriva ut en current position som alltid står högst upp på Consolen, 
            //TODO: Få lite struktur på worldbuilder, ser väldigt stökigt ut.
            
            player.CurrentPosition = kitchen;
            
            Console.WriteLine(player.CurrentPosition.Description);
            while (player.Alive)
            {
                
                string userInput = Console.ReadLine().ToLower();
                if (userInput == "north" || userInput == "norr")
                {
                    player.CurrentPosition = livingRoom;
                    Console.WriteLine($"You are in {livingRoom.Name}, {livingRoom.Description}");
                }
                if (userInput == "pick up" || userInput == "key")
                {
                    Console.WriteLine("Keytype :" +key1.Name+ "\n" +"Description: "+ key1.Description + "\n" + "Function: " + key1.Function );
                    player.Inventory.Add(key1);
                    kitchen.roomItems.Remove(key1);
                    break;

                }



            }

        }

       

    }
}
