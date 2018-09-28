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
            "The flooring is white marble, to the east of you there is a fridge" +
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
        public Room bureau = new Room("Old bureau", "Top-shelf contain items");
        public Room fridge = new Room("Fridge", " contains 5-56");
        //Möbler sovrum
        public Room dresser = new Room("dresser", "contains rusty key");




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
            Door Door4 = new Door(true, 4, bathRoom, "west");
            livingRoom.AddExit(Door4);
            //bedroom doors
            Door Door5 = new Door(false, 5, livingRoom, "west");
            bedRoom.AddExit(Door5);
            //Bathroom doors
            Door Door6 = new Door(false, 6, livingRoom, "east");
            bathRoom.AddExit(Door6);

            //item doors eller nåt
            Door Door7 = new Door(false, 7, bureau, "bureau");
            kitchen.AddExit(Door7);
            Door Door8 = new Door(false, 8, fridge, "fridge");
            kitchen.AddExit(Door8);
            Door Door9 = new Door(false, 9, dresser, "dresser");
            bedRoom.AddExit(Door9);
            Door door10 = new Door(false, 10, kitchen, "kitchen");
            fridge.AddExit(door10);

            //  Buraue with items (kitchen)
            Item remote = new Item("tv-remote", "black", "Turns on the tv");
            Item flashlight = new Item("flashlight", "tiny", "Turn on for light");
            bureau.AddItem(remote);
            bureau.AddItem(flashlight);


            // Fridge with clue (kitchen)
            Item RustRemover = new Item("5-56", "check for new clues in the bedroom", "readme");
            fridge.AddItem(RustRemover);

            //Dresser with items (Bed room)
            Key RustyKey = new Key("rusty key", "Opens nothing.. Use 5-56 on me", "Useless", false);
            dresser.AddItem(RustyKey);

            //TODO GÖR OM, RUSTY KEY + 5-56 = SHINY KEY
            //Key ShinyKey = new Key("Shiny key", "Shiny", "opens chest in the oven", true);
            //dresser.AddItem(ShinyKey);


            //bedRoom.roomItems.Add(GoldenKey);


            //TODO Gör så att 5-56 som finns i köket läggs ihop med rusty key som finns i sovrummet, 
            //TODO för att skapa Shiny-key.


        }


        public void NewGame()
        {
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("|" + "\t\t\t\t\t\t|");
                Console.WriteLine("|" + "\t*WELCOME TO THE TEXT ADVENTURE*" + "\t\t|");
                Console.WriteLine("|" + "\t\t\t\t\t\t|");
                Console.WriteLine("-------------------------------------------------");
                //Console.WriteLine("*******************************");
                //Console.WriteLine("*Welcome to the Text Adventure*");
                //Console.WriteLine("*******************************");
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
                    Console.WriteLine(player1.CurrentPosition.Name + "\t\t\t\"HELP\" to enter the command menu");
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

            if (inputArray[0] == "go" || inputArray[0] == "open" || inputArray[0] == "exit")
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
            else if (inputArray[0] == "use")
            {
                useItem(inputArray);
            }
            else
            {
                Console.WriteLine("invalid command");
            }
            // lägg till nya iffar för nyckel ord här, och glöm inte att ändra i inputmanager oxå.
        }

        private void useItem(string[] inputArray)
        {
            if (inputArray[1] == "5-56 on rusty key")
            {
                foreach (var item in player1.Inventory)
                {
               
                    if (item.Name == "5-56")
                    {
                        foreach (var item2 in player1.Inventory)
                        {
                            if (item2.Name == "rusty key")
                            {
                                Key Shinykey = new Key("shiny key", "looks shiny", "Opens bathroom", true);
                                player1.Inventory.Add(Shinykey);
                                Console.WriteLine("Shiny key was added to your inventory!");
                                player1.Inventory.Remove(item2);
                                break;
                            }

                        }

                        break;
                    }
                }
            }
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
                if (item.Position == input && item.Locked == false)
                {
                    room = item.Leadsto;
                    return true;

                }
                else if (item.Position == input && item.Locked == true)
                {
                    Console.WriteLine("The door is locked");
                    room = null;
                    return false;
                }
            }
            room = null;
            return false;
        }
    }
}
