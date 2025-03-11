using Chess_MVP_ModelViewPresenter.Enums;
using Chess_MVP_ModelViewPresenter.Models;
using Chess_MVP_ModelViewPresenter.Models.Pieces;
using Xunit;

namespace Chess_MVP_ModelViewPresenter.UnitTests.Models.Pieces
{


    public class KnightTests
    {
        private Board board;
        private Knight knight;

        public KnightTests()
        {
            board = new Board();        
            knight = new Knight(PieceColor.White);
        }


        [Fact]
        public void IsValidMove_ValidMoveFoward_True()
        {
            //Arrange
            var origin = new Coordinate("b1");
            var target = new Coordinate("a3");

            //Act
            var result = knight.IsValidMove(origin, target, board);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsValidMove_ValidMoveBackward_True()
        {
            //Arrange
            var origin = new Coordinate("a4");
            var target = new Coordinate("b2");

            //Act
            var result = knight.IsValidMove(origin, target, board);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsValidMove_InvalidMoveStraight_False()
        {
            //Arrange
            var origin = new Coordinate("b1");
            var target = new Coordinate("b3");

            //Act
            var result = knight.IsValidMove(origin, target, board);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void IsValidMove_InvalidMoveDiagonal_False()
        {
            //Arrange
            var origin = new Coordinate("b1");
            var target = new Coordinate("d3");

            //Act
            var result = knight.IsValidMove(origin, target, board);

            //Assert
            Assert.False(result);
        }

    }

}
