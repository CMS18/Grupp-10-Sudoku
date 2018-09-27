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

            Sudoku2 EasyGame = new Sudoku2("003020600900305001001806400" +
                                           "008102900700000008006708200" +
                                           "002609500800203009005010300");


            Sudoku2 MediumGame = new Sudoku2("037060000205000800006908000" +
                                             "000600024001503600650009000" +
                                             "000302700009000402000050360");

            Sudoku2 Diabolical = new Sudoku2("000000000000003085001020000000507000004000100090000000500000073002010000000040009");

            MediumGame.Solve();
            

        }
    }
}
