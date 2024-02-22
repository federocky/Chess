using Chess_MVC_PassiveView.Enums;
using Chess_MVC_PassiveView.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace Chess_MVC_PassiveView.UnitTests.Models
{
    [TestClass]
    public class BoardTests
    {
        private BoardAdapter board;
        private Mock<Piece> pieceMock;

        [TestInitialize]
        public void TestInitialize()
        {
            board = new BoardAdapter();
            pieceMock = new Mock<Piece>(PieceColor.White, "");
            pieceMock.Setup(knight => knight.IsValidMove(It.IsAny<Coordinate>(), It.IsAny<Coordinate>(), It.IsAny<Board>()))
                .Returns(true);
        }

        [TestMethod]
        public void IsValidMove_ValidMove_True()
        {
            //Arrange
            var origin = new Coordinate("b1");
            var target = new Coordinate("b3");
            board.SetPiece(pieceMock.Object, origin);

            //Act
            var result = board.IsValidMove(origin, target);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidMove_SamePosition_False()
        {
            //Arrange
            var origin = new Coordinate("b1");
            var target = new Coordinate("b1");
            board.SetPiece(pieceMock.Object, origin);

            //Act
            var result = board.IsValidMove(origin, target);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidMove_MyPieceInTarget_False()
        {
            //Arrange
            var origin = new Coordinate("b1");
            var target = new Coordinate("c1");
            board.SetPiece(pieceMock.Object, origin);

            //Act
            var result = board.IsValidMove(origin, target);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidMove_MoveProvokeCheck_False()
        {
            //Arrange
            string[][] piecesDisposition =
            [
                ["♜", "♞", "♝", "-", "♚", "♝", "♞", "♜"],
                ["♟", "♟", "♟", "♟", "-", "♟", "♟", "♟"],
                ["_",  "_", "_",  "_",  "_", "_",  "_",  "_"],
                ["_",  "_", "_",  "_",  "♟", "_", "_",  "_"],
                ["_",  "_", "_",  "_",  "_", "_",  "♙", "♛"],
                ["_",  "_", "_",  "_",  "_", "_",  "_",  "_"],
                ["♙", "♙", "♙", "♙", "♙", "♙",  "_",  "♙"],
                ["♖", "♘", "♗", "♕", "♔", "♗", "♘", "♖"]
            ];

            board.Start(piecesDisposition);

            var origin = new Coordinate(6,5);
            var target = new Coordinate(5,5);
            board.SetPiece(pieceMock.Object, origin);

            //Act
            var result = board.IsValidMove(origin, target);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
