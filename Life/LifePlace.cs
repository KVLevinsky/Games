using System;
using System.Collections.Generic;

namespace Life {
    public class LifePlace {
        public Cell[,] Place { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public LifePlace(int width, int height) {
            Width = width;
            Height = height;
            Place = new Cell[width, height];
            Populate();
        }

        public void Populate() {
            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Height; j++)
                    if (Place[i, j] == null)
                        Place[i, j] = new Life.Cell(new CellPosition() { X = i, Y = j }, ((new Random((int)(DateTime.Now.ToBinary())).Next(0, 100) > 65) ? true : false));
                    else
                        Place[i, j].SetAlive((new Random((int)(DateTime.Now.ToBinary())).Next(0, 100) > 50) ? true : false);
        }

        public IEnumerable<Cell> GetNeighbors(CellPosition position) {
            List<Cell> Result = new List<Cell>();
            for (int i = position.X - 1; i < position.X + 2; i++) {
                for (int j = position.Y - 1; j < position.Y + 2; j++) {
                    Result.Add(GetCellOnPosition(i, j));
                }
            }
            return Result;
        }
        public Cell GetCellOnPosition(int x, int y) {
            x = (x + Width) % Width;
            y = (y + Height) % Height;
            return Place[x,y];
        }
        public void Step() {
            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Height; j++)
                    Place[i, j].EvaluateNextState(this);
            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Height; j++)
                    Place[i, j].Step();
        }
    }
}