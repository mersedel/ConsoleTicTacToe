using System;
namespace ConsoleTicTacToe
{
    internal class Program
    {
        // Tracks the currently selected row and column
        private static byte selectedFieldRow;
        private static byte selectedFieldColumn;

        // Controls the game loop
        private static bool gameIsRunning = true;

        // The tic-tac-toe board, initialized with empty cells
        private static char[,] Field = 
        {
            { '_', '_', '_' },
            { '_', '_', '_' },
            { '_', '_', '_' }
        };

        // Keeps track of whose turn it is ('x' or 'o')
        private static char currentPlayer = 'x';


        static void Main(string[] args)
        {
            // Main game loop
            while (gameIsRunning)
            {
                Console.Clear(); // Clear the console for each frame
                DrawField(); // Draw the current state of the game field
                FieldCellSelecter(); // Allow player to select a cell
            }
        }

        // Method to draw the game field on the console
        private static void DrawField()
        {
            Console.WriteLine(currentPlayer + " Player`s turn:");

            // Loops through each cell and draws it
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    // Highlights the currently selected cell
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

        // Handles user input for selecting a cell and placing their mark
        private static void FieldCellSelecter()
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

                    // Check for a winner after each move
                    WinCheck();
                    DrawCheck(); 

                    // Switches to the other player after the move
                    currentPlayer = currentPlayer == 'x' ? 'o' : 'x';

                    break;
            }
        } 

        // Checks for a winning condition
        private static void WinCheck()
        {
            if (CheckLine(0, 0, 0, 1, 0, 2) ||  // Row 1
                CheckLine(1, 0, 1, 1, 1, 2) ||  // Row 2
                CheckLine(2, 0, 2, 1, 2, 2) ||  // Row 3
                CheckLine(0, 0, 1, 0, 2, 0) ||  // Column 1
                CheckLine(0, 1, 1, 1, 2, 1) ||  // Column 2
                CheckLine(0, 2, 1, 2, 2, 2) ||  // Column 3
                CheckLine(0, 0, 1, 1, 2, 2) ||  // Diagonal 1
                CheckLine(2, 0, 1, 1, 0, 2))    // Diagonal 2
            {
                Console.WriteLine(currentPlayer + " Player Wins!\n\nStart new game? (y/n)");

                ConsoleKey key;
                do
                {
                    key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.Y)
                    {
                        ResetGame(); // Reset the game if the player chooses 'Y'
                        break;
                    }
                    else if (key == ConsoleKey.N)
                    {
                        gameIsRunning = false; // Ends the game if the player chooses 'N'
                        break;
                    }
                } while (key != ConsoleKey.Y && key != ConsoleKey.N);
            }
        }

        // Method to check if a player has formed a winning line
        private static bool CheckLine(int r1, int c1, int r2, int c2, int r3, int c3)
        {
            if (Field[r1, c1] == currentPlayer && Field[r2, c2] == currentPlayer && Field[r3, c3] == currentPlayer)
            {
                HighlightWinningLine(r1, c1, r2, c2, r3, c3);
                return true;
            }
            return false;
        }

        private static void DrawCheck()
        {
            byte occupiedCells = 0;

            foreach (var cell in Field)
            {
                if (cell == 'x' || cell == 'o') occupiedCells++;
            }

            if (occupiedCells == 9)
            {
                Console.WriteLine("It`s a draw!\n\nStart new game? (y/n)");

                ConsoleKey key;
                do
                {
                    key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.Y)
                    {
                        ResetGame(); // Reset the game if the player chooses 'Y'
                        break;
                    }
                    else if (key == ConsoleKey.N)
                    {
                        gameIsRunning = false; // Ends the game if the player chooses 'N'
                        break;
                    }
                } while (key != ConsoleKey.Y && key != ConsoleKey.N);
            }
        }

        // Highlights the winning line with color and capital letters
        private static void HighlightWinningLine(int r1, int c1, int r2, int c2, int r3, int c3)
        {
            Field[r1, c1] = char.ToUpper(Field[r1, c1]);
            Field[r2, c2] = char.ToUpper(Field[r2, c2]);
            Field[r3, c3] = char.ToUpper(Field[r3, c3]);

            Console.Clear();
            DrawFieldWithHighlight(r1, c1, r2, c2, r3, c3);
        }

        // Draws the game field and highlights the winning line in color
        private static void DrawFieldWithHighlight(int r1, int c1, int r2, int c2, int r3, int c3)
        {
            Console.WriteLine(currentPlayer + " Player`s turn:");

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if ((row == r1 && col == c1) || (row == r2 && col == c2) || (row == r3 && col == c3))
                    {
                        Console.BackgroundColor = ConsoleColor.DarkCyan; // Highlight winning cells
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"|{Field[row, col]}|");
                        Console.ResetColor();
                    }
                    else if (row == selectedFieldRow && col == selectedFieldColumn)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray; // Highlight the selected cell
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

        // Resets the game board and switches the starting player
        private static void ResetGame()
        {
            Field = new char[3, 3]
            {
                { '_', '_', '_' },
                { '_', '_', '_' },
                { '_', '_', '_' }
            };

            currentPlayer = 'o';

            selectedFieldRow = 0;
            selectedFieldColumn = 0;

            Console.Clear();
        }
    }
}
