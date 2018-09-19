using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Sudoko_18_09_19
{
    internal class Sudoku
    {
        private int[,] board = new int[9, 9];


        public Sudoku(string board)
        {
            // put string in board

            // Gå igenom varje bokstav i tecken(char) ( foreach )

            //  Gör om tecken till siffra
            //  Räkna ut och kolumn
            //  Skriva in siffra i cell

            int position = 0;
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    int number = int.Parse(board[position].ToString());
                    SetCellValue(row, col, number);
                    position++;
                }
            }


        }

        private int GetCellValue(int row, int col)
        {
            return board[row, col];

        }

        private void SetCellValue(int row, int col, int value)
        {
            board[row, col] = value;

        }

        public void PrintBoard()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (col == 3 || col == 6)
                    {
                        Console.Write("| ");
                    }
                    int cellValue = GetCellValue(row, col);

                    if (cellValue != 0)
                    {
                        Console.Write(cellValue + " ");
                    }
                    else
                    {
                        Console.Write("_ ");
                    }
                }
                Console.WriteLine();
                if (row == 2 || row == 5)
                {
                    Console.Write("----------------------");
                    Console.WriteLine();
                }
            }
        }




        private bool CellIsEmpty(int row, int col)
        {
            // Hämta värde på cell i rad och kolumn
            // Om (cell == 0) så är den tom
            //
            if (board[row, col] == 0)
            {
                return true;
            }

            return false;
        }

        private int[] GetNumbersInRow(int row)
        {
            //Hämta siffrorna i en rad
            int[] numbersInRow = new int[9];
            for (int i = 0; i < 9; i++)
            {
                numbersInRow[i] = board[row, i];
            }

            return numbersInRow;
        }

        private int[] GetNumbersInCol(int col)
        {
            //Hämta siffrorna i en rad
            int[] numbersInCol = new int[9];
            for (int i = 0; i < 9; i++)
            {
                numbersInCol[i] = board[i, col ];
            }
       
            return numbersInCol;
        }

        private int[] GetNumbersInBlock(int row, int col)
        {
            // Beräkna vilket block
            //Hämta siffrorna i blocket rad för rad
            //Hannibal lol
            row = (row < 3) ? 0 : (row < 6) ? 3 : 6;
            col = (col < 3) ? 0 : (col < 6) ? 3 : 6;
            int[] numbersInBlock = new int[9];
            int count = 0;
            for (int i = row; i < row + 3; i++)
            {
                for (int j = col; j < col + 3; j++)
                {
                    numbersInBlock[count] = board[i, j];
                    count++;
                }
            }

            return numbersInBlock;


        }

        private int[] FindPossibleNumbers()
        {
            //Hitta möjliga tal för cell utifrån rad, kolumn och block
            throw new NotImplementedException();
        }

        private bool IsComplete()
        {
            // Loopa igenom alla celler
            //      Om (cell är tom) inte färdig
            //
            throw new NotImplementedException();
        }

        public void solve()
        {
            //Loopa tills färdig ( inga tomma rutor)
            //{
            //   Loopa igenom alla celler(for-loop nestade rad och kolumn)
            //}
            //      Om cell är tom
            //        Hitta möjliga tal för cell utifrån rad, kolumn och block
            //         Om(noll alternativ för cellen) finns ingen lösning - avbryta
            //         Om (ett alternativ för cellen) skriv in tal i cell
            //         Om (Flera alternativ för cellen) gå vidare
            //         
        }




    }
}

