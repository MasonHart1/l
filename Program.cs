using System;

namespace l
{
    class Program
    {

        //tictactoe board
        static bool p1Turn;
        static string[] arr = new string[9];

        //tictactoe win conditions

        static void Main(string[] args)
        {
            p1Turn = true;
            Console.WriteLine(p1Turn);
            // Replace null or whitespace entries with blank spaces for display
            for (int i = 0; i < arr.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(arr[i]))
                {
                    arr[i] = (i + 1).ToString();
                }
            }

            DrawBoard();
            PlayerTurn();
        }

        static void DrawBoard()
        {
            Console.WriteLine(
            $@"  {arr[0]} | {arr[1]} | {arr[2]}
 ---+---+---
  {arr[3]} | {arr[4]} | {arr[5]}
 ---+---+---
  {arr[6]} | {arr[7]} | {arr[8]}");
        }

        static void PlayerTurn()
        {
            Console.WriteLine(p1Turn ? "Player 1 (X)" : "Player 2 (O)");
            Console.WriteLine("Choose a position (1-9):");

            string input = Console.ReadLine();
            bool isValid = int.TryParse(input, out int position);

            if (!isValid || position < 1 || position > 9)
            {
                Console.WriteLine("Invalid input. Enter a number between 1 and 9.");
                PlayerTurn();
                return;
            }

            int index = position - 1;

            if (arr[index] == "X" || arr[index] == "O")
            {
                Console.WriteLine("That spot is already taken. Try again.");
                PlayerTurn();
                return;
            }

            arr[index] = p1Turn ? "X" : "O";
            p1Turn = !p1Turn;

            DrawBoard();
            CheckIfWin();
            PlayerTurn();
        }


        static void EndGame(string winner)
        {
            Console.WriteLine($"Player {winner} Wins!");
            Thread.Sleep(1000);
        }

        static void CheckIfWin()
        {
            int[][] wins = new int[][]
            {
        new int[] {0, 1, 2},
        new int[] {3, 4, 5},
        new int[] {6, 7, 8},
        new int[] {0, 3, 6},
        new int[] {1, 4, 7},
        new int[] {2, 5, 8},
        new int[] {0, 4, 8},
        new int[] {2, 4, 6}
            };

            foreach (var combo in wins)
            {
                string a = arr[combo[0]];
                string b = arr[combo[1]];
                string c = arr[combo[2]];

                if (a != " " && a == b && b == c)
                {
                    if (a == "X")
                        EndGame("one");
                    else
                        EndGame("two");

                    Environment.Exit(0); // stop the program after someone wins
                }
            }
        }
    }
}