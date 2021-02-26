using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rowLen = dimens[0];
            int colLen = dimens[1];
            int[,] matrix = new int[rowLen, colLen];
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<int> flowersPosition = new List<int>();

            while (command[0] != "Bloom")
            {
                int posRow = int.Parse(command[0]);
                int posCol = int.Parse(command[1]);

                if ((posRow < 0 || posRow >= matrix.GetLength(0)) || (posCol < 0 || posCol >= matrix.GetLength(1)))
                {
                    Console.WriteLine("Invalid coordinates.");
                    command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                matrix[posRow, posCol] = 1;
                flowersPosition.Add(posRow);
                flowersPosition.Add(posCol);


                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            Bloom(matrix, flowersPosition);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]+" ");
                }
                Console.WriteLine();
            }
        }

        static public void Bloom(int[,] matrix, List<int> flowersPos)
        {
            for (int i = 0; i < flowersPos.Count; i += 2)
            {
                int row = flowersPos[i];
                int col = flowersPos[i + 1];
                Up(matrix, row, col);
                Left(matrix, row, col);
                Right(matrix, row, col);
                Down(matrix, row, col);

            }

        }

        static public void Up(int[,] matrix, int row, int col)
        {
            for (int i = row - 1; i >= 0; i--)
            {
                matrix[i, col] += 1;
            }
        }
        static public void Left(int[,] matrix, int row, int col)
        {
            for (int i = col - 1; i >= 0; i--)
            {
                matrix[row, i] += 1;
            }
        }
        static public void Right(int[,] matrix, int row, int col)
        {
            for (int i = col + 1; i < matrix.GetLength(0); i++)
            {
                matrix[row, i] += 1;
            }
        }
        static public void Down(int[,] matrix, int row, int col)
        {
            for (int i = row + 1; i < matrix.GetLength(1); i++)
            {
                matrix[i, col] += 1;
            }
        }
    }
}
