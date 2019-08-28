using System;
using SchneiderMinesweeper.Classes.Utils.Structures;

namespace SchneiderMinesweeper.Classes.Utils.Constants
{
    public static class GameDefaultSettings
    {
        public const int defaultBoardWidth = 3;
        public const int defaultBoardHeight = 3;
        public const int playerLives = 3;
        public static BoardPosition playerStartPosition = new BoardPosition(0, 0);
        public static BoardPosition destinationPosition = new BoardPosition(2, 2);

    }
}
