namespace Snort
{
    using System.Drawing;

    public partial class Form1 : Form
    {
        private GameState currentState;
        private readonly Rules rules = new Rules();
        private readonly Solving_Methods solver = new Solving_Methods();
        private Difficulty difficulty = Difficulty.medium;
        private bool gameOver = false;

        public Form1()
        {
            InitializeComponent();

            // першим ходить комп'ютер (червоний), бо другий гравець у цій грі виграє за правильної гри
            currentState = GameState.CreateNew(new User { UserMove = false });

            panel1.Paint += panel1_Paint;
            panel1.Resize += (s, e) => panel1.Invalidate();
            panel1.MouseClick += panel1_MouseClick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void StartNewGame()
        {
            gameOver = false;
            currentState = GameState.CreateNew(new User { UserMove = false });
            panel1.Invalidate();
            panel1.Update();

            ComputerMove();    // перший хід робить комп'ютер
        }

        private void buttonNewGame_Click(object? sender, EventArgs e)
        {
            StartNewGame();
        }

        private void comboDifficulty_SelectedIndexChanged(object? sender, EventArgs e)
        {
            switch (comboDifficulty.SelectedIndex)
            {
                case 0:
                    difficulty = Difficulty.easy;
                    break;
                case 2:
                    difficulty = Difficulty.hard;
                    break;
                default:
                    difficulty = Difficulty.medium;
                    break;
            }
        }

        private void panel1_MouseClick(object? sender, MouseEventArgs e)
        {
            if (gameOver)
                return;

            int size = Math.Min(panel1.ClientSize.Width, panel1.ClientSize.Height) / 4;
            int row = e.Y / size;      // піксель -> рядок
            int col = e.X / size;      // піксель -> стовпець

            if (row < 0 || row > 3 || col < 0 || col > 3)
                return;                // клік за межами сітки

            Tuple<int, int> cell = Tuple.Create(row, col);

            if (!rules.CheckIfPossibleMove(cell, currentState, ColorOfCell.blue))
                return;                // кут, зайнята клітинка або сусід червоного

            currentState = rules.TryApplyMove(currentState, ColorOfCell.blue, cell);
            panel1.Invalidate();
            panel1.Update();           // показати хід, поки комп'ютер думає

            if (rules.IsGameOver(currentState))    // у червоного немає ходів
            {
                gameOver = true;
                MessageBox.Show("Ти переміг!");
                return;
            }

            ComputerMove();
        }

        private void ComputerMove()
        {
            Cursor = Cursors.WaitCursor;
            Tuple<int, int> move = solver.ChooseMove(currentState, difficulty);
            Cursor = Cursors.Default;

            currentState = rules.TryApplyMove(currentState, ColorOfCell.red, move);
            panel1.Invalidate();
            panel1.Update();

            if (rules.IsGameOver(currentState))    // у синього немає ходів
            {
                gameOver = true;
                MessageBox.Show("Комп'ютер переміг.");
            }
        }

        private void panel1_Paint(object? sender, PaintEventArgs e)
        {
            int size = Math.Min(panel1.ClientSize.Width, panel1.ClientSize.Height) / 4;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    ColorOfCell color = currentState.GetCellColor(i, j);

                    if (color == ColorOfCell.notInUse)
                        continue;

                    Brush brush;
                    if (color == ColorOfCell.blue)
                        brush = Brushes.Blue;
                    else if (color == ColorOfCell.red)
                        brush = Brushes.Red;
                    else
                        brush = Brushes.White;

                    e.Graphics.FillRectangle(brush, j * size, i * size, size, size);
                    e.Graphics.DrawRectangle(Pens.Black, j * size, i * size, size - 1, size - 1);
                }
            }
        }
    }
}