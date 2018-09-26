using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppUppgift_3
{
    public class InputManager
    {
        private static List<string> KeyWords = new List<string> { "get", "use", "north", "west",
            "south", "east", "inventory", "drop", "description" };

        public static void GetUserInput(string input)
        {
            input = input.ToLower();
            
            if (!KeyWords.Contains(input))
            {
                Console.WriteLine("Invalid command");
            }



        }


    }
}
