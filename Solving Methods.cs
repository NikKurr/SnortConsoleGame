using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snort
{
    public class Solving_Methods
    {
        private const int max_min_value = 1000;        
        private Rules _rules = new Rules();
        public int Evaluate(GameState state)
        {
            ColorOfCell currentColor = state.GetCurrentColor();

            if (!_rules.CheckPossibleMovesLeft(state, currentColor))
                return currentColor == ColorOfCell.blue ? max_min_value : -max_min_value;
            else
            {
                int currentCount = _rules.PossibleMoves(state, currentColor).Count;

                ColorOfCell otherColor = (currentColor == ColorOfCell.blue) ? ColorOfCell.red : ColorOfCell.blue;
                int otherCount = _rules.PossibleMoves(state, otherColor).Count;
                
                return (currentColor == ColorOfCell.red) ? currentCount - otherCount : otherCount - currentCount;
            }
        }

        public Tuple<int, int> ChooseMove(GameState state, Difficulty dif)
        {
            List<Tuple<int, int>> redPossibleMoves = _rules.PossibleMoves(state, ColorOfCell.red);//all possible moves for red

            if (redPossibleMoves.Count == 0)
                throw new Exception("No possible moves for red! You won it!");

            Tuple<int, int> bestCords = redPossibleMoves.First();

            int aplphaBetaPuring = 0;
            Tuple<Tuple<int, int>, int> best = Tuple.Create(redPossibleMoves.First(), -10000);

            foreach (var t in redPossibleMoves)
            {
                GameState newState = _rules.TryApplyMove(state, ColorOfCell.red, t);//creating a new state

                if (_rules.IsGameOver(newState))
                    return t;

                 aplphaBetaPuring = AlphaBetaPuring(newState, (int)dif - 1, -int.MaxValue, int.MaxValue, false);

                if(aplphaBetaPuring > best.Item2)//maximizing
                {
                    best = Tuple.Create(t, aplphaBetaPuring);
                }
            }


            //choosing best cords

            return best.Item1;
        }

        public int AlphaBetaPuring(GameState state, int depth, int alpha, int beta, bool maximizing)
        {
            if (depth == 0 || _rules.IsGameOver(state))
                return Evaluate(state);
            int best;

            GameState newCopyState;
            if (maximizing)
            {
                best = -10000;

                List<Tuple<int, int>> listOfPossibleMoves  = _rules.PossibleMoves(state, ColorOfCell.red);
                foreach(var t in listOfPossibleMoves)
                {
                    newCopyState = _rules.TryApplyMove(state, ColorOfCell.red, t);//moving throw all possible positions 

                    int value = AlphaBetaPuring(newCopyState, depth - 1, alpha, beta, false);
                    best = Math.Max(best, value);
                    alpha = Math.Max(alpha, best);

                    if (beta <= alpha)
                        break;
                }
            }
            else
            {
                best = 10000;
                List<Tuple<int, int>> listOfPossibleMoves = _rules.PossibleMoves(state, ColorOfCell.blue);

                foreach (var t in listOfPossibleMoves)
                {
                    newCopyState = _rules.TryApplyMove(state, ColorOfCell.blue, t);//moving throw all possible positions for blue

                    int value = AlphaBetaPuring(newCopyState, depth - 1, alpha, beta, true);//-1 depth
                    best = Math.Min(best, value);//trying to find min value for best
                    beta = Math.Min(beta, best);//trying to find min value for aplha

                    if (beta <= alpha)
                        break;//no sence to continue
                }
            }

            return best;

        }
    }

    public enum Difficulty
    {
        easy = 2,
        medium = 4,
        hard = 8
    }
}
