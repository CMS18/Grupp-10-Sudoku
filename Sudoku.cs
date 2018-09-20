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
                numbersInCol[i] = board[i, col];
            }

            return numbersInCol;
        }

        private int[] GetNumbersInBlock(int row, int col)
        {
            // Beräkna vilket block
            //Hämta siffrorna i blocket rad för rad
            //Hannibal lol
            int[] numbersinblock = new int[9];
            row = (row < 3) ? 0 : ((row < 6) ? 3 : 6);
            col = (col / 3) * 3;
            int count = 0;

            for (int i = row; i < row + 3; i++)
            {
                for (int j = col; j < col + 3; j++)
                {
                    numbersinblock[count] = board[i, j];
                    count++;
                }
            }

            return numbersinblock;


        }

        public int[] FindPossibleNumbers(int row, int col)
        {
            //Hitta möjliga tal för cell utifrån rad, kolumn och block
            //TODO: hitta sifrån från rad, kolumn och blok
            List<int> result = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int[] numbersInRow = GetNumbersInRow(row);
            int[] numbersInCol = GetNumbersInCol(col);
            int[] numbersInBlock = GetNumbersInBlock(row, col);


            foreach (var number in numbersInCol)
            {
                if (result.Contains(number)) result.Remove(number);
            }

            foreach (var number in numbersInRow)
            {
                if (result.Contains(number)) result.Remove(number);
            }
            foreach (var number in numbersInBlock)
            {
                if (result.Contains(number)) result.Remove(number);
            }

            return result.ToArray();
            //int[] _col = GetNumbersInCol(col);
            //int[] _row = GetNumbersInRow(row);
            //int[] _block = GetNumbersInBlock(row, col);
        }

        private bool IsComplete()
        {
            // Loopa igenom alla celler
            //      Om (cell är tom) inte färdig
            //
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (board[row, col] == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void solve()
        {
            //bool unsolvable = true;
            int tries = 0;
            while (IsComplete())
            {
                
                for (int row = 0; row < 9; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {
                        if (board[row, col] == 0)
                        {
                            int[] possibleNumbers = FindPossibleNumbers(row, col);
                            if (possibleNumbers.Length == 1)
                            {
                                board[row, col] = possibleNumbers[0];
                            }
                            else
                            {
                                tries++;
                                if (tries > 500) {
                                    Console.WriteLine("Hittar ingen lösning");
                                    return;

                                }
                            }
                        }

                    }
                }
               
            }
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

