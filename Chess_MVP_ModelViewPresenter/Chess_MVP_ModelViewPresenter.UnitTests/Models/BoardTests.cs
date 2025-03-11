
using Chess_MVP_ModelViewPresenter.Enums;
using Chess_MVP_ModelViewPresenter.Models;
using Moq;
using Xunit;

namespace Chess_MVP_ModelViewPresenter.UnitTests.Models
{
    public class BoardTests
    {
        private BoardAdapter board;
        private Mock<Piece> pieceMock;


        public BoardTests()
        {
            board = new BoardAdapter();
            pieceMock = new Mock<Piece>(PieceColor.White, "");
            pieceMock.Setup(knight => knight.IsValidMove(It.IsAny<Coordinate>(), It.IsAny<Coordinate>(), It.IsAny<Board>()))
                .Returns(true);                
        }

        [Fact]
        public void IsValidMove_ValidMove_True()
        {
            //Arrange
            var origin = new Coordinate("b1");
            var target = new Coordinate("b3");
            board.SetPiece(pieceMock.Object, origin);

            //Act
            var result = board.IsValidMove(origin, target);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsValidMove_SamePosition_False()
        {
            //Arrange
            var origin = new Coordinate("b1");
            var target = new Coordinate("b1");
            board.SetPiece(pieceMock.Object, origin);

            //Act
            var result = board.IsValidMove(origin, target);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void IsValidMove_MyPieceInTarget_False()
        {
            //Arrange
            var origin = new Coordinate("b1");
            var target = new Coordinate("c1");
            board.SetPiece(pieceMock.Object, origin);

            //Act
            var result = board.IsValidMove(origin, target);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void IsValidMove_MoveProvokeCheck_False()
        {
            //Arrange
            string[][] piecesDisposition = new string[][]
            {
                new string[] { "♜", "♞", "♝", "-", "♚", "♝", "♞", "♜" },
                new string[] { "♟", "♟", "♟", "♟", "-", "♟", "♟", "♟" },
                new string[] { "_", "_", "_", "_", "_", "_", "_", "_" },
                new string[] { "_", "_", "_", "_", "♟", "_", "_", "_" },
                new string[] { "_", "_", "_", "_", "_", "_", "♙", "♛" },
                new string[] { "_", "_", "_", "_", "_", "_", "_", "_" },
                new string[] { "♙", "♙", "♙", "♙", "♙", "♙", "_", "♙" },
                new string[] { "♖", "♘", "♗", "♕", "♔", "♗", "♘", "♖" }
            };

            board.Start(piecesDisposition);

            var origin = new Coordinate(6, 5);
            var target = new Coordinate(5, 5);
            board.SetPiece(pieceMock.Object, origin);

            //Act
            var result = board.IsValidMove(origin, target);

            //Assert
            Assert.False(result);
        }
    }
}
