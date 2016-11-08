using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life {
    public class Cell {
        public CellPosition Position { get; private set; }
        public bool Alive { get; private set; }
        protected bool nextState;
        public Cell(CellPosition position, bool alive) {
            Position = position;
            Alive = alive;
        }
        public void SetAlive(bool alive) {
            Alive = alive;
        }
        public void EvaluateNextState(LifePlace lp) {
            int Result = 0;
            foreach (Cell cell in lp.GetNeighbors(this.Position))
                if (cell.Alive)
                    Result++;
            if ((Result < 2) || (Result > 3))
                nextState = false;
            else
                nextState = true;
        }
        public void Step() {
            Alive = nextState;
        }
    }
}
