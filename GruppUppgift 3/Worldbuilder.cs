using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppUppgift_3
{
    public class Worldbuilder
    {

        public Player player1 { get; set; } = new Player();
        public List<Room> Rooms { get; set; } = new List<Room>();
        public string Name { get; set; }

        public Worldbuilder(string name)
        {

            Name = name;

            Room livingRoom = new Room("Living room", "Dark and fuckery");
            Room kitchen = new Room("Kitchen",
                "The flooring is white marble, to the north of you there is a" + //spelvärlden skapas upp när man skapar ett 
                " vintage-looking mahogany door. On the floor infront of you there is a old key.");


            player1.ChangePosition(kitchen);

            Door Door1 = new Door(false, 1, livingRoom, "north");                                                           //exits läggs till i rummen
            kitchen.AddExit(Door1);
            Door Door2 = new Door(false, 2, kitchen, "south");
            livingRoom.AddExit(Door2);
            
            

            Key RustyKey = new Key("Rusty key", "Opens nothing", "Useless", false); //items läggs i rummen
            kitchen.roomItems.Add(RustyKey);
            Key GoldenKey = new Key("Golden key", "Shiny", "Opens chest in the oven", true);
            livingRoom.roomItems.Add(GoldenKey);

            Rooms.Add(kitchen);
            Rooms.Add(livingRoom);
        }


        public void NewGame()
        {
            {
                Console.WriteLine("*******************************");
                Console.WriteLine("*Welcome to the Text Adventure*");
                Console.WriteLine("*******************************");
                Console.WriteLine();
                Console.Write("Give your character a name: ");
                player1.Name = Console.ReadLine();

                while (player1.Alive)
                {
                    Console.WriteLine(player1.CurrentPosition.Description);
                    Console.WriteLine($"Choose your next move : ");

                    var command = InputManager.GetUserInput(Console.ReadLine());
                    dostuff(command);

                }







                //TODO: Skriva ut en current position som alltid står högst upp på Consolen, 
                //TODO: Få lite struktur på worldbuilder, ser väldigt stökigt ut.

                //player.CurrentPosition = kitchen;

                //Console.WriteLine(player.CurrentPosition.Description);
                //while (player.Alive)
                //{

                //    string userInput = Console.ReadLine().ToLower();
                //    if (userInput == "north" || userInput == "norr")
                //    {
                //        player.CurrentPosition = livingRoom;
                //        Console.WriteLine($"You are in {livingRoom.Name}, {livingRoom.Description}");
                //    }
                //    if (userInput == "pick up" || userInput == "key")
                //    {
                //        Console.WriteLine("Keytype :" +key1.Name+ "\n" +"Description: "+ key1.Description + "\n" + "Function: " + key1.Function );
                //        player.Inventory.Add(key1);
                //        kitchen.roomItems.Remove(key1);
                //        break;

                //}


            }

        private void dostuff(string input)
        {
            if (input == "go north")
            {
                player1.ChangePosition(Rooms[1]);
            }
            else if (input == "go south" && player1.CurrentPosition == livingRoom )
            {

            }
        }
    }
}
