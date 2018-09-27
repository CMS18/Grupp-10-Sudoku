﻿using System;
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
            "to the left, there is an old bureau, the top shelf is open " +
            "to the north, there is a vintage-looking magahony door." ); 

        public Room livingRoom = new Room("Living room",
               "It is dark and freezing cold, " +
               " you are standing on a rug, it feels like the cold comes from below the rug." +
               " To the north of you there is a couch, a tv and a painting," +
               "to the east there is a door, its slightly open." +
               "To the west there is another door, it is closed, possibly locked.");

        public Room bedRoom = new Room("Bed room",
            "The floor is carpeted in a maroon-red color, to the north of you there is a bed," +
            "to the east there is dresser, " +
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

            Key RustyKey = new Key("Rusty key", "Opens nothing", "Useless", false); //items läggs i rummen
            kitchen.roomItems.Add(RustyKey);
            Key GoldenKey = new Key("Golden key", "Shiny", "Opens chest in the oven", true);
            livingRoom.roomItems.Add(GoldenKey);

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
                    Console.WriteLine(player1.CurrentPosition.Name);
                    Console.WriteLine(player1.CurrentPosition.Description);
                    Console.WriteLine($"Choose your next move : ");

                    var command = InputManager.GetUserInput(Console.ReadLine());
                    DoStuff(command);
                }
            }
        }

        private void DoStuff(string input)
        {
            input.ToLower();
            var inputArray = input.Split(' ');
            if (inputArray[0] == "go")
            {
                if(CheckForDoor(inputArray[1], out Room room))
                {
                    player1.ChangePosition(room);
                }
                else
                {
                    Console.WriteLine("You cannot go there");
                }
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
