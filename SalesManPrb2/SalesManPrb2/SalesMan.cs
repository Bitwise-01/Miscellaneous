using System;
using System.Collections.Generic;

namespace SalesManPrb2
{
    class SalesMan
    {
        private Point startingCoord;
        private List<Point> aListOfPoints;
        private List<Point> aListOfCoordinates;
        private Dictionary<string, double[]> data;
        private List<Solution> aListOfSolutions = new List<Solution>();

        public SalesMan(Dictionary<string, double[]> data)
        {
            this.data = data;
            AListOfPoints = ParseData(data);
            AListOfCoordinates = ParseData(data);
        }

        public Point StartingCoord
        {
            get { return startingCoord; }
            set { startingCoord = value; }
        }

        public List<Point> AListOfPoints
        {
            get { return aListOfPoints; }
            set { aListOfPoints = value; }
        }

        public List<Point> AListOfCoordinates
        {
            get { return aListOfCoordinates; }
            set { aListOfCoordinates = value; }
        }

        private List<Point> ParseData(Dictionary<string, double[]> data)
        {
            List<Point> _aListOfPoints = new List<Point>();

           foreach(KeyValuePair<string, double[]> point in data)
           {
                Point aNewPoint = new Point(point.Key, point.Value);
                _aListOfPoints.Add(aNewPoint);
           }
            return _aListOfPoints;
        }

        public Solution Solve()
        {
            double score = 0;
            Point here = null;
            Point lastPoint = null;
            List<string> solution = new List<string>();
            
            while(aListOfPoints.Count != 0)
            {
                here = (here == null) ? NextPoint(StartingCoord) : NextPoint(here);
                if (here != null)
                {
                    string data = $"[{here.Name}{ToCoord(here.Coord)}]";
                    solution.Add(data);
                }

                if (lastPoint != null && here != null)
                {
                    score += Distance(here.Coord, lastPoint.Coord);
                }
                lastPoint = here;
            }            
            
            Solution aSolution = new Solution(solution, score);
            return aSolution;            
        }

        private void DisplaySolution(List<string> steps, double score)
        {
            Console.Write("Calculated Route:");
            foreach (var item in steps)
            {
                if (steps.IndexOf(item) == 0) Console.Write("\t{ ");
                Console.Write((steps.IndexOf(item) != (steps.Count - 1)) ? $"{item}, " : $"{item}");
                if (steps.IndexOf(item) == steps.Count - 1) Console.WriteLine(" }");
            }

            Console.WriteLine($"\nScore: {score}");
            Console.ReadLine();            
        }

        public void Calculate()
        {
            foreach(var point in aListOfCoordinates)
            {                  
                StartingCoord = point;
                Solution aSolution = Solve();

                if (aSolution != null)
                {
                    aListOfSolutions.Add(aSolution);
                }

                AListOfPoints = ParseData(data);
            }

            Solution bestSolution = BestSolution();
            DisplaySolution(bestSolution.Steps, bestSolution.Score);
        }

        private Solution BestSolution()
        {
            Solution aSolution = null;
            foreach(var s1 in aListOfSolutions)
            {
                foreach(var s2 in aListOfSolutions)
                {
                    if (aSolution == null)
                        aSolution = s1;

                    Solution _aSolution = (s1.Score < s1.Score) ? s1 : s2;
                    aSolution = (_aSolution.Score < aSolution.Score) ? _aSolution : aSolution;
                }
            }
            return aSolution;
        }

        private string ToCoord(double[] coord)
        {
            List<double> plts = new List<double>();

            foreach(var c in coord)
            {
                plts.Add(c);
            }
            return $"({plts[0]}, {plts[1]})";
        }

        private Point NextPoint(Point here)
        {
            Point closest = null;

            foreach(var p1 in aListOfPoints)
            {
                foreach(var p2 in aListOfPoints)
                {
                    if (p1 == here || p2 == here)
                        continue;
                    if (closest == null)
                        closest = p1;

                    Point _closest = (Distance(here.Coord, p1.Coord) < Distance(here.Coord, p2.Coord)) ? p1 : p2;
                    closest = (Distance(here.Coord, _closest.Coord) < Distance(here.Coord, closest.Coord)) ? _closest : closest;
                }
            }

            int index = 0;
            bool isFound = false;
            foreach(var p in aListOfPoints)
            {                
                if (p == here)
                {
                    isFound = true;
                    break;
                }
                index += 1;
            }

            if (isFound)
                aListOfPoints.RemoveAt(index);
            return closest;
        } 

        /*
        public double Score
        {
            get { return score; }
            set { score = value; }
        }
        */

        private double Distance(double[] c1, double[] c2)
        {
            double x1 = c1[0];
            double y1 = c1[1];
            double x2 = c2[0];
            double y2 = c2[1];
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }
    }
}