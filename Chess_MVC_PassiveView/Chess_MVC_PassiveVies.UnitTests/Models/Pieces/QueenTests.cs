using Chess_MVC_PassiveView.Enums;
using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Models.Pieces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chess_MVC_PassiveView.UnitTests.Models.Pieces
{
    [TestClass]
    public class QueenTests
    {
        private Board board;
        private Queen queen;

        [TestInitialize]
        public void TestInitialize()
        {
            board = new Board();
            queen = new Queen(PieceColor.White);
        }

        [TestMethod]
        public void IsValidMove_ValidUpDiagonalRightMove_True()
        {
            //Arrange
            var piecesDisposition = GetEmptyBoard();
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(3), Col(3));
            var target = new Coordinate(Row(1), Col(5));

            //Act
            var result = queen.IsValidMove(origin, target, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidMove_ValidDiagonalUpLeftMove_True()
        {
            //Arrange
            var piecesDisposition = GetEmptyBoard();
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(3), Col(3));
            var target = new Coordinate(Row(1), Col(1));

            //Act
            var result = queen.IsValidMove(origin, target, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidMove_ValidDiagonalDownRightMove_True()
        {
            //Arrange
            var piecesDisposition = GetEmptyBoard();
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(3), Col(3));
            var target = new Coordinate(Row(5), Col(5));

            //Act
            var result = queen.IsValidMove(origin, target, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidMove_ValidDiagonalDownLeftMove_True()
        {
            //Arrange
            var piecesDisposition = GetEmptyBoard();
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(3), Col(3));
            var target = new Coordinate(Row(5), Col(1));

            //Act
            var result = queen.IsValidMove(origin, target, board);

            //Assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void IsValidMove_ValidStraightMoveUp_True()
        {
            //Arrange
            var piecesDisposition = GetEmptyBoard();
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(3), Col(3));
            var target = new Coordinate(Row(0), Col(3));

            //Act
            var result = queen.IsValidMove(origin, target, board);

            //Assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void IsValidMove_ValidStraightMoveDown_True()
        {
            //Arrange
            var piecesDisposition = GetEmptyBoard();
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(3), Col(3));
            var target = new Coordinate(Row(7), Col(3));

            //Act
            var result = queen.IsValidMove(origin, target, board);

            //Assert
            Assert.IsTrue(result);
        }



        [TestMethod]
        public void IsValidMove_ValidStraightMoveRight_True()
        {
            //Arrange
            var piecesDisposition = GetEmptyBoard();
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(3), Col(3));
            var target = new Coordinate(Row(3), Col(7));

            //Act
            var result = queen.IsValidMove(origin, target, board);

            //Assert
            Assert.IsTrue(result);
        }



        [TestMethod]
        public void IsValidMove_ValidStraightMoveLeft_True()
        {
            //Arrange
            var piecesDisposition = GetEmptyBoard();
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(3), Col(3));
            var target = new Coordinate(Row(3), Col(0));

            //Act
            var result = queen.IsValidMove(origin, target, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidMove_InvalidMovePieceInPath_False()
        {
            //Arrange
            string[][] piecesDisposition =
            [ //   0    1    2    3    4    5    6    7
            /*0*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*1*/["_", "_", "_", "_", "-", "_", "_", "_"],
            /*2*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*3*/["_", "_", "_", "♕", "_", "_", "_", "_"],
            /*4*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*5*/["_", "♟", "_", "_", "_", "_", "_", "_"],
            /*6*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*7*/["_", "_", "_", "_", "_", "_", "_", "_"]
            ];

            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(3), Col(3));
            var target = new Coordinate(Row(6), Col(0));

            //Act
            var result = queen.IsValidMove(origin, target, board);

            //Assert
            Assert.IsFalse(result);
        }

        private int Row(int row)
        {
            return row;
        }

        private int Col(int col)
        {
            return col;
        }

        private string[][] GetEmptyBoard()
        {
            string[][] piecesDisposition =
            [ //   0    1    2    3    4    5    6    7
            /*0*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*1*/["_", "_", "_", "_", "-", "_", "_", "_"],
            /*2*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*3*/["_", "_", "_", "♕", "_", "_", "_", "_"],
            /*4*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*5*/["_", "-", "_", "_", "_", "_", "_", "_"],
            /*6*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*7*/["_", "_", "_", "_", "_", "_", "_", "_"]
            ];

            return piecesDisposition;
        }
    }
}
