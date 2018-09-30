using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Sudoko_18_09_19
{
    class Sudoku2
    {
        private readonly int[,] Sudoku = new int[9, 9];

        public Sudoku2 (String Numbers)
        {
            Numbers = Regex.Replace(Numbers, "[^1-9]", "0");
            int stringposition = 0;
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    int number = int.Parse(Numbers[stringposition].ToString());
                    Sudoku[row, col] = number;
                    stringposition++;
                }
            }
        }
        private List<int> GetNumbersInRow(int row, int[,]Board)
        {
            List<int> NumbersInRow = new List<int>();
            for (int i = 0; i < 9; i++)
            {
                if (Board[row, i] != 0)
                {
                    NumbersInRow.Add(Board[row, i]);
                }                
            }
            return NumbersInRow;
        }
        private List<int> GetNumbersInCol(int col, int[,] Board)
        {
            List<int> NumbersInCol = new List<int>();
            for (int i = 0; i < 9; i++)
            {
                if (Board[i, col] != 0)
                {
                    NumbersInCol.Add(Board[i, col]);
                }
            }
            return NumbersInCol;
        }
        private List<int> GetNumbersInBlock(int row, int col, int [,]Board)
        {
            List<int> NumbersInBlock = new List<int>();
            row = (row / 3) * 3;
            col = (col / 3) * 3;
            for (int i = row; i < row+3; i++)
            {
                for (int j = col; j < col+3; j++)
                {
                    if (Board[i,j] != 0)
                    {
                        NumbersInBlock.Add(Board[i, j]);
                    } 
                }
            }
            return NumbersInBlock;
        }
        private List<int> FindPossibleNumbers(int row, int col, int[,] Board)
        {
            List<int> NumbersInRow = GetNumbersInRow(row, Board);
            List<int> NumbersInCol = GetNumbersInCol(col, Board);
            List<int> NumbersInBlock = GetNumbersInBlock(row, col, Board);
            NumbersInRow.AddRange(NumbersInCol);
            NumbersInRow.AddRange(NumbersInBlock);
            List<int> PossibleNumbers = new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9};
            foreach (var item in NumbersInRow)
            {
                if (PossibleNumbers.Contains(item)) PossibleNumbers.Remove(item);
            }
            return PossibleNumbers;          
        }
        private bool CheckIfComplete (int[,]Board)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (Board[row,col]== 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void PrintBoard(int[,]Board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (j == 3 || j == 6)
                    {
                        Console.Write("| ");
                    }
                    Console.Write(Board[i, j] + " ");
                }
                Console.WriteLine();
                if (i == 2 || i == 5)
                {
                    Console.Write("----------------------");
                    Console.WriteLine();
                }
            }
        }
        public void Solve ()
        {
            PrintBoard(Sudoku);
            Console.WriteLine();
            SolveNumbers(Sudoku);

        }
        private bool SolveNumbers(int[,] Board)
        {
            for (int i = 1; i < 10; i++)
            {
                for (int row = 0; row < 9; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {
                        if (Board[row,col]==0)
                        {
                            var PossibleNumbers = FindPossibleNumbers(row, col, Board);
                            if (PossibleNumbers.Count == i)
                            {
                                return GuessNumbers(row, col, PossibleNumbers, Board);
                            }
                        }
                    }
                }
            }
            return true;
        }

        private bool GuessNumbers(int row, int col, List<int> Possiblenumbers, int[,]Board)
        {
            for (int Guess = 1; Guess < 10; Guess++)
            {
                if (Possiblenumbers.Contains(Guess))
                {
                    Board[row, col] = Guess;
                    if (SolveNumbers(Board))
                    {
                        if (CheckIfComplete(Board))
                        {
                            Console.WriteLine("Lösning hittad!:\n");
                            PrintBoard(Board);
                            Console.ReadLine();
                            return true;
                        }
                    }
                }
            }
            Board[row, col] = 0;
            return false;
        }
    }
}
