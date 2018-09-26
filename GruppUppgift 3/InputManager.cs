using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppUppgift_3
{
    public class InputManager
    {
        private static List<string> KeyWords = new List<string> { "take", "use", "go", "inventory" };

        public static void GetUserInput(string input)
        {
            input = input.ToLower();
            var inputarray = input.Split(' ');
            
            if (!KeyWords.Contains(input))
            {
                Console.WriteLine("Invalid command");
            }
            if (inputarray[0]=="go")
            {
                CheckForGoCommands(inputarray[1]);
            }
            
        }

        private static void CheckForGoCommands(string input)
        {
            if (input == "east")
            {

            }
            else if (input == "west")
            {

            }
            else if (input == "north")
            {

            }
            else if (input == "south")
            {

            }
        }
    }
}
