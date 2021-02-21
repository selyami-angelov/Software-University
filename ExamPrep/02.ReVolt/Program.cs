using System;

namespace _02.ReVolt
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatr = int.Parse(Console.ReadLine());
            int comandsCount = int.Parse(Console.ReadLine());

            int rowSize = sizeOfMatr;
            int colSize = sizeOfMatr;
            char[,] matrix = new char[rowSize, colSize];
            int playerRow = 0;
            int playerCol = 0;
            bool finish = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] filRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = filRow[col];

                    if (filRow[col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            for (int i = 0; i < comandsCount; i++)
            {
                string command = Console.ReadLine();
                if (CheckTrap(playerRow,playerCol,matrix,command))
                {
                    continue;
                }

                matrix[playerRow, playerCol] = '-';

                playerRow = MoveRow(playerRow, command, matrix);
                playerCol = MoveCol(playerCol, command, matrix);

                if (matrix[playerRow,playerCol]=='F')
                {
                    matrix[playerRow, playerCol] = 'f';
                    finish = true;
                    break;
                }
                if (matrix[playerRow, playerCol] == 'B')
                {
                    playerRow = MoveRow(playerRow, command, matrix);
                    playerCol = MoveCol(playerCol, command, matrix);
                    //matrix[playerRow, playerCol] = 'f';

                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = 'f';
                        finish = true;
                        break;
                    }
                    matrix[playerRow, playerCol] = 'f';
                }
                else
                {
                    matrix[playerRow, playerCol] = 'f';
                }
                
            }

            if (finish)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }

        }

        public static bool CheckTrap(int row, int col, char[,] matrix, string comand)
        {
            int checkRow = MoveRow(row, comand, matrix);
            int checkCol = MoveCol(col, comand, matrix);

            if (matrix[checkRow,checkCol] == 'T')
            {
                return true;
            }

            return false;
        }

        public static int MoveRow(int row, string comand, char[,] matrix)
        {
            if (comand == "up")
            {
                if (row - 1 < 0)
                {
                    return matrix.GetLength(0) - 1;
                }
                return row - 1;
            }
            else if (comand == "down")
            {
                if (row + 1 > matrix.GetLength(1) - 1)
                {
                    return 0;
                }

                return row + 1;
            }

            return row;
        }
        public static int MoveCol(int col, string comand, char[,] matrix)
        {

            if (comand == "left")
            {
                if (col - 1 < 0)
                {
                    return matrix.GetLength(1) - 1;
                }

                return col - 1;
            }
            else if (comand == "right")
            {
                if (col + 1 > matrix.GetLength(1) - 1)
                {
                    return 0;
                }

                return col + 1;
            }

            return col;
        }
    }
}
