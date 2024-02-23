using Chess_MVC_PassiveView.Enums;
using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Models.Pieces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chess_MVC_PassiveView.UnitTests.Models.Pieces
{
    [TestClass]
    public class BishopTests
    {
        private Board board;
        private Bishop bishop;

        [TestInitialize]
        public void TestInitialize()
        {
            board = new Board();
            bishop = new Bishop(PieceColor.White);
        }

         [TestMethod]
        public void IsValidMove_ValidUpRightMove_True() 
        {
            //Arrange
            var piecesDisposition = GetEmptyBoard();
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(3),Col(3));
            var target = new Coordinate(Row(1),Col(5));

            //Act
            var result = bishop.IsValidMove(origin, target, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidMove_ValidUpLeftMove_True() 
        {
            //Arrange
            var piecesDisposition = GetEmptyBoard();
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(3), Col(3));
            var target = new Coordinate(Row(1), Col(1));

            //Act
            var result = bishop.IsValidMove(origin, target, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidMove_ValidDownRightMove_True()
        {
            //Arrange
            var piecesDisposition = GetEmptyBoard();
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(3), Col(3));
            var target = new Coordinate(Row(5), Col(5));

            //Act
            var result = bishop.IsValidMove(origin, target, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidMove_ValidDownLeftMove_True()
        {
            //Arrange
            var piecesDisposition = GetEmptyBoard();
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(3), Col(3));
            var target = new Coordinate(Row(5), Col(1));

            //Act
            var result = bishop.IsValidMove(origin, target, board);

            //Assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void IsValidMove_InvalidStraightMove_False()
        {
            //Arrange
            var piecesDisposition = GetEmptyBoard();
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(3), Col(3));
            var target = new Coordinate(Row(3), Col(5));

            //Act
            var result = bishop.IsValidMove(origin, target, board);

            //Assert
            Assert.IsFalse(result);
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
            /*3*/["_", "_", "_", "♗", "_", "_", "_", "_"],
            /*4*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*5*/["_", "♟", "_", "_", "_", "_", "_", "_"],
            /*6*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*7*/["_", "_", "_", "_", "_", "_", "_", "_"]
            ];            
            
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(3), Col(3));
            var target = new Coordinate(Row(6), Col(0));

            //Act
            var result = bishop.IsValidMove(origin, target, board);

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
            /*3*/["_", "_", "_", "♗", "_", "_", "_", "_"],
            /*4*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*5*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*6*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*7*/["_", "_", "_", "_", "_", "_", "_", "_"]
            ];

            return piecesDisposition;
        }
    }
}
