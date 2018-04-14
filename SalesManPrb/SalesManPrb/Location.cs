namespace SalesManPrb
{
    class Location
    {
        private string name; /* name of the location */
        private double distance; /* distance from initial position */

        public Location(string name, double dist)
        {
            this.Name = name; 
            this.Distance = dist; 
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public double Distance
        {
            get { return this.distance; }
            set { this.distance = value; }
        }
    }
}
