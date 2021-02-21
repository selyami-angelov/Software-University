using System;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int matrRow = matrixSize;
            int matrCol = matrixSize;
            char[,] matrix = new char[matrRow, matrCol];

            int snakeRow = 0;
            int snakeCol = 0;
            int foodQuant = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowFill = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowFill[col];

                    if (rowFill[col]=='S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }



            while (foodQuant<10)
            {
                string command = Console.ReadLine();
                matrix[snakeRow, snakeCol] = '.';
                snakeRow = MoveRow(snakeRow, command);
                snakeCol = MoveCol(snakeCol, command);

                if (!PosCheck(snakeRow,snakeCol,matrix))
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                if (matrix[snakeRow,snakeCol]=='B')
                {

                    matrix[snakeRow, snakeCol] = '.';

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        bool flag = false;

                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (matrix[row,col]=='B')
                            {
                                matrix[row, col] = 'S';
                                snakeRow = row;
                                snakeCol = col;
                                flag = true;
                                break;
                            }
                        }

                        if (flag)
                        {
                            break;
                        }
                    }
                }
                else if (matrix[snakeRow, snakeCol] == '*')
                {
                    matrix[snakeRow, snakeCol] = 'S';
                    foodQuant++;
                }
            }

            if (foodQuant>=10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodQuant}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }

        public static int MoveRow(int row,string comand)
        {
            if (comand == "up")
            {
                return row-=1;
            }
            else if (comand == "down")
            {
                return row+=1;
            }

            return row;
        }
        public static int MoveCol(int col,string comand)
        {
            if (comand == "left")
            {
                return col-=1;
            }
            else if (comand == "right")
            {
                return col+=1;
            }

            return col;
        }

        public static bool PosCheck(int row, int col, char[,] matrix)
        {
            if (row<0 || row>=matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return false;
            }
            return true;
        }
    }
}
