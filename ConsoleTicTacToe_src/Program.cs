using System;
namespace ConsoleTicTacToe
{
    internal class Program
    {
        private static byte selectedFieldRow;
        private static byte selectedFieldColumn;

        private static bool gameIsRunning = true;

        private static char[,] Field = 
        {
            { '_', '_', '_' },
            { '_', '_', '_' },
            { '_', '_', '_' }
        };

        private static char currentPlayer = 'X';


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
            Console.WriteLine($"{currentPlayer} Player`s turn:");

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

                case ConsoleKey.Enter:
                    Field[selectedFieldRow, selectedFieldColumn] = currentPlayer;

                    if (currentPlayer == 'X') { currentPlayer = 'O'; break; }
                    if (currentPlayer == 'O') { currentPlayer = 'X'; break; }
                    break;
            }
        }
    }
}
