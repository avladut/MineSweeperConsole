using System;
using SchneiderMinesweeper.Classes.View;

namespace SchneiderMinesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GameView gw = new GameView();
            gw.DisplayUI();
        }
    }
}
