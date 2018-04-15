/* 
 * Date: 04/14/2018
 * Author: Mohamed Sheikh
 * Description: Second attempt to solve TSP
 */

using System.Collections.Generic;

namespace SalesManPrb2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double[]> coordinates = new Dictionary<string, double[]>
            {
                { "A", new double[] {-3, 0} }, { "B", new double[] {-1.8, -1.6} }, { "C", new double[] {0, -2} }, { "D", new double[] {1.8, -1.6} },
                { "E", new double[] {2, 0} }, { "F", new double[] {1.8, 1.6} }, { "G", new double[] {0, 2} }, { "H", new double[] {-1.8, 1.6} },
                { "I", new double[] {-2, 0} }, { "J", new double[] {-1, -1} }, { "K", new double[] {0, -1} }, { "L", new double[] {1, -1} },
                { "M", new double[] {1, 0} }, { "N", new double[] {1, 1} }, { "O", new double[] {0, 1} }, { "P", new double[] {-1, 1} },
                { "Q", new double[] {-1, 0} }, { "R", new double[] {0, 0} },
            };

            SalesMan aSolution = new SalesMan(coordinates);
            aSolution.Calculate();
        }
    }
}
