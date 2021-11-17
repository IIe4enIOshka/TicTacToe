namespace TicTacToe
{
    class GameField
    {
        public Cell[,] Cells { get; private set; }

        private int _size;
        private int _cellSize = 90;
        private int _offset = 10;
        private int _valueRound = 1;
        private int _valueCross = 2;
        private int _valueFreeCell = 0;

        public GameField(int size)
        {
            _size = size;
            Cells = new Cell[_size, _size];

            Init();
        }

        private void Init()
        {
            for (int i = 0; i < _size; i++)
                for (int j = 0; j < _size; j++)
                    Cells[i, j] = new Cell(_cellSize, _offset + j * _cellSize + _offset * j, _offset + i * _cellSize + _offset * i);

        }

        public void Clear()
        {
            for (int i = 0; i < _size; i++)
                for (int j = 0; j < _size; j++)
                    Cells[i, j].SetValue(_valueFreeCell);
        }

        public bool CheckFullnes()
        {
            for (int i = 0; i < _size; i++)
                for (int j = 0; j < _size; j++)
                    if (Cells[i, j].Value == _valueFreeCell)
                        return false;

            return true;
        }

        public bool CheckWin()
        {
            for (int i = 0; i < _size; i++)
                if (CheckRow(i, _valueRound) ||
                    CheckRow(i, _valueCross) ||
                    CheckColl(i, _valueRound) ||
                    CheckColl(i, _valueCross) ||
                    CheckDiagonal(true, _valueRound) ||
                    CheckDiagonal(true, _valueCross) ||
                    CheckDiagonal(false, _valueRound) ||
                    CheckDiagonal(false, _valueCross))
                    return true;

            return false;
        }

        private bool CheckRow(int row, int value)
        {
            for (int i = 0; i < _size; i++)
                if (Cells[row, i].Value != value)
                    return false;

            return true;
        }

        private bool CheckColl(int coll, int value)
        {
            for (int i = 0; i < _size; i++)
                if (Cells[i, coll].Value != value)
                    return false;

            return true;
        }

        private bool CheckDiagonal(bool isMain, int value)
        {
            if (isMain == true)
            {
                for (int i = 0; i < _size; i++)
                    if (Cells[i, i].Value != value)
                        return false;
            }
            else
            {
                for (int i = 0; i < _size; i++)
                    if (Cells[_size - i - 1, i].Value != value)
                        return false;
            }

            return true;
        }
    }
}
