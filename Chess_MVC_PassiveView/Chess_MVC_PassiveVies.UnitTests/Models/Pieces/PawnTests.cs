using Chess_MVC_PassiveView.Enums;
using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Models.Pieces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chess_MVC_PassiveView.UnitTests.Models.Pieces
{
    [TestClass]
    public class PawnTests
    {
        private Board board;
        private Pawn pawn;

        [TestInitialize]
        public void TestInitialize()
        {
            board = new Board();
            pawn = new Pawn(PieceColor.White);
        }

        [TestMethod]
        public void IsValidMove_ValidOneBoxMove_True()
        {
            //Arrange
            var piecesDisposition = GetEmptyBoard();
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(1), Col(3));
            var target = new Coordinate(Row(2), Col(3));

            //Act
            var result = pawn.IsValidMove(origin, target, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidMove_ValidTwoBoxMove_True()
        {
            //Arrange
            var piecesDisposition = GetEmptyBoard();
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(1), Col(3));
            var target = new Coordinate(Row(3), Col(3));

            //Act
            var result = pawn.IsValidMove(origin, target, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidMove_InvalidTwoBoxMove_False()
        {
            //Arrange
            var piecesDisposition = GetEmptyBoard();
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(2), Col(3));
            var target = new Coordinate(Row(4), Col(3));

            //Act
            var result = pawn.IsValidMove(origin, target, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidMove_InvalidBackMove_False()
        {
            //Arrange
            var piecesDisposition = GetEmptyBoard();
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(1), Col(3));
            var target = new Coordinate(Row(0), Col(3));

            //Act
            var result = pawn.IsValidMove(origin, target, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidMove_InvalidDiagonalMove_False()
        {
            //Arrange
            var piecesDisposition = GetEmptyBoard();
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(1), Col(3));
            var target = new Coordinate(Row(2), Col(2));

            //Act
            var result = pawn.IsValidMove(origin, target, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidMove_ValidDiagonalMove_True()
        {
            //Arrange
            string[][] piecesDisposition =
            [ //   0    1    2    3    4    5    6    7
            /*0*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*1*/["_", "_", "_", "♙", "-", "_", "_", "_"],
            /*2*/["_", "_", "♞", "_", "_", "_", "_", "_"],
            /*3*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*4*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*5*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*6*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*7*/["_", "_", "_", "_", "_", "_", "_", "_"]
            ];     
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(1), Col(3));
            var target = new Coordinate(Row(2), Col(2));

            //Act
            var result = pawn.IsValidMove(origin, target, board);

            //Assert
            Assert.IsTrue(result);
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
            /*1*/["_", "_", "_", "♙", "-", "_", "_", "_"],
            /*2*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*3*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*4*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*5*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*6*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*7*/["_", "_", "_", "_", "_", "_", "_", "_"]
            ];

            return piecesDisposition;
        }
    }
}
