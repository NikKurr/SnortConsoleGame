using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snort
{
    public class GameState
    {
        private Grid _grid;

        private User _user;

        public GameState(Grid grid, User user)
        {
            _grid = grid;
            _user = user;
        }

        public void ChangePlayerMove()
        {
            _user.UserMove = _user.UserMove == true ? false : true;
        }
        public GameState CopyOfGrid()
        {

            if (_grid != null && _user != null)
            {
                Grid newGrid = _grid.CreateACopyOfGrid(_grid);
                User newUser = new User(_user);

                return new GameState(newGrid, newUser);
            }
            else
                throw new Exception("Can't copy current state, no state was created yet!");
        }

        public ColorOfCell GetCellColor(int row, int col)
        {
            return _grid.grid[row, col].ColorOfCell;
        }
        public bool CheckIfAnyColor(Tuple<int, int> cord)
        {
            if (_grid.grid[cord.Item1, cord.Item2].ColorOfCell != ColorOfCell.empty)
            {
                return true;//if there is anything but no an empty cell
            }

            return false;
        }

        public bool CheckIfNoNeighbors(Tuple<int, int> cord, ColorOfCell currnetColor)
        {
            Tuple<int, int> Down = new Tuple<int, int>(cord.Item1 - 1, cord.Item2);

            if (!CheckIfNotOutsideTheRange(Down))
            {
                if (_grid.grid[Down.Item1, Down.Item2].ColorOfCell != ColorOfCell.notInUse && _grid.grid[Down.Item1, Down.Item2].ColorOfCell != ColorOfCell.empty && _grid.grid[Down.Item1, Down.Item2].ColorOfCell != currnetColor)
                {
                    return false;
                }
            }//Down Check

            Tuple<int, int> Up = new Tuple<int, int>(cord.Item1 + 1, cord.Item2);

            if (!CheckIfNotOutsideTheRange(Up))
            {
                if (_grid.grid[Up.Item1, Up.Item2].ColorOfCell != ColorOfCell.notInUse && _grid.grid[Up.Item1, Up.Item2].ColorOfCell != ColorOfCell.empty && _grid.grid[Up.Item1, Up.Item2].ColorOfCell != currnetColor)
                {
                    return false;
                }
            }//Up check

            Tuple<int, int> Left = new Tuple<int, int>(cord.Item1, cord.Item2 - 1);

            if (!CheckIfNotOutsideTheRange(Left))
            {
                if (_grid.grid[Left.Item1, Left.Item2].ColorOfCell != ColorOfCell.notInUse && _grid.grid[Left.Item1, Left.Item2].ColorOfCell != ColorOfCell.empty && _grid.grid[Left.Item1, Left.Item2].ColorOfCell != currnetColor)
                {
                    return false;
                }
            }//Left check

            Tuple<int, int> Right = new Tuple<int, int>(cord.Item1, cord.Item2 + 1);

            if (!CheckIfNotOutsideTheRange(Right))
            {
                if (_grid.grid[Right.Item1, Right.Item2].ColorOfCell != ColorOfCell.notInUse && _grid.grid[Right.Item1, Right.Item2].ColorOfCell != ColorOfCell.empty && _grid.grid[Right.Item1, Right.Item2].ColorOfCell != currnetColor)
                {
                    return false;
                }
            }//Right check

            return true;//can put
        }

        private bool CheckIfNotOutsideTheRange(Tuple<int, int> cords)
        {
            if ((cords.Item1 < 0 || cords.Item2 < 0))//gonna be one out of two cords out of range
            {
                return true;
            }
            else
            {
                if (cords.Item1 > 3 || cords.Item2 > 3)//gonna be one out of two cords out of range(more than 3)
                {
                    return true;
                }
                return false;
            }
        }


        public GameState SetNewColorForCopy(ColorOfCell color, Tuple<int, int> cordinates)
        {
            GameState newCopy = CopyOfGrid();//copping a grid to a new one

            newCopy._grid.grid[cordinates.Item1, cordinates.Item2].SetNewColorCell(color);
            newCopy.ChangePlayerMove();
            return newCopy;
        }

        public static GameState CreateNew(User user)
        {
            Grid grid = new Grid();
            grid.CreateEmptyGrid();
            return new GameState(grid, user);
        }

        public ColorOfCell GetCurrentColor()
        {
            return _user.UserMove ? ColorOfCell.blue : ColorOfCell.red;
        }
    }
}
