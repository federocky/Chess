namespace Chess_DomainModel
{
    public class Coordinate
    {
        private int col { get; set; }
        private int row { get; set; }

        //public Coordinate(char column, int row)
        //{
        //    this.column = column;
        //    this.row = row;
        //}

        public Coordinate(string coordinate)
        {
            this.row = int.Parse(coordinate[1].ToString()) -1; // TODO: puede explotar
            this.col = GetColumn(coordinate);

        }

        public Coordinate(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        private int GetColumn(string coordinate)
        {

            switch (coordinate[0].ToString().ToLower())
            {
                case "a": return 0;
                case "b": return 1;
                case "c": return 2;
                case "d": return 3;
                case "e": return 4;
                case "f": return 5;
                case "g": return 6;
                case "h": return 7;
                default : return -1;
            }
        }

        public int GetColumn()
        {
            return col;
        }

        public int GetRow()
        {
            return row;
        }



    }
}
