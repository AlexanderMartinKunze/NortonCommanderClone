using System;
using System.Linq;


//Sudoku Background
//Sudoku is a game played on a 9x9 grid. The goal of the game is to fill all cells of the grid with digits from 1 to 9,
//so that each column, each row, and each of the nine 3x3 sub-grids (also known as blocks) contain all of the digits from 1 to 9.
//(More info at: http://en.wikipedia.org/wiki/Sudoku)

//Sudoku Solution Validator
//Write a function validSolution/ValidateSolution/valid_solution() that accepts a 2D array representing a Sudoku board,
//and returns true if it is a valid solution, or false otherwise.
//The cells of the sudoku board may also contain 0's, which will represent empty cells. Boards containing one or more zeroes are considered to be invalid solutions.

//The board is always 9 cells by 9 cells, and every cell only contains integers from 0 to 9.
namespace SodokuValidator
{
    public class Sodoku
    {
        public bool ValidateSolution(int[][] board)
        {
            return Check_lines(board) && Check_squares(board);
        }

        private bool Check_square(int[][] board, int a, int b)
        {
            int[] cube1 = {board[a][b + 2]};
            int[] cube2 = {board[a + 1][b + 2]};
            int[] cube3 = {board[a + 2][b + 2]};

    
            
            
            return cube1.SequenceEqual(cube2) && cube2.SequenceEqual(cube3);
        }

        private bool Check_lines(int[][] board)
        {
            foreach (int[] element in board)
            {
                Array.Sort(element);
                if (!element.SequenceEqual(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9})) return false;
            }

            return true;
        }


        private bool Check_squares(int[][] board)
        {
            return Check_square(board, 0, 0) &&
                   Check_square(board, 0, 3) &&
                   Check_square(board, 0, 6) &&
                   Check_square(board, 3, 0) &&
                   Check_square(board, 3, 3) &&
                   Check_square(board, 3, 6) &&
                   Check_square(board, 6, 0) &&
                   Check_square(board, 6, 3) &&
                   Check_square(board, 6, 6);
        }
    }
}