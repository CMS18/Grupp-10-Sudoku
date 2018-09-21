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
            Sudoku gamemedium = new Sudoku("037060000205000800006908000" + 
                                           "000600024001503600650009000" + 
                                           "000302700009000402000050360");

            Sudoku gameeasy = new Sudoku("003020600900305001001806400" +
                                         "008102900700000008006708200" +
                                         "002609500800203009005010300");


            //gameeasy.Solve();
            gamemedium.PrintBoard();
            Console.WriteLine();
            gamemedium.GetTheWolf();
            gamemedium.PrintBoard();
            Console.ReadLine();
            


        }
    }
}
