using System;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int rowSize = matrixSize;
            int colSize = matrixSize;
            char[,] matrix = new char[rowSize, colSize];

            int beeRow = 0;
            int beeCol = 0;
            int pollinated = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            string comand = Console.ReadLine();

            while (comand != "End")
            {
                matrix[beeRow, beeCol] = '.';

                beeRow = MoveRow(beeRow,comand);
                beeCol = MoveCol(beeCol,comand);

                if ((beeRow < 0 || beeRow>= matrix.GetLength(0))||(beeCol < 0 || beeCol >= matrix.GetLength(1)))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (matrix[beeRow,beeCol]=='f')
                {
                    pollinated++;
                    matrix[beeRow, beeCol] = '.';
                }
                else if (matrix[beeRow, beeCol] == 'O')
                {
                    matrix[beeRow, beeCol] = '.';
                    beeRow = MoveRow(beeRow, comand);
                    beeCol = MoveCol(beeCol, comand);

                    if (matrix[beeRow, beeCol] == 'f')
                    {
                        pollinated++;
                    }
                }

                matrix[beeRow, beeCol] = 'B';

                comand = Console.ReadLine();
            }

            if (pollinated<5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5-pollinated} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinated} flowers!");
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

        public static int MoveRow(int row,string comand)
        {
            if (comand == "up")
            {
                return row - 1;
            }
            else if (comand == "down")
            {
                return row + 1;
            }

            return row;
            
        }

        public static int MoveCol(int col, string comand)
        {
            
            if (comand == "left")
            {
                return col - 1;
            }
            else if (comand == "right")
            {
                return col + 1;
            }

            return col;
        }
        
    }
}
