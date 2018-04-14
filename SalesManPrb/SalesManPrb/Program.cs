/*
 * Date: 04/14/2018
 * Author: Mohamed Sheikh
 * Description: Find a solution to the travelling salesman problem
 */

using System.Collections.Generic;

namespace SalesManPrb
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> data = new Dictionary<string, double>
            {
                {"B", 2},
                {"A", 1},
                {"C", 3},
                {"D", 4},
            };

            SalesMan aSalesMan = new SalesMan(data);
            aSalesMan.Solution();   
        }
    }
}