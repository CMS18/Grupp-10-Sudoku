using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppUppgift_3
{
    public class Worldbuilder
    {

        public Player Player { get; set; } = new Player();
        public List<Room> Rooms { get; set; } = new List<Room>();
        public string Name { get; set; }

        public Worldbuilder(string name)
        {
            Name = name;
            
            Room livingRoom = new Room("Living room", "Dark and fuckery");
            Room kitchen = new Room("Kitchen", "The flooring is white marble, to the north of you there is a" +  //spelvärlden skapas upp när man skapar ett 
            " vintage-looking mahogany door. On the floor infront of you there is a old key.");                  //Worldbuilderobjekt

            Player.ChangePosition(kitchen);

            Door Door1 = new Door(false, 1, livingRoom, kitchen, "north");                                                           //exits läggs till i rummen
            kitchen.AddExit(Door1);
            
            

            Key RustyKey = new Key("Rusty key", "Opens nothing", "Useless", false);                                  //items läggs i rummen
            kitchen.roomItems.Add(RustyKey);
            Key GoldenKey = new Key("Golden key", "Shiny", "Opens chest in the oven", true);
            livingRoom.roomItems.Add(GoldenKey);



        }


        public void NewGame()
        {
            while (Player.Alive)
            {
                Console.WriteLine(Player.CurrentPosition.Description);
                Console.WriteLine("Choose your next move: ");

                InputManager.GetUserInput(Console.ReadLine());
                
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
    }
}
