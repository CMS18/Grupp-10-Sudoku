using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GruppUppgift_3
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            Worldbuilder w = new Worldbuilder("pemis");
            w.NewGame();

            //room2.Exits = doorExits;
            //string play = player1.CurrentPosition.Description;
            //Console.WriteLine(play);
            Console.WriteLine();



            // Game-loop
            //       v
            // skriver ut vad player ser
            //       v
            // skriv ett kommando ( rutiner ) 
            //       v
            // om man blir klar // finished ------------> win
            //       v
            // om inte klar, gå tillbaka till gameloop.

            //Key key = new Key("Rusty key","Rusty");

        }
    }
}
