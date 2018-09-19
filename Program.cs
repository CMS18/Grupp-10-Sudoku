using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoko_18_09_19
{
    class Program
    {
        static void Main(string[] args)
        {
            Sudoku game = new Sudoku("0370600002050008000069080000" +
                "00600024001503600650009000" +
                "000302700009000402000050360");


            game.PrintBoard();
            Console.WriteLine();
            game.solve();
            game.PrintBoard();




        }
    }
}
