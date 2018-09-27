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
        public string Name { get; set; }
        public Room kitchen = new Room("Kitchen", 
            "The flooring is white marble, to the east of you there is a stove and a fridge" +
            "to the left,\n there is an old bureau, the top shelf is open \n" +
            "to the north, there is a vintage-looking magahony door." ); 

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

            //  Buraue with items (kitchen)
            Item remote = new Item("Tv-remote", "black", "Turns on the tv");
            Item flashlight = new Item("Flashlight", "tiny", "Turn on for light");
            Container buraue = new Container("Old buraue", "Top-shelf contain items");
            buraue.containerItems.Add(remote);
            buraue.containerItems.Add(flashlight);
            kitchen.AddItem(buraue);

            // Fridge with clue (kitchen)
            Item clueSheet = new Item("clue sheet", "check for new clues in the bathroom", "readme");
            Container fridge = new Container("Fridge", " contains clue sheet");
            fridge.containerItems.Add(clueSheet);
            kitchen.AddItem(fridge);

            //Dresser with items (Bed room)
            Key GoldenKey = new Key("golden key", "Shiny", "opens chest in the oven", true);
            Container dresser = new Container("dresser", "contains golden key");
            dresser.containerItems.Add(GoldenKey);
            bedRoom.roomItems.Add(GoldenKey);

            Key RustyKey = new Key("rusty key", "Opens nothing", "Useless", false);
            kitchen.AddItem(RustyKey);

            
          
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
                //Console.WriteLine($"Hi {player1.Name}! Welcome to the Text Adventure V1.02. To start the game," +
                //    $" type in \r\nSTART. To access the command menu, type in \r\nHELP. Enjoy!");

                while (player1.Alive)
                {
                    
                   
                    Console.WriteLine(player1.CurrentPosition.Name + "\t\t\t\t\t\t\t\t\t\tHelp menu \"help\"");
                    Console.WriteLine("***");
                    Console.WriteLine(player1.CurrentPosition.Description);
                    Console.WriteLine("***");
                    Console.Write("Choose your next move: ");

                    var command = InputManager.GetUserInput(Console.ReadLine());
                    DoStuff(command);
                }


                    //}

                    //while (player1.Alive)
                    //{
                    //    if (player1.Alive && "start" == Console.ReadLine().ToLower())
                    //    {
                    //        Console.WriteLine(player1.CurrentPosition.Name);
                    //        Console.WriteLine(player1.CurrentPosition.Description);
                    //        Console.WriteLine($"Choose your next move : ");
                    //        var command = InputManager.GetUserInput(Console.ReadLine());
                    //        DoStuff(command);
                    //        Console.WriteLine();

                    //    }
                    //    else if (player1.Alive && "help" == Console.ReadLine().ToLower())
                    //    {
                    //        Console.WriteLine($"Commands: \r\ngo \r\nsouth \r\nnorth \r\nwest \r\neast" +
                    //        $" \r\nhelp \r\ntake \r\ndrop\r\ninventory");
                    //        Console.WriteLine($"Choose your next move: ");
                    //        var command = InputManager.GetUserInput(Console.ReadLine());
                    //        DoStuff(command);


                    //    }
                    //    else if (player1.Alive)
                    //    {
                    //        Console.WriteLine(player1.CurrentPosition.Name);
                    //        Console.WriteLine(player1.CurrentPosition.Description);
                    //        Console.WriteLine($"Choose your next move : ");
                    //        var command = InputManager.GetUserInput(Console.ReadLine());
                    //        DoStuff(command);
                    //    }
                    //    else
                    //    {
                    //        Console.WriteLine("fel");
                    //    }


                    //}

            }
        }

        private void DoStuff(string input)
        {
            input.ToLower();
            var inputArray = input.Split(' ');
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
            //else if (inputArray[0] == "inspect")
            //{
            //    InspectItem();
            //}
            // lägg till nya iffar för nyckel ord här, och glöm inte att ändra i inputmanager oxå.
        }

        //private void InspectItem()
        //{
        //    foreach (var item in player1.Inventory)
        //    {
                
        //    }
        //}

        private void Dropitem(string[] inputArray)
        {
            bool success = false;
            foreach (var item in player1.Inventory)
            {
                if (inputArray[1] == item.Name || inputArray[1] + " " + inputArray[2] == item.Name)
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
                if (inputArray[1] == item.Name || inputArray[1] + " " + inputArray[2] == item.Name)
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
