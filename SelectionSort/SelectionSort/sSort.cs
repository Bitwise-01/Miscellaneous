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
    class sSort
    {
        private int index = 0;
        private int current_lowest = 0;
        private int[] nlist = { 2, 5, 3, 1, 0, 4 };

        public void Sort()
        {
            for(int n=0; n<nlist.Length; n++)
            {                
                for(int i=index; i<nlist.Length; i++)
                {
                    if (nlist[current_lowest] > nlist[i])
                        current_lowest = i;
                }

                int a = nlist[index];
                int b = nlist[current_lowest];

                nlist[index] = b;
                nlist[current_lowest] = a;

                index += 1;
                current_lowest = index;
            }
        }

        public override string ToString()
        {
            string n = "{ ";

            for(int i=0; i<nlist.Length; i++)
            {
                n += nlist[i] + ((i==nlist.Length-1) ? " }" : ", ");
            }
            return n;
        }
    }
}
