namespace SalesManPrb2
{
    class Point
    {
        private string name;
        private double[] coord;

        public Point(string name, double[] coord)
        {
            Name = name;
            Coord = coord;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double[] Coord
        {
            get { return coord; }
            set { coord = value; }
        }
    }
}