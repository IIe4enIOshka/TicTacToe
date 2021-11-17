using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    class Cell : PictureBox
    {
        public Cell GetCell => this;

        public int Value { get; private set; }

        public Cell(int size, int positionX, int positionY)
        {
            Value = 0;
            this.BackColor = Color.Linen;
            this.Size = new Size(size, size);
            this.Location = new Point(positionX, positionY);
        }

        public void SetValue(int value)
        {
            Value = value;
        }
    }
}
