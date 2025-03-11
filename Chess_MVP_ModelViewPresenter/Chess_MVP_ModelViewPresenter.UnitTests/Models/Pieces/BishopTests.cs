using Chess_MVP_ModelViewPresenter.Enums;
using Chess_MVP_ModelViewPresenter.Models;
using Chess_MVP_ModelViewPresenter.Models.Pieces;
using Xunit;

namespace Chess_MVP_ModelViewPresenter.UnitTests.Models.Pieces
{
    public class BishopTests
    {
        private Board board;
        private Bishop bishop;

        public BishopTests()
        {
            board = new Board();
            bishop = new Bishop(PieceColor.White);
        }

        [Fact]
        public void IsValidMove_ValidUpRightMove_True()
        {
            //Arrange
            var piecesDisposition = GetEmptyBoard();
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(3), Col(3));
            var target = new Coordinate(Row(1), Col(5));

            //Act
            var result = bishop.IsValidMove(origin, target, board);

            //Assert
            Assert.True(result);
        }

        [Fact]
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
            Assert.True(result);
        }

        [Fact]
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
            Assert.True(result);
        }

        [Fact]
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
            Assert.True(result);
        }


        [Fact]
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
            Assert.False(result);
        }

        [Fact]
        public void IsValidMove_InvalidMovePieceInPath_False()
        {
            //Arrange
            string[][] piecesDisposition = new string[][]
            {               //  0    1    2    3    4    5    6    7
            /*0*/new string[] {"_", "_", "_", "_", "_", "_", "_", "_"},
            /*1*/new string[] {"_", "_", "_", "_", "-", "_", "_", "_"},
            /*2*/new string[] {"_", "_", "_", "_", "_", "_", "_", "_" },
            /*3*/new string[] {"_", "_", "_", "♗", "_", "_", "_", "_"},
            /*4*/new string[] {"_", "_", "_", "_", "_", "_", "_", "_" },
            /*5*/new string[] {"_", "♟", "_", "_", "_", "_", "_", "_" },
            /*6*/new string[] {"_", "_", "_", "_", "_", "_", "_", "_" },
            /*7*/new string[] {"_", "_", "_", "_", "_", "_", "_", "_" }
            };

            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(3), Col(3));
            var target = new Coordinate(Row(6), Col(0));

            //Act
            var result = bishop.IsValidMove(origin, target, board);

            //Assert
            Assert.False(result);
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
            string[][] piecesDisposition = new string[][]
            { //               0    1    2    3    4    5    6    7
            /*0*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*1*/new string[]{"_", "_", "_", "_", "-", "_", "_", "_"},
            /*2*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_" },
            /*3*/new string[]{"_", "_", "_", "♗", "_", "_", "_", "_"},
            /*4*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*5*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*6*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*7*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_" }
            };

            return piecesDisposition;
        }
    }
}
