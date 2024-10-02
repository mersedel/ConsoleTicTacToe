using System;

namespace ConsoleTicTacToe
{
    internal class Program
    {
        static int col = 0;
        static int row = 0;

        static void Main(string[] args)
        {
            char[,] CellContainer[col, row];
        }

        static void CellPosition(int col, int row)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    col--;
                   return;

                case ConsoleKey.DownArrow:
                    col++;
                   return;

                case ConsoleKey.LeftArrow:
                    row--;
                   return;

                case ConsoleKey.RightArrow:
                    row++;
                   return;

            }
        }*/

        static string Output(int col, int row)
        {
            for (int columnIndex = 0; columnIndex < col; columnIndex++)
            {
                for (int rowIndex = 0; rowIndex < row; rowIndex++)
                {
                    Console.WriteLine(CellPosition(columnIndex, rowIndex));
                }
                rowIndex = 0;
            }
    }
}
