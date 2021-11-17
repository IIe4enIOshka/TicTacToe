using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Game : Form
    {
        private int _size = 3;
        private int _valueRound = 1;
        private int _valueCross = 2;
        private int _valueFreeCell = 0;

        private GameField _gameField;
        private bool _currentMove = false;

        public Game()
        {
            InitializeComponent();

            this.Size = new Size(_size * 90 + (_size + 3) * 10 - 3, _size * 90 + (_size + 5) * 10); // размеры формы. сомнительно
            this.BackColor = Color.Peru;

            Init();
            Drawing.DrawField(_gameField, _size);
            AddCell();
            AddEventClick();
        }
        private void Init()
        {
            _gameField = new GameField(_size);
        }

        private void AddCell()
        {
            for (int i = 0; i < _size; i++)
                for (int j = 0; j < _size; j++)
                    this.Controls.Add(_gameField.Cells[i, j].GetCell);
        }

        private void AddEventClick()
        {
            for (int i = 0; i < _size; i++)
                for (int j = 0; j < _size; j++)
                    _gameField.Cells[i, j].GetCell.MouseClick += MouseClick;
        }

        private new void MouseClick(object sender, MouseEventArgs e)
        {
            Cell cell = sender as Cell;

            if (cell.Value == _valueFreeCell)
            {
                Move(cell);
                _currentMove = !_currentMove;
                Drawing.DrawCell(cell);
                CheckWin();
            }
        }

        private new void Move(Cell cell)
        {
            if (_currentMove == true)
                cell.SetValue(_valueRound);
            else
                cell.SetValue(_valueCross);
        }

        private void CheckWin()
        {
            if (_gameField.CheckWin() == true || _gameField.CheckFullnes() == true)
                ShowMessage();
        }

        private void ShowMessage()
        {
            if (MessageBox.Show("Игра окончена") == DialogResult.OK)
                Restart();
        }

        private void Restart()
        {
            _gameField.Clear();
            Drawing.DrawField(_gameField, _size);
        }
    }
}
