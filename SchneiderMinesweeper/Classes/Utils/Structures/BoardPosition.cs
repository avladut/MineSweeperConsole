using System;
namespace SchneiderMinesweeper.Classes.Utils.Structures
{
    public struct BoardPosition
    {
        public int x { get; private set; }
        public int y { get; private set; }

        public BoardPosition(int x, int y)
        {
            this.x = x;
            this.y = y;

            //public bool Equals(BoardPosition position)
            //{
            //    return position.x == x && position.y == y;
            //}
        }
    }
}
