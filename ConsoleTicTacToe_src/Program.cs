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
            Console.WriteLine(currentPlayer + " Player`s turn:");

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
                    if (Field[selectedFieldRow, selectedFieldColumn] != '_') break;

                    Field[selectedFieldRow, selectedFieldColumn] = currentPlayer;

                    Console.Clear();
                    DrawField();

                    WinCheck();

                    if (currentPlayer == 'X')
                        currentPlayer = 'O';
                    else
                        currentPlayer = 'X';

                    break;
            }
        }

        static void WinCheck()
        {
            if (CheckLine(0, 0, 0, 1, 0, 2) || CheckLine(1, 0, 1, 1, 1, 2) || CheckLine(2, 0, 2, 1, 2, 2) || // Rows
                CheckLine(0, 0, 1, 0, 2, 0) || CheckLine(0, 1, 1, 1, 2, 1) || CheckLine(0, 2, 1, 2, 2, 2) || // Columns
                CheckLine(0, 0, 1, 1, 2, 2) || CheckLine(2, 0, 1, 1, 0, 2))                                 // Diagonals
            {
                Console.WriteLine(currentPlayer + " Wins!\n\nStart new game? (y/n)");

                ConsoleKey key;
                do
                {
                    key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.Y)
                    {
                        ResetGame();
                        break;
                    }
                    else if (key == ConsoleKey.N)
                    {
                        gameIsRunning = false;
                        break;
                    }
                } while (key != ConsoleKey.Y && key != ConsoleKey.N);

            }
        }

        static bool CheckLine(int r1, int c1, int r2, int c2, int r3, int c3)
        {
            return Field[r1, c1] == currentPlayer && Field[r2, c2] == currentPlayer && Field[r3, c3] == currentPlayer;
        }

        static void ResetGame()
        {
            Field = new char[3, 3]
            {
                { '_', '_', '_' },
                { '_', '_', '_' },
                { '_', '_', '_' }
            };

            currentPlayer = 'X';

            selectedFieldRow = 0;
            selectedFieldColumn = 0;

            Console.Clear();
        }
    }
}
