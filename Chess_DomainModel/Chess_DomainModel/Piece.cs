using Chess_DomainModel.Enums;
using Chess_DomainModel.Pieces;
using System.Drawing;

namespace Chess_DomainModel
{
    public abstract class Piece
    {
        protected PieceColor color { get; set; }
        private String symbol { get; set; }

        protected Piece(PieceColor color, string symbol)
        {
            this.color = color;
            this.symbol = symbol;
        }

        //TODO: hacer valiación generica de que nadie se puede mover hacia una casilla donde ya hay una ficha de mi mismo color.
        //TODO: validacion generica de que nadie puede quedarse quiero, un origin == target
        //TODO: validacion general de que nadie se puede ir si esto pone en peligro al rey (esta es chunga)
        public abstract bool IsValidMove(Coordinate origin, Coordinate target, IBoard board);

        public bool IsColor(PieceColor color)
        {
            return this.color == color;
        }

        public override string ToString()
        {
            return $"{symbol}";
        }
    }
}