using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchneiderMinesweeper;
using SchneiderMinesweeper.Classes.Utils.Constants;
using SchneiderMinesweeper.Classes.Utils.Structures;
using SchneiderMinesweeper.Classes.ViewModel;

namespace SchneiderMinesweeperTests
{
    [TestClass]
    public class BoardViewModelTests
    {
        public BoardViewModel setupTestData ()
        {
            BoardViewModel boardVM = new BoardViewModel(3,
                3,
                2,
                new BoardPosition(2, 2),
                new BoardPosition(1, 1));

            boardVM.setBoardTileValueAtPosition(BoardTileType.safe, new BoardPosition(0, 0));
            boardVM.setBoardTileValueAtPosition(BoardTileType.safe, new BoardPosition(0, 1));
            boardVM.setBoardTileValueAtPosition(BoardTileType.mine, new BoardPosition(0, 2));
            boardVM.setBoardTileValueAtPosition(BoardTileType.safe, new BoardPosition(1, 0));
            boardVM.setBoardTileValueAtPosition(BoardTileType.safe, new BoardPosition(1, 1));
            boardVM.setBoardTileValueAtPosition(BoardTileType.mine, new BoardPosition(1, 2));
            boardVM.setBoardTileValueAtPosition(BoardTileType.safe, new BoardPosition(2, 0));
            boardVM.setBoardTileValueAtPosition(BoardTileType.safe, new BoardPosition(2, 1));
            boardVM.setBoardTileValueAtPosition(BoardTileType.safe, new BoardPosition(2, 2));

            return boardVM;
        }

        [TestMethod]
        public void TestMoveOnMine()
        {
            BoardViewModel boardVM = setupTestData();

            PlayerActionResult result = boardVM.attemptPlayerAction(PlayerActions.down);
            Assert.AreEqual(PlayerActionResult.movedOnMine, result, "Player move not triggering mine");
            Assert.AreEqual(1, boardVM.player.numberOfLives, "Player not losing lives from mines");
            Assert.AreEqual(2, boardVM.player.position.y, "Player position not updated on mine");
        }

        [TestMethod]
        public void TestMoveOnSafeSpace()
        {
            BoardViewModel boardVM = setupTestData();

            PlayerActionResult result = boardVM.attemptPlayerAction(PlayerActions.left);
            Assert.AreEqual(PlayerActionResult.movedSafe, result, "Player move should be safe tile");
            Assert.AreEqual(2, boardVM.player.numberOfLives, "Player lost lives from safe tile");
            Assert.AreEqual(0, boardVM.player.position.x, "Player position not updated on mine");
        }

        [TestMethod]
        public void TestMoveOutsideGrid()
        {
            BoardViewModel boardVM = setupTestData();

            boardVM.attemptPlayerAction(PlayerActions.left);
            PlayerActionResult result = boardVM.attemptPlayerAction(PlayerActions.left);
            Assert.AreEqual(PlayerActionResult.error, result, "Player should not move outside grid");
        }

        [TestMethod]
        public void TestVictory()
        {
            BoardViewModel boardVM = setupTestData();

            boardVM.attemptPlayerAction(PlayerActions.down);
            PlayerActionResult result = boardVM.attemptPlayerAction(PlayerActions.right);
            Assert.AreEqual(PlayerActionResult.win, result, "Player should win");
        }

        [TestMethod]
        public void TestDefeat()
        {
            BoardViewModel boardVM = setupTestData();

            boardVM.attemptPlayerAction(PlayerActions.down);
            PlayerActionResult result = boardVM.attemptPlayerAction(PlayerActions.left);
            Assert.AreEqual(PlayerActionResult.lose, result, "Player should lose");
        }
    }
}
