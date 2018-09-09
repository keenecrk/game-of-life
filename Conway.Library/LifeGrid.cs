using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway.Library
{
    public class LifeGrid
    {
        public CellState[,] CurrentState;
        private CellState[,] nextState;

        public LifeGrid()
        {
            CurrentState = new CellState[5, 5];
            nextState = new CellState[5, 5];
        }

        public void UpdateState()
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    var liveNeighbors = GetLiveNeighbors(i, j);
                    nextState[i, j] = LifeRules.GetNewState(CurrentState[i, j], liveNeighbors);
                }

            CurrentState = nextState;
            nextState = new CellState[5, 5];
        }

        private int GetLiveNeighbors(int positionX, int positionY)
        {
            int liveNeighbors = 0;
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        continue;

                    int neighborX = positionX + i;
                    int neighborY = positionY + j;

                    if (neighborX >= 0 && neighborX < 5 &&
                        neighborY >= 0 && neighborY < 5)
                    {
                        if (CurrentState[neighborX, neighborY] == CellState.Alive)
                            liveNeighbors++;
                    }
                }
            return liveNeighbors;
        }
    }
}
