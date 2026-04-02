using GridGameProject.GameLogic;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GridGameProject
{
    public partial class MainWindow : Window
    {
        private GameState gameState;
        private int cellSize = 30;

        private string highScoreFilePath = "highscore.txt";
        private int highScore = 0;

        public MainWindow()
        {
            InitializeComponent();

            gameState = new GameState(20, 10);

            gameState.ScoreUpdatedEvent += OnScoreUpdated;
            gameState.GameOverEvent += OnGameOver;
            LoadHighScore();

            _ = GameLoop();
        }

        private async Task GameLoop()
        {
            Draw();

            while (!gameState.GameOver)
            {
                await Task.Delay(500);
                gameState.MoveBlockDown();
                Draw();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameState.GameOver) return;

            switch (e.Key)
            {
                case Key.Left:
                    gameState.MoveLeftBlock();
                    break;
                case Key.Right:
                    gameState.MoveRightBlock();
                    break;
                case Key.Down:
                    gameState.MoveBlockDown();
                    break;
                case Key.Up:
                    gameState.RotateBlock();
                    break;
                case Key.Space:
                    gameState.DropBlockToBottom();
                    break;
                case Key.C:
                    gameState.HoldBlock();
                    break;
            }
            Draw();
        }

        private void Draw()
        {
            GameCanvas.Children.Clear();

            for (int r = 0; r < gameState.Rows; r++)
            {
                for (int c = 0; c < gameState.Columns; c++)
                {
                    if (gameState.GameGrid[r, c] == GridValue.Occupied)
                    {
                        DrawCell(r, c, Brushes.Cyan);
                    }
                }
            }
            foreach (Position p in gameState.CurrentBlock.TilePositions())
            {
                DrawCell(p.Row, p.Column, Brushes.Red);
            }
        }

        private void DrawCell(int row, int col, Brush color)
        {
            Rectangle rect = new Rectangle
            {
                Width = cellSize - 1,
                Height = cellSize - 1,
                Fill = color
            };

            Canvas.SetTop(rect, row * cellSize);
            Canvas.SetLeft(rect, col * cellSize);

            GameCanvas.Children.Add(rect);
        }

        private void LoadHighScore()
        {
            if (File.Exists(highScoreFilePath))
            {
                string savedScoreText = File.ReadAllText(highScoreFilePath);

                if (int.TryParse(savedScoreText, out int savedScore))
                {
                    highScore = savedScore;
                }
            }
            HighScoreText.Text = highScore.ToString();
        }

        private void SaveHighScoreIfNecessary()
        {
            if (gameState.Score > highScore)
            {
                File.WriteAllText(highScoreFilePath, gameState.Score.ToString());
            }
        }

        private void OnScoreUpdated(int newScore)
        {
            ScoreText.Text = newScore.ToString();
        }

        private void OnGameOver()
        {
            GameOverText.Visibility = Visibility.Visible;

            SaveHighScoreIfNecessary();
        }
    }
}