using System.Drawing;

namespace TicTacToe
{
    static class Drawing
    {
        private static Graphics _graphics;
        private static int _widthPen = 7;
        private static int _offset = 10;
        private static int _valueRound = 1;
        private static int _valueCross = 2;

        private static Pen pen = new Pen(Color.SaddleBrown, _widthPen);

        public static void DrawField(GameField gameField, int size)
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    DrawCell(gameField.Cells[i, j].GetCell);
        }

        public static void DrawCell(Cell cell)
        {
            Bitmap bitmap = new Bitmap(cell.Width, cell.Height);
            _graphics = Graphics.FromImage(bitmap);

            if (cell.Value == _valueRound)
            {
                DrawEllipse(cell);
            }
            else if (cell.Value == _valueCross)
            {
                DrawCross(cell);
            }

            cell.Image = bitmap;
        }

        private static void DrawEllipse(Cell cell)
        {
            _graphics.DrawEllipse(pen, _offset, _offset, cell.Width - _offset * 2, cell.Height - _offset * 2);
        }

        private static void DrawCross(Cell cell)
        {
            _graphics.DrawLine(pen, _offset, _offset, cell.Width - _offset, cell.Height - _offset);
            _graphics.DrawLine(pen, cell.Width - _offset, _offset, _offset, cell.Height - _offset);
        }
    }
}
