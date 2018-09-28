using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GruppUppgift_3
{
    public class Worldbuilder
    {
        public Container container { get; set; } = new Container();
        public Player player1 { get; set; } = new Player();
        public string Name { get; set; }
        public Room kitchen = new Room("Kitchen",
            "The flooring is white marble, to the east of you there is a stove and a fridge" +
            "to the left,\n there is an old bureau, the top shelf is open \n" +
            "to the north, there is a vintage-looking magahony door.");

        public Room livingRoom = new Room("Living room",
               "It is dark and freezing cold, " +
               " you are standing on a rug, it feels like the cold comes from below the rug.\n" +
               " To the north of you there is a couch, a tv and a painting,\n" +
               "to the east there is a door, its slightly open.\n" +
               "To the west there is another door, it is closed, possibly locked.");

        public Room bedRoom = new Room("Bed room",
            "The floor is carpeted in a maroon-red color,\n to the north of you there is a bed," +
            "to the east there is dresser,\n " +
            " to the west there is a painting of some old women in a rocking chair");
        public Room bathRoom = new Room("Bath room",
            "To the north there is a toilet dressed in leather");
        //MÖBLER Kök
        public Room buraue = new Room("Old buraue", "Top-shelf contain items");
        public Room fridge = new Room("Fridge", " contains clue sheet");
        //Möbler sovrum
        public Room dresser = new Room("dresser", "contains golden key");




        public Worldbuilder(string name)
        {

            Name = name;

            player1.ChangePosition(kitchen);
            //kitchendoors
            Door Door1 = new Door(false, 1, livingRoom, "north");                                                           //exits läggs till i rummen
            kitchen.AddExit(Door1);
            //livingroom doors
            Door Door2 = new Door(false, 2, kitchen, "south");
            livingRoom.AddExit(Door2);
            Door Door3 = new Door(false, 3, bedRoom, "east");
            livingRoom.AddExit(Door3);
            Door Door4 = new Door(false, 4, bathRoom, "west");
            livingRoom.AddExit(Door4);
            //bedroom doors
            Door Door5 = new Door(false, 5, livingRoom, "west");
            bedRoom.AddExit(Door5);
            //Bathroom doors
            Door Door6 = new Door(false, 6, livingRoom, "east");
            bathRoom.AddExit(Door6);

            //item doors eller nåt
            Door Door7 = new Door(false, 7, buraue, "buraue");
            kitchen.AddExit(Door7);
            Door Door8 = new Door(false, 8, fridge, "fridge");
            kitchen.AddExit(Door8);
            Door Door9 = new Door(false, 9, dresser, "dresser");
            bedRoom.AddExit(Door9);

            //  Buraue with items (kitchen)
            Item remote = new Item("tv-remote", "black", "Turns on the tv");
            Item flashlight = new Item("flashlight", "tiny", "Turn on for light");
            buraue.AddItem(remote);
            buraue.AddItem(flashlight);


            // Fridge with clue (kitchen)
            Item clueSheet = new Item("clue sheet", "check for new clues in the bathroom", "readme");
            fridge.AddItem(clueSheet);

            //Dresser with items (Bed room)
            Key GoldenKey = new Key("golden key", "Shiny", "opens chest in the oven", true);
            dresser.AddItem(GoldenKey);
            //bedRoom.roomItems.Add(GoldenKey);

            //Key RustyKey = new Key("rusty key", "Opens nothing", "Useless", false);
            //kitchen.AddItem(RustyKey);



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
                Console.Title = "Kitchen";
                Console.WriteLine($"Hi {player1.Name}! \r\nWelcome to the Text Adventure V1.02.\n" +
                    $"Type in \"START\" to begin your new adveture,\r\nEnjoy!");
                var start = Console.ReadLine();
                Console.WriteLine();

                while (player1.Alive && start == "start")
                {
                    //Console.Clear();
                   
                    Console.WriteLine(player1.CurrentPosition.Name + "\t\t\t\t\t\t\t\t\"HELP\" to enter the command menu");
                    Console.WriteLine("***");
                    Console.WriteLine(player1.CurrentPosition.Description);
                    Console.WriteLine();
                    Console.Write("Choose your next move: ");

                    var command = InputManager.GetUserInput(Console.ReadLine());
                    DoStuff(command);
                }

            }
        }

        private void DoStuff(string[] inputArray)
        {
            
            if (inputArray[0] == "help")
            {
                Console.Clear();
                player1.helpMenu();
                Console.Clear();
            }

            if (inputArray[0] == "go")
            {
                MovePlayer(inputArray);
            }
            else if (inputArray[0] == "take")
            {
                TakeItem(inputArray);
            }
            else if (inputArray[0] == "inventory")
            {
                player1.CheckInventory();
            }
            else if (inputArray[0] == "drop")
            {
                Dropitem(inputArray);
            }
            else if (inputArray[0] == "look")
            {
                Console.WriteLine(player1.CurrentPosition.Description);
            }
            else if (inputArray[0] == "inspect")
            {
                InspectItem(inputArray);
            }
            else
            {
                Console.WriteLine("invalid command");
            }
            // lägg till nya iffar för nyckel ord här, och glöm inte att ändra i inputmanager oxå.
        }

        private void InspectItem(string[] inputArray)
        {
            foreach (var item in player1.CurrentPosition.roomItems)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Description);
            }
            //var result = from i in player1.CurrentPosition.roomItems
            //    from j in container.containerItems
            //    where j.Name == inputArray[1]
            //    where i.Name == inputArray[1]
            //    select i.Name.Contains(j.Name);
                    
            //foreach (var i in result)
            //{
            //    Console.WriteLine(i);
            //}

            
        }

        private void Dropitem(string[] inputArray)
        {
            bool success = false;
            foreach (var item in player1.Inventory)
            {
                if (inputArray[1] == item.Name)
                {
                    player1.CurrentPosition.roomItems.Add(item);
                    player1.Inventory.Remove(item);
                    Console.WriteLine("YOU THREW THE " + item.Name + " ON THE GROUND!");
                    success = true;
                    break;
                }
            }
            if (success == false)
            {
                Console.WriteLine("Couldn't drop item :(");
            }
        }

        private void MovePlayer(string[] inputArray)
        {
            if (CheckForDoor(inputArray[1], out Room room))
            {
                player1.ChangePosition(room);
                Console.Title = room.Name;
            }
            else
            {

                Console.WriteLine("You cannot go there");

            }
        }

        private void TakeItem(string[] inputArray)
        {
            bool SuccesfullItemPickup = false;
            foreach (var item in player1.CurrentPosition.roomItems)
            {
                if (inputArray[1] == item.Name)
                {
                    player1.Inventory.Add(item);
                    player1.CurrentPosition.roomItems.Remove(item);
                    Console.WriteLine(item.Name + " was added to your inventory.");
                    SuccesfullItemPickup = true;
                    break;
                }

            }
            if (SuccesfullItemPickup == false)
            {
                Console.WriteLine("You cannot do that...");
            }

        }
        public bool CheckForDoor(string input, out Room room)
        {
            foreach (var item in player1.CurrentPosition.Exits)
            {
                if (item.Position == input)
                {
                    room = item.Leadsto;
                    return true;

                }
            }
            room = null;
            return false;
        }
    }
}
