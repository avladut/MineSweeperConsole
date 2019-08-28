using System;
namespace SchneiderMinesweeper.Classes.Utils.Constants
{
    //should rename to Action
    public enum PlayerActions
    {
        exit = 0,
        up,
        down,
        left,
        right
    }

    public enum PlayerActionResult
    {
        movedSafe = 0,
        movedOnMine,
        error,
        win,
        lose,
        exit
    }

    static class PlayerActionsMethods
    {
        public static String GetActionText(this PlayerActions action)
        {
            switch (action)
            {
                case PlayerActions.exit:
                    return "Exit";
                case PlayerActions.up:
                    return "Move UP";
                case PlayerActions.down:
                    return "Move DOWN";
                case PlayerActions.left:
                    return "Move LEFT";
                case PlayerActions.right:
                    return "Move RIGHT";
                default:
                    return "Unknown";
            }
        }
    }

    static class PlayerActionResultMethods
    {
        public static String GetActionResultText(this PlayerActionResult actionResult)
        {
            switch (actionResult)
            {
                case PlayerActionResult.movedSafe:
                    return "moved to safe tile";
                case PlayerActionResult.movedOnMine:
                    return "BOOM!!";
                case PlayerActionResult.error:
                    return "invalid move out of grid or inexistent option";
                case PlayerActionResult.win:
                    return "you won the game";
                case PlayerActionResult.lose:
                    return "you lost the game";
                case PlayerActionResult.exit:
                    return "you exited the game";

                default:
                    return "Unknown";
            }
        }
    }
}
