using System;
using SchneiderMinesweeper.Classes.Utils.Structures;

namespace SchneiderMinesweeper.Classes.Model
{
    public struct PlayerModel
    {
        public BoardPosition position { get; set; }
        public int numberOfMoves { get; set; }
        public int numberOfLives { get; set; }


        public PlayerModel(BoardPosition initialPosition, int lives)
        {
            this.position = initialPosition;
            this.numberOfLives = lives;
            this.numberOfMoves = 0;
        }

        public override string ToString()
        {
            return "Player status:{\nPlayer position (x: " + position.x + " y: " + position.y + ")\nMoves: " + numberOfMoves + "\nLives left: " + numberOfLives + "\n}"; ;
        }
    }
}
