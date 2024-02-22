using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess_MVC_PassiveView.Models;

namespace Chess_MVC_PassiveVies.UnitTests.Models.Pieces
{
    [TestClass]
    public class KnightTests
    {
        private Board board;

        [TestInitialize]
        public void TestInitialize()
        {
            board = new Board();
        }

        [TestMethod]
        public void IsValidMove_ValidMove_True()
        {
            //Arrange
            var origin = new Coordinate("b1");
            var target = new Coordinate("a3");

            //Act
            var result = board.IsValidMove(origin, target);

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
            var result = board.IsValidMove(origin, target);

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
            var result = board.IsValidMove(origin, target);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
