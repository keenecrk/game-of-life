using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conway.Library;

namespace Conway.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new LifeGrid();
            grid.CurrentState[1, 2] = CellState.Alive;
            grid.CurrentState[2, 2] = CellState.Alive;
            grid.CurrentState[3, 2] = CellState.Alive;

            ShowGrid(grid.CurrentState);

            while (Console.ReadLine() != "q")
            {
                grid.UpdateState();
                ShowGrid(grid.CurrentState);
            }
        }

        private static void ShowGrid(CellState[,] currentState)
        {
            Console.Clear();
            int x = 0;
            int rowLength = 5;

            foreach (var state in currentState)
            {
                var output = state == CellState.Alive ? "O" : "·";
                Console.Write(output);
                x++;
                if (x >= rowLength)
                {
                    x = 0;
                    Console.WriteLine();
                }
            }
        }
    }
}
