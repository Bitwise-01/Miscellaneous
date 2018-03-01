/*
 * 
 * Date: 02/28/2018
 * Author: Mohamed Sheikh
 * Description: Selection Sort
 * 
 */

using System;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            
            sSort n = new sSort();
            n.Sort();
           
            Console.WriteLine(n.ToString());
            Console.ReadLine();
            
        }
    }
}
