using System;
using System.IO;

namespace BraveNewWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            char[,] map =
            {
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                {'#',' ',' ',' ','#',' ','$',' ','#',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','$',' ','#', },
                {'#',' ',' ',' ','#',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ','#','#','#','#',' ',' ',' ',' ',' ',' ',' ','#',' ',' ','$',' ','#', },
                {'#',' ',' ',' ','#','#','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ','$',' ',' ','$',' ','#',' ',' ','$',' ','#', },
                {'#',' ',' ',' ','#',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ','#',' ',' ','$',' ','#', },
                {'#',' ',' ',' ','#',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ','#',' ','#','#',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ','$',' ','#',' ',' ',' ',' ',' ',' ',' ','#',' ','#',' ',' ','#','#','#','#','#','#','#',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ','#',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ','#',' ','#',' ',' ','#',' ',' ',' ',' ',' ','#',' ',' ',' ',' ','#', },
                {'#',' ','#','#','#','#','#','#','#','#','#','#','#',' ',' ',' ','#',' ',' ',' ',' ','#',' ','$',' ',' ',' ','#',' ',' ',' ',' ','#', },
                {'#',' ','$',' ','#',' ','#','$',' ',' ',' ',' ','#',' ',' ',' ','#',' ','#',' ',' ','#',' ','$',' ',' ',' ','#',' ',' ',' ',' ','#', },
                {'#','$',' ','$','#',' ','#',' ','#',' ','$',' ',' ',' ',' ',' ','#',' ','#','#','#','#',' ','$',' ',' ',' ','#','$','$','$','$','#', },
                {'#',' ','$',' ','#',' ',' ',' ','#',' ',' ','$','#',' ',' ',' ','#',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', }

            };

            char[] bag = new char[0];

            char treasure = '$';
            char empty = '0';
            char wall = '#';
            char player = '@';

            int userPositionX = 2;
            int userPositionY = 2;

            bool isWork = true;

            while (isWork)
            {
                Console.SetCursorPosition(0, 14);
                ShowBag(bag);

                Console.SetCursorPosition(0, 0);
                ShowMap(map);

                Console.SetCursorPosition(userPositionY, userPositionX);
                ShowPlayer(player);

                TryMovePlayer(ref userPositionX, ref userPositionY, map, wall);

                TryTakeTreasure(map, ref userPositionX, ref userPositionY, ref bag, treasure, empty);

                Console.Clear();
            }
        }

        static void ShowMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void ShowBag(char[] bag)
        {
            Console.Write("Сумка: ");

            for (int i = 0; i < bag.Length; i++)
            {
                Console.Write($"{bag[i]} ");
            }
        }

        static void ShowPlayer(char player)
        {
            Console.Write(player);
        }

        static void GetDirection(out int directionX, out int directionY)
        {
            const ConsoleKey CommandMoveUp = ConsoleKey.UpArrow;
            const ConsoleKey CommandMoveDown = ConsoleKey.DownArrow;
            const ConsoleKey CommandMoveLeft = ConsoleKey.LeftArrow;
            const ConsoleKey CommandMoveRight = ConsoleKey.RightArrow;

            ConsoleKeyInfo charKey = Console.ReadKey();

            directionX = 0;
            directionY = 0;

            switch (charKey.Key)
            {
                case CommandMoveUp:
                    directionX--;
                    break;

                case CommandMoveDown:
                    directionX++;
                    break;

                case CommandMoveLeft:
                    directionY--;
                    break;

                case CommandMoveRight:
                    directionY++;
                    break;
            }
        }

        static void TryMovePlayer(ref int userPositionX, ref int userPositionY, char[,] map, char wall)
        {
            GetDirection(out int directionX, out int directionY);

            if (map[userPositionX + directionX, userPositionY + directionY] != wall)
            {
                MovePlayer(ref userPositionX, directionX, ref userPositionY, directionY);
            }
        }

        static void MovePlayer(ref int userPositionX, int directionX, ref int userPositionY, int directionY)
        {
            userPositionX += directionX;
            userPositionY += directionY;
        }

        static void TryTakeTreasure(char[,] map, ref int userPositionX, ref int userPositionY, ref char[] bag, char treasure, char empty)
        {
            if (map[userPositionX, userPositionY] == treasure)
            {
                map[userPositionX, userPositionY] = empty;

                GetNewTreasure(ref bag, treasure);
            }
        }

        static void GetNewTreasure(ref char[] bag, char treasure)
        {
            char[] tempBag = new char[bag.Length + 1];

            for (int i = 0; i < bag.Length; i++)
            {
                tempBag[i] = bag[i];
            }

            tempBag[tempBag.Length - 1] = treasure;

            bag = tempBag;
        }
    }
}
