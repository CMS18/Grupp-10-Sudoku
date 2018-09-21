using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GruppUppgift_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Skapa en karaktär ( Player )
            Player player1 = new Player();

            Console.Write("Ge din karaktär ett namn: ");
            player1.Name = Console.ReadLine();

            //skapa ett rum
            Room Köket= new Room("Köket", "Det är vitt kakel, det finns en dörr norr om dig, på golvet ligger en dammig nyckel");
            
            Room room2 = new Room("Vardagsrum","Mörkt och jävligt");

            Key nyckel = new Key("Key", "Den ser dålig ut", null);

            List<Exit> doorExits = new List<Exit>();
            Exit exit1 = new Exit(false, Köket, 1);

            player1.CurrentPosition = Köket;
            while (player1.Alive)
            {
                Console.WriteLine(player1.CurrentPosition.Description);
                string userInput = Console.ReadLine().ToLower();
                if (userInput.Contains("norr"))
                {
                    player1.CurrentPosition = room2;
                    Console.WriteLine($"Du är i {room2.Name},det är {room2.Description}");
                }
                else if (userInput.Contains("pick up") || userInput.Contains("Key"))
                {
                    player1.Inventory.Add(nyckel);
                    Köket.roomItems.Remove(nyckel);
                    Console.WriteLine(nyckel.Description);
                }
                

                
            }

            //room2.Exits = doorExits;
            //string play = player1.CurrentPosition.Description;
            //Console.WriteLine(play);
            Console.WriteLine();



            // Game-loop
            //       v
            // skriver ut vad player ser
            //       v
            // skriv ett kommando ( rutiner ) 
            //       v
            // om man blir klar // finished ------------> win
            //       v
            // om inte klar, gå tillbaka till gameloop.

            //Key key = new Key("Rusty key","Rusty");

        }
    }
}
