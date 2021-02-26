using System;
using System.Numerics;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            char[,] matrix = new char[input, input];
            double money = 0;
            int personRow = 0;
            int personCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] curRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (curRow[col] == 'S')
                    {
                        personRow = row;
                        personCol = col;
                    }

                    matrix[row, col] = curRow[col];
                }
            }

            while (money < 50)
            {
                string move = Console.ReadLine();
                matrix[personRow, personCol] = '-';

                if (IsOut(personCol, personRow, move, matrix))
                {
                    break;
                }

                if (move == "up")
                {
                    personRow -= 1;
                }
                else if (move == "down")
                {
                    personRow += 1;
                }
                else if (move == "left")
                {
                    personCol -= 1;
                }
                else if (move == "right")
                {
                    personCol += 1;
                }

                if (matrix[personRow, personCol] == 'O')
                {
                    bool flag = false;
                    matrix[personRow, personCol] = '-';

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (matrix[row, col] == 'O')
                            {
                                matrix[row, col] = 'S';
                                personRow = row;
                                personCol = col;
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
                else if (char.IsDigit(matrix[personRow, personCol]))
                {
                    money += int.Parse(matrix[personRow, personCol].ToString());
                    matrix[personRow, personCol] = 'S';
                }

            }

            if (money < 50)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            else
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {money}");


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }


        }

        public static bool IsOut(int curCol, int curRow, string move, char[,] matrix)
        {
            if (move == "up")
            {
                if (curRow - 1 < 0 || curRow - 1 >= matrix.GetLength(0))
                {
                    return true;
                }
            }
            else if (move == "down")
            {
                if (curRow + 1 < 0 || curRow + 1 >= matrix.GetLength(0))
                {
                    return true;
                }
            }
            else if (move == "left")
            {
                if (curCol - 1 < 0 || curCol - 1 >= matrix.GetLength(1))
                {
                    return true;
                }
            }
            else if (move == "right")
            {
                if (curCol + 1 < 0 || curCol + 1 >= matrix.GetLength(1))
                {
                    return true;
                }
            }

            return false;
        }



    }
}
