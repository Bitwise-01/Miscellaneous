/* 
 * Date: 03/05/2018
 * Author: Mohamed Sheikh
 * Description: Insertion Algorithm
 */

using System;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Insert n = new Insert();
            string unsorted = n.ToString(); /* for comparing */

            /* if you don't want to see the process change true to false */
            n.displayProcess = true;

            /* invoke the sorting method */
            n.Sort();

            /* display to user & pause */
            Console.WriteLine($"[-] Unsorted: {unsorted}\n[+] Sorted: {n.ToString()}");
            Console.Read();
        }
    }
}
