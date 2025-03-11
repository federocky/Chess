using Chess_MVP_ModelViewPresenter.Enums;
using Chess_MVP_ModelViewPresenter.Models;
using Chess_MVP_ModelViewPresenter.Models.Pieces;
using Xunit;

namespace Chess_MVP_ModelViewPresenter.UnitTests.Models.Pieces
{
    public class KingTests
    {
        private BoardAdapter board;
        private King king;

        public KingTests()
        {
            board = new BoardAdapter();
            king = new King(PieceColor.White);
        }

        [Fact]
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
            Assert.True(result);
        }

        [Fact]
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
            Assert.True(result);
        }

        [Fact]
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
            Assert.True(result);
        }

        [Fact]
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
            Assert.True(result);
        }

        [Fact]
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
            Assert.True(result);
        }

        [Fact]
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
            Assert.True(result);
        }

        [Fact]
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
            Assert.True(result);
        }

        [Fact]
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
            Assert.True(result);
        }

        [Fact]
        public void IsValidMove_ValidCastlingLeft_True()
        {
            //Arrange
            string[][] piecesDisposition = new string[][]
            { //               0    1    2    3    4    5    6    7
            /*0*/new string[]{"♖", "_", "_", "_", "♔", "_", "_", "♖" },
            /*1*/new string[]{"_", "_", "_", "_", "-", "_", "_", "_" },
            /*2*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*3*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*4*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*5*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*6*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*7*/new string[]{ "_", "_", "_", "_", "_", "_", "_", "_"}
            };
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(0), Col(4));
            var target = new Coordinate(Row(0), Col(2));

            //Act
            var result = king.IsValidMove(origin, target, board);

            //Assert
            Assert.True(result);
        }


        [Fact]
        public void IsValidMove_ValidCastlingRight_True()
        {
            //Arrange
            string[][] piecesDisposition = new string[][]
            { //               0    1    2    3    4    5    6    7
            /*0*/new string[]{"♖", "_", "_", "_", "♔", "_", "_", "♖" },
            /*1*/new string[]{"_", "_", "_", "_", "-", "_", "_", "_"},
            /*2*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*3*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*4*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*5*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*6*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*7*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"}
            };

            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(0), Col(4));
            var target = new Coordinate(Row(0), Col(6));

            //Act
            var result = king.IsValidMove(origin, target, board);

            //Assert
            Assert.True(result);
        }


        [Fact]
        public void IsValidMove_InvalidCastlingRookMoved_False()
        {
            //Arrange
            string[][] piecesDisposition = new string[][]
            { //               0    1    2    3    4    5    6    7
            /*0*/new string[]{"♖", "_", "_", "_", "♔", "_", "_", "♖" },
            /*1*/new string[]{"_", "_", "_", "_", "-", "_", "_", "_"},
            /*2*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*3*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*4*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*5*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*6*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*7*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"}
            };

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
            Assert.False(result);
        }

        [Fact]
        public void IsValidMove_InvalidCastlingKingMoved_False()
        {
            //Arrange
            string[][] piecesDisposition = new string[][]
            { //               0    1    2    3    4    5    6    7
            /*0*/new string[]{"♖", "_", "_", "_", "♔", "_", "_", "♖" },
            /*1*/new string[]{"_", "_", "_", "_", "-", "_", "_", "_"},
            /*2*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*3*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*4*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*5*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*6*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*7*/new string[]{"_", "_", "_", "_", "_", "_", "_", "_"}
            };
            board.Start(piecesDisposition);

            var origin = new Coordinate(Row(0), Col(4));
            var target = new Coordinate(Row(0), Col(2));

            var kingCoordinate = new Coordinate(Row(0), Col(4));
            var result2 = king.IsValidMove(kingCoordinate, new Coordinate(Row(0), Col(3)), board);

            //Act
            var result = king.IsValidMove(origin, target, board);

            //Assert
            Assert.False(result);
        }

        [Fact]
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
            { //                0    1    2    3    4    5    6    7
            /*0*/new string []{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*1*/new string []{"_", "_", "_", "_", "-", "_", "_", "_"},
            /*2*/new string []{"_", "_", "_", "_", "_", "_", "_", "_" },
            /*3*/new string []{"_", "_", "_", "♔", "_", "_", "_", "_" },
            /*4*/new string []{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*5*/new string []{"_", "_", "_", "_", "_", "_", "_", "_"},
            /*6*/new string []{"_", "_", "_", "_", "_", "_", "_", "_" },
            /*7*/new string []{ "_", "_", "_", "_", "_", "_", "_", "_" }
            };

            return piecesDisposition;
        }
    }
}

