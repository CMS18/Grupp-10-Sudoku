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
        public Room livingRoom = new Room("Living room:", "Riddled with cobwebs and everything is covered" +
            " by a thin layer of dust. It appears that no one has been in this room for quite some time.");
        public Room kitchen = new Room("Kitchen:",
                "The flooring is white marble, to the north of you there is a" +
                " vintage-looking mahogany door. On the floor infront of you there is a old key.");

        public Worldbuilder(string name)
        {

            Name = name;


            player1.ChangePosition(kitchen);

            Door Door1 = new Door(false, 1, livingRoom, "north");                                                           //exits läggs till i rummen
            kitchen.AddExit(Door1);
            Door Door2 = new Door(false, 2, kitchen, "south");
            livingRoom.AddExit(Door2);



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
                Console.WriteLine($"Hi {player1.Name}! Welcome to the Text Adventure V1.02. To start the game," +
                    $" type in \r\nSTART. To access the command menu, type in \r\nHELP. Enjoy!");

                while (player1.Alive)
                {

                    Console.WriteLine(player1.CurrentPosition.Name);
                    Console.WriteLine(player1.CurrentPosition.Description);
                    Console.WriteLine($"Choose your next move : ");

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
            if (inputArray[0] == "go")
            {
                if (CheckForDoor(inputArray[1], out Room room))
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
