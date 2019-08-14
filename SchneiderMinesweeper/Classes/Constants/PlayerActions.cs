using System;
namespace SchneiderMinesweeper.Classes.Constants
{
    //should rename to Action
    public enum PlayerActions
    {
        exit = 0,
        up,
        down,
        left,
        right,
        unknown
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
}
