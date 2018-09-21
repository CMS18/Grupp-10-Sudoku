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
            Sudoku game = new Sudoku("037060000205000800006908000" + 
                                     "000600024001503600650009000" + 
                                     "000302700009000402000050360");




            game.PrintBoard();
            Console.WriteLine();
            game.Solve(game.board);


        }
    }
}
