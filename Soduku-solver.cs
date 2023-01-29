using System;
using System.Linq;

class SudokuSolver
{
    static int[,] sudoku = new int[9, 9];

    static bool Solve(int row, int col)
    {
        if (row == 9)
            return true;

        if (sudoku[row, col] != 0)
        {
            if (col == 8)
            {
                if (Solve(row + 1, 0))
                    return true;
            }
            else
            {
                if (Solve(row, col + 1))
                    return true;
            }
            return false;
        }

        for (int num = 1; num <= 9; num++)
        {
            if (IsValid(row, col, num))
            {
                sudoku[row, col] = num;
                if (col == 8)
                {
                    if (Solve(row + 1, 0))
                        return true;
                }
                else
                {
                    if (Solve(row, col + 1))
                        return true;
                }
                sudoku[row, col] = 0;
            }
        }
        return false;
    }

    static bool IsValid(int row, int col, int num)
    {
        for (int i = 0; i < 9; i++)
        {
            if (sudoku[row, i] == num || sudoku[i, col] == num)
                    return false;
        }

        int startRow = row - row % 3;
        int startCol = col - col % 3;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (sudoku[i + startRow, j + startCol] == num)
                    return false;
            }
        }
        return true;
    }

    static void Main(string[] args)
    {
        //Input the Sudoku puzzle
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                sudoku[i, j] = int.Parse(Console.ReadLine());
            }
        }

        if (Solve(0, 0))
        {
            //Print the solution
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(sudoku[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No solution exists");
        }
        Console.ReadLine();
    }
}
