using Chess_MVC_PassiveView.Enums;
using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Models.Pieces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chess_MVC_PassiveVies.UnitTests.Models.Pieces
{
    [TestClass]
    public class KnightTests
    {
        private Board board;
        private Knight knight;

        [TestInitialize]
        public void TestInitialize()
        {
            board = new Board();
            knight = new Knight(PieceColor.White);
        }

        [TestMethod]
        public void IsValidMove_ValidMoveFoward_True()
        {
            //Arrange
            var origin = new Coordinate("b1");
            var target = new Coordinate("a3");

            //Act
            var result = knight.IsValidMove(origin, target, board);

            //Assert
            Assert.IsTrue(result);            
        }

        [TestMethod]
        public void IsValidMove_ValidMoveBackward_True()
        {
            //Arrange
            var origin = new Coordinate("a4");
            var target = new Coordinate("b2");

            //Act
            var result = knight.IsValidMove(origin, target, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidMove_InvalidMoveStraight_False()
        {
            //Arrange
            var origin = new Coordinate("b1");
            var target = new Coordinate("b3");

            //Act
            var result = knight.IsValidMove(origin, target, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidMove_InvalidMoveDiagonal_False()
        {
            //Arrange
            var origin = new Coordinate("b1");
            var target = new Coordinate("d3");

            //Act
            var result = knight.IsValidMove(origin, target, board);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
