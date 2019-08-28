using System;
using SchneiderMinesweeper.Classes.Utils.Constants;
using SchneiderMinesweeper.Classes.ViewModel;

namespace SchneiderMinesweeper.Classes.View
{
    public class GameView
    {

        public BoardViewModel boardVM
        {
            get;
            private set;
        }
        public GameView()
        {
            boardVM = BoardViewModel.getBoardModelWithDefaultValues();
        }

        public void DisplayUI()
        {
            bool shouldContinueGame = true;
           

            while (shouldContinueGame)
            {
                DisplayMenuText();
                String input = Console.ReadLine();

                try
                {
                    int result = Int32.Parse(input);
                    //PlayerActions action = (PlayerActions)result;
                    PlayerActions action = (PlayerActions)Enum.ToObject(typeof(PlayerActions), result);
                    Console.WriteLine("\n\n" + action.GetActionText() + "\n\n");
                    shouldContinueGame = ActionSelected(action);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse '{input}'");
                }
            }
        }

        private bool ActionSelected(PlayerActions action)
        {
            PlayerActionResult actionResult = boardVM.attemptPlayerAction(action);

            Console.WriteLine("\nACTION FEEDBACK: " + actionResult.GetActionResultText() + "\n");
            if (actionResult == PlayerActionResult.exit ||
                    actionResult == PlayerActionResult.win ||
                    actionResult == PlayerActionResult.lose)
            {
                return false;
            }
            return true;
        }

        private void DisplayMenuText()
        {
            Console.WriteLine(boardVM.getPlayerStatus());
            Console.WriteLine("Enter your option: ");
            foreach (PlayerActions action in Enum.GetValues(typeof(PlayerActions)))
            {
                Console.WriteLine((int)action + ". " + action.GetActionText());
            }
        }
    }
}
