namespace Chess_MVC_PassiveView.Models
{
    public class Coordinate
    {
        private int col { get; set; }
        private int row { get; set; }


        public Coordinate(string coordinate)
        {
            this.row = int.Parse(coordinate[1].ToString()) - 1;
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
                default: return -1;
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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Coordinate otherCoordinate = (Coordinate)obj;
            return row == otherCoordinate.row && col == otherCoordinate.col;
        }
    }
}
