using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.scenerioBased
{
    internal class SnakeAndLadder
    {
        static Random random = new Random();
        static int[] snakeHead = { 17, 54, 62, 64, 87, 93, 94, 99 };

        static int[] snakeTail = { 7, 34, 19, 60, 36, 73, 75, 79 };

        static int[] ladderStart = { 1, 4, 9, 21, 28, 51, 72, 80 };

        static int[] ladderEnd = { 38, 14, 31, 42, 84, 67, 91, 99 };

        public static void Main(string[] args)
        {
            Console.Write("Enter number of players between 2 and 4: ");
            int playerCount = int.Parse(Console.ReadLine());

            if (playerCount < 2 || playerCount > 4)
            {
                Console.WriteLine("Invalid number of players ");
                return; 
            }

            string[] players = new string[playerCount];
            int[] positions = new int[playerCount];

            for (int i = 0; i < playerCount; i++)
            {
                Console.Write("Enter name for Player " + (i + 1) + ": ");
                players[i] = Console.ReadLine();
                positions[i] = 0;
            }

            bool gameWon = false;
            while (!gameWon)
            {
                for (int i = 0; i < playerCount; i++)
                {
                    Console.WriteLine($"\n{players[i]}'s turn. Press Enter to roll dice...");
                    Console.ReadLine();

                    int dice = RollDice();
                    positions[i] = MovePlayer(players[i], positions[i], dice);

                    if (CheckWin(positions[i]))
                    {
                        Console.WriteLine($"\n{players[i]} wins the game!");
                        gameWon = true;
                        break;
                    }
                }
            }
        }

        public static int MovePlayer(string playerName, int position, int dice)
        {
            int newPos = position + dice;

            if (newPos > 100)
            {
                Console.WriteLine($"Dice: {dice} | {playerName}: Move skipped (exceeds 100)");
                return position;
            }

            int finalPos = ApplySnakeOrLadder(newPos);
            string message = GetEventMessage(newPos, finalPos);

            Console.WriteLine($"Dice: {dice} | {playerName}: {position} --> {finalPos} {message}");
            return finalPos;
        }
        //create a method to check snake and ladder positions
        public static int ApplySnakeOrLadder(int position)
        {//if the position of player is equal to ladderstart ,player's position is now at ladderEnd
            for (int i = 0; i < ladderStart.Length; i++)
                if (position == ladderStart[i])
                    return ladderEnd[i];
            //if the position of player is equal to snakestart ,player's position is now at snakeEnd
            for (int i = 0; i < snakeHead.Length; i++)
                if (position == snakeHead[i])
                    return snakeTail[i];

            return position;
        }
        //create a method to get messages
        public static string GetEventMessage(int oldPos, int newPos)
        {
            if (newPos > oldPos)
            {
                return "(Ladder Up)";
            }
            if (newPos < oldPos)
            {
                return "(Snake Down)";
            }
            if (newPos == 100)
            {
                return "(Exact Hit)";
            }
            return "";
        }

        public static int RollDice()
        {
            return random.Next(1, 7);
        }

        public static bool CheckWin(int position)
        {
            if (position == 100)
                return true;
            else
                return false;
        }

    }
}
