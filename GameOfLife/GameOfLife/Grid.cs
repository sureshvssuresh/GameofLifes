using System;
using System.Linq;

public class Grid
{
    public readonly Cell[,] Cells;

    public int Columns;
    public int Rows;

    public Grid(int row, int column)
    {
        Columns = column;
        Rows = row;

        Cells = new Cell[row, column];
        for (int x = 0; x < column; x++)
            for (int y = 0; y < row; y++)
                Cells[x, y] = new Cell();

        CollectNeighborsAddress();
    }


    private void CollectNeighborsAddress()
    {
        for (int x = 0; x < Columns; x++)
        {
            for (int y = 0; y < Rows; y++)
            {
                bool isLeftEdge = (x == 0);
                bool isRightEdge = (x == Columns - 1);
                bool isTopEdge = (y == 0);
                bool isBottomEdge = (y == Rows - 1);

                int Left = isLeftEdge ? Columns - 1 : x - 1;
                int Right = isRightEdge ? 0 : x + 1;
                int Top = isTopEdge ? Rows - 1 : y - 1;
                int Bottom = isBottomEdge ? 0 : y + 1;

                Cells[x, y].neighbors.Add(Cells[Left, Top]);
                Cells[x, y].neighbors.Add(Cells[x, Top]);
                Cells[x, y].neighbors.Add(Cells[Right, Top]);
                Cells[x, y].neighbors.Add(Cells[Left, y]);
                Cells[x, y].neighbors.Add(Cells[Right, y]);
                Cells[x, y].neighbors.Add(Cells[Left, Bottom]);
                Cells[x, y].neighbors.Add(Cells[x, Bottom]);
                Cells[x, y].neighbors.Add(Cells[Right, Bottom]);
            }
        }
    }

    public void ProcessNextGen()
    {
        foreach (var cell in Cells)
		{
            // Any live cell with fewer than two live neighbours dies(referred to as underpopulation).
            // Any live cell with more than three live neighbours dies(referred to as overpopulation).
            // Any live cell with two or three live neighbours lives, unchanged, to the next generation.
            // Any dead cell with exactly three live neighbours will come to life.

            int liveNeighbors = cell.neighbors.Where(x => x.IsAlive).Count();

            cell.IsAliveNext = (cell.IsAlive && liveNeighbors == 2) || liveNeighbors == 3;
        }

        foreach (var cell in Cells)
            cell.IsAlive = cell.IsAliveNext;
    }
}