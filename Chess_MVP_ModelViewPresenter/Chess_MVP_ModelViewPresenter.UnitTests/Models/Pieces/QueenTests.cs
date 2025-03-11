using Chess_MVP_ModelViewPresenter.Enums;
using Chess_MVP_ModelViewPresenter.Models;
using Chess_MVP_ModelViewPresenter.Models.Pieces;
using Xunit;

namespace Chess_MVP_ModelViewPresenter.UnitTests.Models.Pieces
{
    public class QueenTests
    {
        private Board board;
        private Queen queen;

        public QueenTests()
        {
            board = new Board();
            queen = new Queen(PieceColor.White);
        }


        [Fact]
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
            Assert.True(result);
        }

        [Fact]
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
            Assert.True(result);
        }

        [Fact]
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
            Assert.True(result);
        }

        [Fact]
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
            Assert.True(result);
        }


        [Fact]
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
            Assert.True(result);
        }


        [Fact]
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
            Assert.True(result);
        }



        [Fact]
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
            Assert.True(result);
        }



        [Fact]
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
            Assert.True(result);
        }

        [Fact]
        public void IsValidMove_InvalidMovePieceInPath_False()
        {
            //Arrange
            string[][] piecesDisposition = new string[][]
            {             //   0    1    2    3    4    5    6    7
            /*0*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*1*/new string[]{"_", "_", "_", "_", "-", "_", "_", "_"},
            /*2*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*3*/new string[]{"_", "_", "_", "♕", "_", "_", "_", "_"},
            /*4*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*5*/new string[]{"_", "♟", "_", "_", "_", "_", "_", "_"},
            /*6*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*7*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"}
            };

            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(3), Col(3));
            var target = new Coordinate(Row(6), Col(0));

            //Act
            var result = queen.IsValidMove(origin, target, board);

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
            {             //   0    1    2    3    4    5    6    7
            /*0*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*1*/new string[]{"_", "_", "_", "_", "-", "_", "_", "_"},
            /*2*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*3*/new string[]{"_", "_", "_", "♕", "_", "_", "_", "_"},
            /*4*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*5*/new string[]{"_", "-", "_", "_", "_", "_", "_", "_"},
            /*6*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*7*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"}
            };

            return piecesDisposition;
        }
    }
}
