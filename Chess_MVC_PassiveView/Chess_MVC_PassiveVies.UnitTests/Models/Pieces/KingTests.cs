using Chess_MVC_PassiveView.Enums;
using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Models.Pieces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chess_MVC_PassiveView.UnitTests.Models.Pieces
{
    [TestClass]
    public class KingTests
    {
        private BoardAdapter board;
        private King king;

        [TestInitialize]
        public void TestInitialize()
        {
            board = new BoardAdapter();
            king = new King(PieceColor.White);
        }

        [TestMethod]
        public void IsValidMove_ValidUpMove_True()
        {
            //Arrange
            var piecesDisposition = GetEmptyBoard();
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(3), Col(3));
            var target = new Coordinate(Row(4), Col(3));

            //Act
            var result = king.IsValidMove(origin, target, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidMove_ValidDownMove_True()
        {
            //Arrange
            var piecesDisposition = GetEmptyBoard();
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(3), Col(3));
            var target = new Coordinate(Row(2), Col(3));

            //Act
            var result = king.IsValidMove(origin, target, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidMove_ValidRightMove_True()
        {
            //Arrange
            var piecesDisposition = GetEmptyBoard();
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(3), Col(3));
            var target = new Coordinate(Row(3), Col(4));

            //Act
            var result = king.IsValidMove(origin, target, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidMove_ValidLeftMove_True()
        {
            //Arrange
            var piecesDisposition = GetEmptyBoard();
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(3), Col(3));
            var target = new Coordinate(Row(4), Col(2));

            //Act
            var result = king.IsValidMove(origin, target, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidMove_ValidUpRightMove_True()
        {
            //Arrange
            var piecesDisposition = GetEmptyBoard();
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(3), Col(3));
            var target = new Coordinate(Row(2), Col(4));

            //Act
            var result = king.IsValidMove(origin, target, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidMove_ValidUpLefttMove_True()
        {
            //Arrange
            var piecesDisposition = GetEmptyBoard();
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(3), Col(3));
            var target = new Coordinate(Row(2), Col(2));

            //Act
            var result = king.IsValidMove(origin, target, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidMove_ValidDownLefttMove_True()
        {
            //Arrange
            var piecesDisposition = GetEmptyBoard();
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(3), Col(3));
            var target = new Coordinate(Row(4), Col(2));

            //Act
            var result = king.IsValidMove(origin, target, board);

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
            var target = new Coordinate(Row(4), Col(4));

            //Act
            var result = king.IsValidMove(origin, target, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidMove_ValidCastlingLeft_True()
        {
            //Arrange
            string[][] piecesDisposition =
            [ //   0    1    2    3    4    5    6    7
            /*0*/["♖", "_", "_", "_", "♔", "_", "_", "♖"],
            /*1*/["_", "_", "_", "_", "-", "_", "_", "_"],
            /*2*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*3*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*4*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*5*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*6*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*7*/["_", "_", "_", "_", "_", "_", "_", "_"]
            ];
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(0), Col(4));
            var target = new Coordinate(Row(0), Col(2));

            //Act
            var result = king.IsValidMove(origin, target, board);
            
            //Assert
            Assert.IsTrue(result);
        }

        
        [TestMethod]
        public void IsValidMove_ValidCastlingRight_True()
        {
            //Arrange
            string[][] piecesDisposition =
            [ //   0    1    2    3    4    5    6    7
            /*0*/["♖", "_", "_", "_", "♔", "_", "_", "♖"],
            /*1*/["_", "_", "_", "_", "-", "_", "_", "_"],
            /*2*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*3*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*4*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*5*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*6*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*7*/["_", "_", "_", "_", "_", "_", "_", "_"]
            ];
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(0), Col(4));
            var target = new Coordinate(Row(0), Col(6));

            //Act
            var result = king.IsValidMove(origin, target, board);
            
            //Assert
            Assert.IsTrue(result);
        }

                
        [TestMethod]
        public void IsValidMove_InvalidCastlingRookMoved_False()
        {
            //Arrange
            string[][] piecesDisposition =
            [ //   0    1    2    3    4    5    6    7
            /*0*/["♖", "_", "_", "_", "♔", "_", "_", "♖"],
            /*1*/["_", "_", "_", "_", "-", "_", "_", "_"],
            /*2*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*3*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*4*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*5*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*6*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*7*/["_", "_", "_", "_", "_", "_", "_", "_"]
            ];
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(0), Col(4));
            var target = new Coordinate(Row(0), Col(2));

            var rook = new Rook(PieceColor.White);
            var rookCoordinate = new Coordinate(Row(0), Col(0));
            rook.IsValidMove(rookCoordinate, new Coordinate(Row(0), Col(1)), board);
            board.SetPiece(rook, rookCoordinate);

            //Act
            var result = king.IsValidMove(origin, target, board);
            
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidMove_InvalidCastlingKingMoved_False()
        {
            //Arrange
            string[][] piecesDisposition =
            [ //   0    1    2    3    4    5    6    7
            /*0*/["♖", "_", "_", "_", "♔", "_", "_", "♖"],
            /*1*/["_", "_", "_", "_", "-", "_", "_", "_"],
            /*2*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*3*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*4*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*5*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*6*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*7*/["_", "_", "_", "_", "_", "_", "_", "_"]
            ];
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(0), Col(4));
            var target = new Coordinate(Row(0), Col(2));

            var kingCoordinate = new Coordinate(Row(0), Col(4));
            var result2 = king.IsValidMove(kingCoordinate, new Coordinate(Row(0), Col(3)), board);

            //Act
            var result = king.IsValidMove(origin, target, board);
            
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidMove_InvalidDobleMove_False()
        {
            //Arrange
            var piecesDisposition = GetEmptyBoard();
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(3), Col(3));
            var target = new Coordinate(Row(3), Col(6));

            //Act
            var result = king.IsValidMove(origin, target, board);

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
            /*3*/["_", "_", "_", "♔", "_", "_", "_", "_"],
            /*4*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*5*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*6*/["_", "_", "_", "_", "_", "_", "_", "_"],
            /*7*/["_", "_", "_", "_", "_", "_", "_", "_"]
            ];

            return piecesDisposition;
        }
    }
}
