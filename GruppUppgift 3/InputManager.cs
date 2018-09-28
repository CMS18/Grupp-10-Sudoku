﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppUppgift_3
{
    public class InputManager
    {
        private static List<string> KeyWords = new List<string> { "take", "use", "go", "inventory", "drop", "description", "help", "inspect" };

        public static string GetUserInput(string input)
        {

            input = input.ToLower();
            var inputarray = input.Split(' ');

            if (inputarray[0] == "go")
            {
                return CheckForGoCommands(inputarray);
            }
            else
            {
                return input;
            }
            
        }

        public static string ArrayToString(string[] inputarray)
        {
            string input = "";
            foreach (var item in inputarray)
            {
                input += item + " ";
            }
            return input;
        }

        private static string CheckForGoCommands(string[] inputarray)
        {
            var output = "";
            if (inputarray.Length == 1 && inputarray[0] == "north" || inputarray[0] == "south" || 
                inputarray[0] == "east" || inputarray[0] == "west" || inputarray[0] == "dresser" ||
                inputarray[0] == "buraue" || inputarray[0] == "fridge")
            {
                return "go" + inputarray[0];
            }
            if (!KeyWords.Contains(inputarray[0]))
            {
                Console.WriteLine("Invalid command");
            }
            if (inputarray[0] == "go")
            {
                output = CheckForGoCommands(inputarray[1]);
            }
            return inputarray[0] + " " + output;


        }
        // vad är detta??????

    //private static string InputHelpList(string input)
    //    {
    //        if (input == "help")
    //        {
    //            Console.WriteLine($"Commands: \r\ngo \r\nsouth \r\nnorth \r\nwest \r\neast" +
    //                $" \r\nhelp \r\ntake \r\ndrop\r\n inventory");
    //        }
    //        return "Invalid command";
    //    }


    private static string CheckForGoCommands(string input)
        {
            if (input == "east" || input == "west" || input == "south" || input == "north" )
            {
                return input;
            }
            return "Invalid command";
        }
    }
}
