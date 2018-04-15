using System.Collections.Generic;

namespace SalesManPrb2
{
    class Solution
    {
        private double score;
        private List<string> steps;

        public Solution(List<string> steps, double score)
        {
            Steps = steps;
            Score = score;
        }

        public List<string> Steps
        {
            get { return steps; }
            set { steps = value; }
        }

        public double Score
        {
            get { return score; }
            set { score = value; }
        }
    }
}