using System;
using SchneiderMinesweeper.Classes.Constants;

namespace SchneiderMinesweeper.Classes.View
{
    public class GameView
    {
        public GameView()
        {
        }

        public void DisplayUI()
        {
            string input = String.Empty;
            PlayerActions action = PlayerActions.unknown;
           

            while (action != PlayerActions.exit)
            {
                DisplayMenuText();
                input = Console.ReadLine();

                try
                {
                    int result = Int32.Parse(input);
                    action = (PlayerActions)result;
                    Console.WriteLine(action.GetActionText());
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse '{input}'");
                }
            }
        }

        private void DisplayMenuText()
        {
            Console.WriteLine("Enter your option: ");
            foreach (PlayerActions action in Enum.GetValues(typeof(PlayerActions)))
            {
                Console.WriteLine((int)action + ". " + action.GetActionText());
            }
        }
    }
}
