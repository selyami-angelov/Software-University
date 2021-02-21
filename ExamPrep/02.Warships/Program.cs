using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int matRow = fieldSize;
            int matCol = fieldSize;
            int playerOneShips = 0;
            int playerTwoShips = 0;
            char[,] matrix = new char[matRow, matCol];
            int playerOneSunk = 0;
            int playerTwoSunk = 0;
            List<string> comands = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] fillRow = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {

                    if (fillRow[col] == '<')
                    {
                        playerOneShips++;
                    }
                    else if (fillRow[col] == '>')
                    {
                        playerTwoShips++;
                    }

                    matrix[row,col] = fillRow[col];
                }
            }

            for (int i = 0; i < comands.Count; i++)
            {
                int row = int.Parse(comands[i].Split(" ", StringSplitOptions.RemoveEmptyEntries)[0]);
                int col = int.Parse(comands[i].Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]);

                if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
                {
                    continue;
                }

                if (matrix[row, col] == '#')
                {
                    matrix[row, col] = 'X';

                    if (IsValid(row - 1, col, matrix))
                    {
                        if (matrix[row - 1, col] == '<')
                        {
                            playerOneShips--;
                            playerOneSunk++;
                            matrix[row - 1, col] = 'X';

                        }
                        else if (matrix[row - 1, col] == '>')
                        {
                            playerTwoShips--;
                            playerTwoSunk++;
                            matrix[row - 1, col] = 'X';
                        }
                    }
                    if (IsValid(row - 1, col + 1, matrix))
                    {
                        if (matrix[row - 1, col+1] == '<')
                        {
                            playerOneShips--;
                            playerOneSunk++;
                            matrix[row - 1, col+1] = 'X';
                        }
                        else if (matrix[row - 1, col+1] == '>')
                        {
                            playerTwoShips--;
                            playerTwoSunk++;
                            matrix[row - 1, col + 1] = 'X';
                        }
                    }
                    if (IsValid(row - 1, col - 1, matrix))
                    {
                        if (matrix[row - 1, col-1] == '<')
                        {
                            playerOneShips--;
                            playerOneSunk++;
                            matrix[row - 1, col-1] = 'X';
                        }
                        else if (matrix[row - 1, col-1] == '>')
                        {
                            playerTwoShips--;
                            playerTwoSunk++;
                            matrix[row - 1, col - 1] = 'X';
                        }
                    }
                    if (IsValid(row, col + 1, matrix))
                    {
                        if (matrix[row, col + 1] == '<')
                        {
                            playerOneShips--;
                            playerOneSunk++;
                            matrix[row, col + 1] = 'X';
                        }
                        else if (matrix[row, col +1] == '>')
                        {
                            playerTwoShips--;
                            playerTwoSunk++;
                            matrix[row, col + 1] = 'X';
                        }
                    }
                    if (IsValid(row, col - 1, matrix))
                    {
                        if (matrix[row, col - 1] == '<')
                        {
                            playerOneShips--;
                            playerOneSunk++;
                            matrix[row, col - 1] = 'X';
                        }
                        else if (matrix[row, col - 1] == '>')
                        {
                            playerTwoShips--;
                            playerTwoSunk++;
                            matrix[row, col - 1] = 'X';
                        }
                    }
                    if (IsValid(row + 1, col, matrix))
                    {
                        if (matrix[row+1, col] == '<')
                        {
                            playerOneShips--;
                            playerOneSunk++;
                            matrix[row + 1, col] = 'X';
                        }
                        else if (matrix[row + 1, col] == '>')
                        {
                            playerTwoShips--;
                            playerTwoSunk++;
                            matrix[row + 1, col] = 'X';
                        }
                    }
                    if (IsValid(row + 1, col - 1, matrix))
                    {
                        if (matrix[row + 1, col-1] == '<')
                        {
                            playerOneShips--;
                            playerOneSunk++;
                            matrix[row + 1, col - 1] = 'X';
                        }
                        else if (matrix[row + 1, col - 1] == '>')
                        {
                            playerTwoShips--;
                            playerTwoSunk++;
                            matrix[row + 1, col - 1] = 'X';
                        }
                    }
                    if (IsValid(row + 1, col + 1, matrix))
                    {
                        if (matrix[row + 1, col +1] == '<')
                        {
                            playerOneShips--;
                            playerOneSunk++;
                            matrix[row + 1, col + 1] = 'X';
                        }
                        else if (matrix[row + 1, col + 1] == '>')
                        {
                            playerTwoShips--;
                            playerTwoSunk++;
                            matrix[row + 1, col + 1] = 'X';
                        }
                    }
                }
                else if (IsValid(row,col,matrix))
                {
                    if (matrix[row, col] == '>')
                    {
                        playerTwoShips--;
                        playerTwoSunk++;
                        matrix[row, col] = 'X';
                    }
                    else if (matrix[row, col] == '<')
                    {
                        playerOneShips--;
                        playerOneSunk++;
                        matrix[row, col] = 'X';
                    }
                }
                

                if (playerOneShips == 0)
                {
                    Console.WriteLine($"Player Two has won the game! {playerTwoSunk+playerOneSunk} ships have been sunk in the battle.");
                    return;
                }
                if(playerTwoShips == 0)
                {
                    Console.WriteLine($"Player One has won the game! {playerOneSunk+playerTwoSunk} ships have been sunk in the battle.");
                    return;
                }
            }

            Console.WriteLine($"It's a draw! Player One has {playerOneShips} ships left. Player Two has {playerTwoShips} ships left.");
        }

        public static bool IsValid(int row, int col, char[,] matrix)
        {

            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }


    }
}
