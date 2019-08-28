using System;
using SchneiderMinesweeper.Classes.Model;
using SchneiderMinesweeper.Classes.Utils.Constants;
using SchneiderMinesweeper.Classes.Utils.Structures;

namespace SchneiderMinesweeper.Classes.ViewModel
{
    public class BoardViewModel
    {
        private BoardModel board;

        //should be private but needs testing
        public PlayerModel player;

        public static BoardViewModel getBoardModelWithDefaultValues()
        {
            return new BoardViewModel(GameDefaultSettings.defaultBoardWidth,
                    GameDefaultSettings.defaultBoardHeight,
                    GameDefaultSettings.playerLives,
                    GameDefaultSettings.destinationPosition,
                    GameDefaultSettings.playerStartPosition);
        }

        public BoardViewModel(int boardWidth,
                int boardHeight,
                int playerLives,
                BoardPosition destinationPosition,
                BoardPosition playerInitialPosition)
        {
            board = new BoardModel(boardWidth, boardHeight, destinationPosition);
            player = new PlayerModel(playerInitialPosition, playerLives);
            populateBoardWithRandomValues();
        }


        private void populateBoardWithRandomValues()
        {
            Random random = new Random();
            for (int i = 0; i< board.boardWidth; i++)
            {
                for (int j = 0; j < board.boardHeight; j++)
                {
                    int randomValue = random.Next(0, 2);
                    BoardTileType tile = randomValue == 0 ? BoardTileType.safe : BoardTileType.mine;
                    setBoardTileValueAtPosition(tile, new BoardPosition(i, j));
                }
            }
        }

        public void setBoardTileValueAtPosition(BoardTileType tile, BoardPosition boardPosition)
        {
            board.setTileForPosition(boardPosition, tile);
        }

        public PlayerActionResult attemptPlayerAction(PlayerActions action)
        {
            BoardPosition newPosition;
            switch (action)
            {
                case PlayerActions.up:
                    newPosition = new BoardPosition(this.player.position.x, (this.player.position.y - 1));
                    break;
                case PlayerActions.down:
                    newPosition = new BoardPosition(this.player.position.x, (this.player.position.y + 1));
                    break;
                case PlayerActions.left:
                    newPosition = new BoardPosition((this.player.position.x - 1), this.player.position.y);
                    break;
                case PlayerActions.right:
                    newPosition = new BoardPosition((this.player.position.x + 1), this.player.position.y);
                    break;
                case PlayerActions.exit:
                    return PlayerActionResult.exit;
                default:
                    return PlayerActionResult.error;
            }

            if (this.validateNewPosition(newPosition))
            {
                return updatePlayerWithPosition(newPosition);
            }

            return PlayerActionResult.error;
        }

        private bool validateNewPosition(BoardPosition position)
        {
            if (position.x >= 0 &&
                position.x < board.boardWidth &&
                position.y >= 0 &&
                position.y < board.boardHeight) {

                return true;
            }

            return false;
        }

        private PlayerActionResult updatePlayerWithPosition(BoardPosition position)
        {
            player.position = position;
            player.numberOfMoves += 1;

            //check if player won
            if (player.position.Equals(board.destinationPosition))
            {
                return PlayerActionResult.win;
            }

            //check if player stepped on a mine
            if (board.getValueForPosition(player.position) == BoardTileType.mine) {
                player.numberOfLives -= 1;

                //if the player has 0 lives, the game is over
                if (player.numberOfLives == 0)
                {
                    return PlayerActionResult.lose;
                }
                return PlayerActionResult.movedOnMine;
            }

            return PlayerActionResult.movedSafe;
        }

        public String getPlayerStatus()
        {
            return player.ToString();
        }
    }
}
