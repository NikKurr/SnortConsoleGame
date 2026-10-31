using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Snort
{
    public class Grid
    {
        public Cell[,] grid { get;private set; }

        public void CreateEmptyGrid()
        {
            Cell[,] newGrid = new Cell[4, 4];

            for(int i = 0; i < 4; i++) {//moving throw i
                for (int j = 0; j < 4; j++)//moving throw j
                {
                    if ((i == 0 && j == 0) || (i == 0 && j == 3) || (i == 3 && j == 0) || (i == 3 && j == 3))
                        newGrid[i, j] = new Cell(ColorOfCell.notInUse);
                    else
                        newGrid[i, j] = new Cell(ColorOfCell.empty);
                }
            }

            grid = newGrid;
        }

        public Grid()
        {

        }
        public Grid(Cell[,] grid)
        {
            this.grid = grid;
        }

        public Grid CreateACopyOfGrid(Grid gridToCopy)
        {
            Cell[,] newGridCells = new Cell[4, 4];

            for(int i = 0; i < 4; i++)
            {
                for(int j  = 0; j < 4; j++)
                {
                    newGridCells[i, j] = new Cell(gridToCopy.grid[i, j]);
                }
            }

            return new Grid(newGridCells);
        }
    }
}
