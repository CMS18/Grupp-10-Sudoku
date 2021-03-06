﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GruppUppgift_3
{
    public class Worldbuilder
    {

        public Player player1 { get; set; } = new Player();
        public string Name { get; set; }

        // Skapar rummen
        public Room kitchen = new Room("Kitchen",
            "The flooring is white marble, to the east of you there is a fridge " +
            "to the left,\nthere is an old bureau, the top shelf is open \n" +
            "to the north, there is a vintage-looking magahony door.");

        public Room livingRoom = new Room("Living room",
               "It is dark and freezing cold, " +
               "you are standing on a rug, it feels like the cold comes from below the rug.\n" +
               "To the north of you there is a couch, a tv and a painting,\n" +
               "to the east there is a door, its slightly open.\n" +
               "To the west there is another door, it is closed, possibly locked.");

        public Room bedRoom = new Room("Bed room",
            "The floor is carpeted in a maroon-red color,\n to the north of you there is a bed," +
            "to the east there is dresser,\n " +
            "to the west there is a painting of some old women in a rocking chair");
        public Room bathRoom = new Room("Bath room",
            "To the north there is a toilet dressed in leather");
        //Möbler Kök
        public Room bureau = new Room("Old bureau", "Type: \"Inspect\"");
        public Room fridge = new Room("Fridge", "Type: \"Inspect\"");
        //Möbler sovrum
        public Room dresser = new Room("dresser", "Type: \"Inspect\"");
        //Möbler badrum
        public Room toilet = new Room("Toilet", "Golden, dressed in leather");



        public Worldbuilder(string name)
        {

            Name = name;
            // alla dörrar
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

            //"furniture doors" eller nåt
            Door Door7 = new Door(false, 7, bureau, "bureau");
            kitchen.AddExit(Door7);
            Door Door8 = new Door(false, 8, fridge, "fridge");
            kitchen.AddExit(Door8);

            Door Door9 = new Door(false, 9, dresser, "dresser");
            bedRoom.AddExit(Door9);
            Door door10 = new Door(false, 10, kitchen, "kitchen");
            fridge.AddExit(door10);
            Door door11 = new Door(false, 11, bedRoom, "bedroom");
            dresser.AddExit(door11);
            Door door12 = new Door(false, 12, kitchen, "kitchen");
            bureau.AddExit(door12);
            Door door13 = new Door(false, 13, kitchen, "fridge");
            fridge.AddExit(door13);
            Door door14 = new Door(false, 14, bedRoom, "dresser");
            dresser.AddExit(door14);



            //  Buraue with items (kitchen)
            Item remote = new Item("tv-remote", "black", "Turns on the tv");
            Item flashlight = new Item("flashlight", "tiny", "Turn on for light");
            bureau.AddItem(remote);
            bureau.AddItem(flashlight);


            // Fridge with clue (kitchen)
            Item RustRemover = new Item("5-56", "Powerful rustremover!", "Do not drink!");
            fridge.AddItem(RustRemover);

            //Dresser with items (Bed room)
            Key RustyKey = new Key("rusty key", "Opens nothing.. Use 5-56 on me", "Useless", 56);
            dresser.AddItem(RustyKey);

        }

        public void NewGame(bool newgame = true)
        {
            {
                // start meny
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("|" + "\t\t\t\t\t\t|");
                Console.WriteLine("|" + "\t*WELCOME TO THE TEXT ADVENTURE*" + "\t\t|");
                Console.WriteLine("|" + "\t\t\t\t\t\t|");
                Console.WriteLine("-------------------------------------------------");

                Console.WriteLine();
                Console.Write("Give your character a name: ");
                player1.Name = Console.ReadLine();
                Console.Title = "Kitchen";
                Console.WriteLine($"Hi {player1.Name}! \r\nWelcome to the Text Adventure V1.02.\n" +
                    $"Type in \"START\" to begin your new adventure,\r\nEnjoy!"
                    );
                string start = "";
                while (start != "start")
                {
                    start = Console.ReadLine();
                    if (start == "help")
                    {
                        player1.helpMenu();
                    }
                }
                Console.Clear();
                Console.WriteLine();
                // spelet börjar
                while (player1.Alive && player1.GottaPoo && start == "start")
                {
                    //Console.Clear();
                    Console.WriteLine();
                    //Console.WriteLine(player1.CurrentPosition.Name + "\t\t\t\t\t\t\t\t\t" + "\"HELP\" to enter the command menu"); tidigare C.WL
                    Console.WriteLine("***");
                    Console.WriteLine(player1.CurrentPosition.Name);
                    Console.WriteLine("***");
                    Console.WriteLine(player1.CurrentPosition.Description);
                    Console.WriteLine();
                    Console.Write("Choose your next move: ");

                    var command = InputManager.GetUserInput(Console.ReadLine());
                    DoStuff(command);
                }

            }
        }
        // Kommandon
        private void DoStuff(string[] inputArray)
        {

            if (inputArray[0] == "help")
            {
                Console.Clear();
                player1.helpMenu();
                Console.Clear();
            }

            else if (inputArray[0] == "cheat")
            {
                player1.cheatMenu();
                Console.Clear();
            }

            if (inputArray[0] == "go" || inputArray[0] == "open" || inputArray[0] == "exit" || inputArray[0] == "close")
            {
                MovePlayer(inputArray);
            }
            else if (inputArray[0] == "sit")
            {
                SitToWin(inputArray);
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
                InspectFurniture(inputArray);
            }
            else if (inputArray[0] == "use")
            {
                useItem(inputArray);
            }
            else
            {
                Console.WriteLine("invalid command");
            }
        }
        //Metoder
        private void SitToWin(string[] inputArray)
        {
            if (inputArray[1] == "on toilet")
            {
                Console.Beep(2000, 200);
                Console.Beep(1000, 200);
                Console.Beep(500, 200);
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("|" + "\t\t\t\t\t\t|");
                Console.WriteLine("|" + "\t\t***VICTORY!***" + "\t\t\t|");
                Console.WriteLine("|" + "\t\t\t\t\t\t|");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Victory!");
                Console.ReadLine();
                Authors.WhileVictoryEqualsTrue();
                Console.WriteLine("Do you want to play again? y/n");
                string playAgain = Console.ReadLine().ToLower();
                if (playAgain == "y")
                { NewGame(); }

                if (playAgain == "n")
                {
                    player1.GottaPoo = false;
                }


            }
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
                                Key Shinykey = new Key("shiny key", "looks shiny", "Opens bathroom", 4);
                                player1.Inventory.Add(Shinykey);
                                Console.WriteLine("-------------------------------------------------");
                                Console.WriteLine("|" + "\t\t\t\t\t\t|");
                                Console.WriteLine("|" + " Shiny key has been added to your inventory!" + "\t|");
                                Console.WriteLine("|" + "\t\t\t\t\t\t|");
                                Console.WriteLine("-------------------------------------------------");
                                Console.WriteLine("Shiny key was added to your inventory!");
                                player1.Inventory.Remove(item2);
                                dresser.Description = "Empty";
                                break;
                            }

                        }

                        break;
                    }
                }
            }
            else if (inputArray[1] == "shiny key on door")
            {
                if (player1.CurrentPosition == livingRoom)
                {
                    foreach (Door item in livingRoom.Exits)
                    {
                        if (item.DoorId == 4)
                        {
                            item.Locked = false;
                            Console.WriteLine();
                            Console.WriteLine("-------------------------------------------------");
                            Console.WriteLine("|" + "\t\t\t\t\t\t|");
                            Console.WriteLine("|\t" + "Bathroom door has been unlocked!" + "\t|");
                            Console.WriteLine("|" + "\t\t\t\t\t\t|");
                            Console.WriteLine("-------------------------------------------------");
                            Console.WriteLine("Bathroom door was unlocked\n");
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("You cannot do that!");
                Console.WriteLine();
            }
        }

        private void InspectFurniture(string[] inputArray)
        {
            if (player1.CurrentPosition.roomItems.Count == 0)
            {
                Console.WriteLine(player1.CurrentPosition.Name + " Is Empty");
            }
            else
            {
                Console.WriteLine("\n" + player1.CurrentPosition.Name + " " + "contains: ");
                foreach (var item in player1.CurrentPosition.roomItems)
                {
                    Console.WriteLine(item.Name + " " + "\t\t\t\t" + item.Description);
                }
                Console.WriteLine();
            }
        }

        private void InspectItem(string[] inputArray)
        {
            foreach (var item in player1.CurrentPosition.roomItems)
            {
                Console.WriteLine(item.Description);
            }
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
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("\t\t" + item.Name + " has been added to your inventory!");
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------------------------------------------");
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
                    Console.WriteLine();
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
