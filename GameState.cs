using System;
namespace GridGameProject.GameLogic
{
    public class GameState
    {
        public GridValue[,] GameGrid { get; private set; }

        public int Rows { get; }
        public int Columns{ get; }

        public Block CurrentBlock { get; private set; }

        public int Score { get; private set; }
        public bool GameOver { get; private set; }

        public event Action GameOverEvent;
        public event Action<int> ScoreUpdatedEvent;


        private BlockQueue blockQueue;

        public GameState(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            GameGrid = new GridValue[Rows, Columns];

            blockQueue = new BlockQueue();

            CurrentBlock = blockQueue.GetRandomBlock();
        }

        private bool IsInside(int r,int c)
        {
            return r >= 0 && r < Rows && c >= 0 && c < Columns;
        }

        private bool IsEmpty (int r, int c)
        {
            return IsInside(r, c) && GameGrid[r, c] == GridValue.Empty;
        }

        private bool BlockFits()
        {
            foreach (Position p in CurrentBlock.TilePositions())
            {
                if (!IsEmpty(p.Row, p.Column))
                {
                    return false;
                }
            }
            return true;
        }

        public void MoveLeftBlock()
        {
            CurrentBlock.Move(0, -1);

            if (!BlockFits())
            {
                CurrentBlock.Move(0, 1);
            }
        }
        public void MoveRightBlock()
        {
            CurrentBlock.Move(0, 1);

            if (!BlockFits())
            {
                CurrentBlock.Move(0, -1);
            }
        }
        public void RotateBlock()
        {
            CurrentBlock.Rotate();

            if (!BlockFits())
            {
                for(int i = 0; i < 3; i++)
                {
                    CurrentBlock.Rotate();
                }
            }
        }

        public void MoveBlockDown()
        {
            CurrentBlock.Move(1, 0);

            if (!BlockFits())
            {
                CurrentBlock.Move(-1, 0);

                PlaceBlock();
            }
        }

        private void ClearFullRows()
        {
            int clearedThisTurn = 0;

            for (int r = Rows - 1; r >= 0; r--)
            {
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    ShiftRowsDown(r);
                    clearedThisTurn++;
                    r++;
                }
            }

            if (clearedThisTurn > 0)
            {
                Score += clearedThisTurn * 100 * clearedThisTurn;

                ScoreUpdatedEvent?.Invoke(Score);
            }
        }

        private void PlaceBlock()
        {
            foreach (Position p in CurrentBlock.TilePositions())
            {
                GameGrid[p.Row, p.Column] = GridValue.Occupied; 
            }

            ClearFullRows();

            CurrentBlock = blockQueue.GetRandomBlock();

            if (!BlockFits())
            {
                GameOver = true;
                GameOverEvent?.Invoke();
            }
        }

        private bool IsRowFull(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (GameGrid[r, c] == GridValue.Empty)
                {
                    return false;
                }
            }
            return true;
        }

        private void ClearRow(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                GameGrid[r, c] = GridValue.Empty;
            }
        }

        private void ShiftRowsDown(int clearedRow)
        {
            for (int r = clearedRow - 1; r >= 0; r--)
            {
                for (int c = 0; c < Columns; c++)
                {
                    GameGrid[r + 1, c] = GameGrid[r, c];

                    GameGrid[r, c] = GridValue.Empty;
                }
            }
        }
    }
}

