using System;
using SchneiderMinesweeper.Classes.View;

namespace SchneiderMinesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            GameView gw = new GameView();
            gw.DisplayUI();
        }
    }
}
