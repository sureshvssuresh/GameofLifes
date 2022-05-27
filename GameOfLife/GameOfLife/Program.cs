using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
     
    class Program
	{
		 
		static void Main(string[] args)
		{


            Console.WriteLine("Hello World Suresh!");
            Console.WriteLine("Enter the no of persons");

            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the position row and column (x y)!");

            Grid grid = new(25, 25);

            for (int i = 0; i < n; i++)
            {
                var position = Console.ReadLine();


                var positions = position.Split(' ');
                int x = Convert.ToInt32(positions[0]);
                int y = Convert.ToInt32(positions[1]);

                grid.Cells[x, y].IsAlive = true;
            }

            Console.WriteLine("Enter generations's population which positions are you interested to see?");
            var gen = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= gen; i++)
            {

                grid.ProcessNextGen();

            }


            for (int i = 0; i < grid.Columns; i++)
                for (int j = 0; j < grid.Rows; j++)
                {
                    if (grid.Cells[i, j].IsAlive)
                        Console.WriteLine($"({i},{j})");
                }
            Console.ReadLine();

		}
	}
}
