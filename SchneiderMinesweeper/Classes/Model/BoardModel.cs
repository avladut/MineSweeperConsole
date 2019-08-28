using System;
using SchneiderMinesweeper.Classes.Utils.Constants;
using SchneiderMinesweeper.Classes.Utils.Structures;

namespace SchneiderMinesweeper.Classes.Model
{
    
    public struct BoardModel
    {
        public int boardWidth {get; private set;}
        public int boardHeight { get; private set; }
        public BoardPosition destinationPosition { get; private set; }

        private BoardTileType[,] board;

        public BoardModel(int boardWidth, int boardHeight, BoardPosition destination)
        {
            this.boardHeight = boardHeight;
            this.boardWidth = boardWidth;
            this.destinationPosition = destination;
            this.board = new BoardTileType[boardWidth, boardHeight];
        }

        public void setTileForPosition(BoardPosition position, BoardTileType tileType)
        {
            board[position.x, position.y] = tileType;
        }

        public BoardTileType getValueForPosition(BoardPosition position)
        {
            return board[position.x, position.y];
        }
    }
}
