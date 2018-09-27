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

        public static string GetUserInput(string input)
        {
            input = input.ToLower();
            var inputarray = input.Split(' ');
            var output = "";
            
            if (!KeyWords.Contains(inputarray[0]))
            {
                Console.WriteLine("Invalid command");
            }
            if (inputarray[0]=="go")
            {
                output = CheckForGoCommands(inputarray[1]);
            }
            return inputarray[0] + " " + output;
        }

        private static string CheckForGoCommands(string input)
        {
            if (input == "east" || input == "west" || input == "south" || input == "north")
            {
                return input;
            }
            return "Invalid command";
        }
    }
}
