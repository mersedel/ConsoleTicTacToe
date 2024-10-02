using System;
namespace ConsoleTicTacToe
{
    internal class Program
    {
        static byte selectedFieldRow;
        static byte selectedFieldColumn;

        static bool gameIsRunning = true; //тимчасово воно буде true на початку

        static char[,] Field = 
        {
            { '_', '_', '_' },
            { '_', '_', '_' },
            { '_', '_', '_' }
        };


        static void Main(string[] args)
        {
            while (gameIsRunning)
            {
                Console.Clear();
                DrawField();
                FieldCellSelecter();
            }
        }

        static void DrawField()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (row == selectedFieldRow && col == selectedFieldColumn)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"|{Field[row, col]}|");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write($"|{Field[row, col]}|");
                    }
                }
                Console.WriteLine();
            }
        }

        static void FieldCellSelecter()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    if (selectedFieldRow == 0) break;
                    selectedFieldRow--; break;

                case ConsoleKey.DownArrow:
                    if (selectedFieldRow == 2) break;
                    selectedFieldRow++; break;

                case ConsoleKey.LeftArrow:
                    if (selectedFieldColumn == 0) break;
                    selectedFieldColumn--; break;

                case ConsoleKey.RightArrow:
                    if (selectedFieldColumn == 2) break;
                    selectedFieldColumn++; break;
            }
        }

    }
}
