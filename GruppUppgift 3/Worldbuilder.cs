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

                while (player1.Alive)
                {
                    Console.WriteLine(player1.CurrentPosition.Name);
                    Console.WriteLine(player1.CurrentPosition.Description);
                    Console.WriteLine($"Choose your next move : ");

                    var command = InputManager.GetUserInput(Console.ReadLine());
                    dostuff(command);
                }
            }
        }

        private void dostuff(string input)
        {
            if (input == "go north" && player1.GetCurrentPosition(player1) == "kitchen")
            {
                player1.ChangePosition(livingRoom);
            }
            else if (input == "go south" && player1.GetCurrentPosition(player1) == "livingroom"  )
            {
                player1.ChangePosition(kitchen);
            }
        }
    }
}
