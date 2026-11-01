using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Snort
{
    public class Rules
    {
        public bool CheckIfPossibleMove(Tuple<int, int> cordinates, GameState state, ColorOfCell color)
        {
            if (state.CheckIfAnyColor(cordinates))
            {
                return false;
            }
            else
            {
                if (!state.CheckIfNoNeighbors(cordinates, color))
                {
                    return false;
                }
                else
                {

                    return true;// if every check is ok so we can put anything
                }
            }
        }

        public bool CheckPossibleMovesLeft(GameState state, ColorOfCell color)
        {
            //moving throw 4 on 4 our field and check possible move
            return PossibleMoves(state, color).Count > 0;
        }

        public List<Tuple<int, int>> PossibleMoves(GameState state, ColorOfCell color)
        {
            List<Tuple<int, int>> innerList = new List<Tuple<int, int>>();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Tuple<int, int> tuple = new Tuple<int, int>(i, j);//currentcordinates
                    if (CheckIfPossibleMove(tuple, state, color))
                    {
                        innerList.Add(tuple);
                    }
                }
            }//loop fo finding posible moves and adding to our list

            return innerList;
        }

        public GameState TryApplyMove(GameState currentState, ColorOfCell color, Tuple<int, int> cordinates)
        {
            if(!CheckIfPossibleMove(cordinates, currentState, color))
            {
                throw new ArgumentException("The move is not possible");
            }
            else
            {
               GameState newState = currentState.SetNewColorForCopy(color, cordinates);

                return newState;
            }
        }
        public bool IsGameOver(GameState state)
        {
            if(!CheckPossibleMovesLeft(state, state.GetCurrentColor()))
            {
                return true;
            }

            return false;
        }
    }
}
