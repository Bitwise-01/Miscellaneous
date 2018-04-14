using System;
using System.Collections.Generic;

namespace SalesManPrb
{
    class SalesMan
    {
        private double score = 0;
        private List<Location> aListOfLocations = new List<Location>();

        public SalesMan(Dictionary<string, double> data)
        {
            foreach(KeyValuePair<string, double> item in data)
            {
                Location aLocation = new Location(item.Key, item.Value);
                aListOfLocations.Add(aLocation);
            }
        }

        public void Solution()
        {
            bool isHere = false;
            Location here = null;
            List<string> solution = new List<string>();
            Location lastLocation = aListOfLocations[0];

            while(aListOfLocations.Count != 1)
            {
                here = (isHere) ? NewLocation(here) : aListOfLocations[0];
                if (!isHere) { isHere = true; }
                else { Score += Math.Abs(here.Distance - lastLocation.Distance); }
                solution.Add($"{here.Name}[{here.Distance}]");
                lastLocation = here;
            }

           foreach(var item in solution)
           {
                Console.Write((solution.IndexOf(item) != (solution.Count - 1)) ? $"{item}, " : $"{item}\n");
           }

            Console.WriteLine($"Score: {Score-1}");
            Console.ReadLine();
        }

        private Location NewLocation(Location here)
        {
            bool isLastLocation = false;
            Location newLocation = null;
            Location lastLocation = null;

            foreach(var p1 in aListOfLocations)
            {
                foreach(var p2 in aListOfLocations)
                {
                    if ((p1 == here) || (p2 == here))
                    {
                        continue;
                    }

                    newLocation = GetNewLocation(here, p1, p2);
                    if (!isLastLocation)
                    {
                        isLastLocation = true;
                        lastLocation = newLocation;
                    } 
                    else
                    {
                        lastLocation = GetNewLocation(here, newLocation, lastLocation);
                    }
                }
            }

            if (isLastLocation)
            {
                int indexOfHere = aListOfLocations.FindIndex(l => l.Distance == here.Distance);
                aListOfLocations.RemoveAt(indexOfHere);
            }
            return lastLocation;
        }

        public double Score
        {
            get { return score; }
            set { score = value; }
        }

        private Location GetNewLocation(Location here, Location p1, Location p2)
        {
            return Math.Abs(here.Distance - p1.Distance) <= Math.Abs(here.Distance - p2.Distance) ? p1 : p2;
        }
    }
}