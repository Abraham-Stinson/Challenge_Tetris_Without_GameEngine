using System;
using System.Collections;
using System.Collections.Generic;

namespace GridGameProject.GameLogic
{
    public abstract class Block
    {
        public bool [,] Shape { get; private set; }
        public Position Offset { get; set; }
        public Block (bool[,] initialShape, Position startOffset) {
            Shape = initialShape;
            Offset = startOffset;
        }
        public void Rotate()
        {
            int size = Shape.GetLength(0);
            bool[,] newShape = new bool[size, size];

            for(int r = 0; r < size; r++)
            {
                for(int c=0; c < size; c++)
                {
                    newShape[c,size-1-r] =Shape[r,c];
                }
            }

            Shape = newShape;
        }

        public void Move(int rows, int columns)
        {
            Offset.Row += rows;
            Offset.Column += columns;
        }

        public IEnumerable<Position> TilePositions()
        {
            for(int r = 0; r < Shape.GetLength(0); r++)
            {
                for(int c=0;c< Shape.GetLength(1); c++)
                {
                    if (Shape[r, c])
                    {
                        yield return new Position(Offset.Row + r, Offset.Column + c);
                    }
                }
            }
        }
    }
}