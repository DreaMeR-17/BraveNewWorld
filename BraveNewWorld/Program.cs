using System;
using System.Runtime.InteropServices;

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

            char[] bag = new char[1];

            char treasure = '$';
            char empty = '0';
            char wall = '#';
            char player = '@';

            int userX = 2;
            int userY = 2;

            bool isWork = true;

            while (isWork)
            {
                Console.SetCursorPosition(0, 14);
                ShowBag(bag);

                Console.SetCursorPosition(0, 0);
                ShowMap(map);

                Console.SetCursorPosition(userY, userX);
                ShowPlayer(player);

                GetDirection(map, ref userX, ref userY, wall);

                if (map[userX, userY] == treasure)
                {
                    map[userX, userY] = empty;

                    char[] tempBag = new char[bag.Length + 1];

                    for (int i = 0; i < bag.Length; i++)
                    {
                        tempBag[i] = bag[i];
                    }

                    tempBag[tempBag.Length - 1] = treasure;

                    bag = tempBag;
                }
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

        static void GetDirection(char[,] map, ref int userX, ref int userY, char wall)
        {
            const ConsoleKey CommandMoveUp = ConsoleKey.UpArrow;
            const ConsoleKey CommandMoveDown = ConsoleKey.DownArrow;
            const ConsoleKey CommandMoveLeft = ConsoleKey.LeftArrow;
            const ConsoleKey CommandMoveRight = ConsoleKey.RightArrow;

            ConsoleKeyInfo charKey = Console.ReadKey();

            switch (charKey.Key)
            {
                case CommandMoveUp:
                    if (map[userX - 1, userY] != wall)
                    {
                        userX--;
                    }
                    break;

                case CommandMoveDown:
                    if (map[userX + 1, userY] != wall)
                    {
                        userX++;
                    }
                    break;

                case CommandMoveLeft:
                    if (map[userX, userY - 1] != wall)
                    {
                        userY--;
                    }
                    break;

                case CommandMoveRight:
                    if (map[userX, userY + 1] != wall)
                    {
                        userY++;
                    }
                    break;
            }
        }
    }
}
