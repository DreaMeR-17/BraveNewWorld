using System;

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

            int userX = 2;
            int userY = 2;

            while (true)
            {
                Console.SetCursorPosition(0, 14);
                ShowBag(bag);

                Console.SetCursorPosition(0, 0);
                ShowMap(map);

                Console.SetCursorPosition(userY, userX);
                Console.Write('@');

                ConsoleKeyInfo charKey = Console.ReadKey();

                switch (charKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (map[userX - 1, userY] != '#')
                        {
                            userX--;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (map[userX + 1, userY] != '#')
                        {
                            userX++;
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (map[userX, userY - 1] != '#')
                        {
                            userY--;
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (map[userX, userY + 1] != '#')
                        {
                            userY++;
                        }
                        break;
                }

                if (map[userX, userY] == '$')
                {
                    map[userX, userY] = '0';

                    char[] tempBag = new char[bag.Length + 1];

                    for (int i = 0; i < bag.Length; i++)
                    {
                        tempBag[i] = bag[i];
                    }

                    tempBag[tempBag.Length - 1] = '$';

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
    }
}
