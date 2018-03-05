/* 
 * Date: 03/05/2018
 * Author: Mohamed Sheikh
 * Description: Insertion Algorithm
 */

using System;

namespace InsertionSort
{
    class Insert
    {
        public bool displayProcess = true;
        private int[] unsorted = { 8, 2, 9, 7, 3, 1, 11, 14 };

        public void Sort()
        {
            for(int n=0; n<unsorted.Length; n++)
            {
                for(int i=n+1; i<unsorted.Length; i++)
                {
                    /* this method will do it everything */
                    this.Reduce(i); 
                }
            }
        }

        private void Reduce(int index)
        {
            /* for each elements that are in a lower index tha the current index swap them */
            for(int index1=index; index1>=0; index1--)
            {
                for(int index2=index1-1; index2>=0; index2--)
                {
                    if ((this.unsorted[index1] < this.unsorted[index2]) && (index1 > index2))
                    {
                        this.Swap(index1, index2);
                    }
                }
            }
        }

        private void Swap(int index1, int index2)
        {
            if(this.displayProcess)
            {
                Console.WriteLine($"{this.unsorted[index1]} <-> {this.unsorted[index2]}\nBefore: {this.ToString()}");
            }

            int _index1 = this.unsorted[index1];
            int _index2 = this.unsorted[index2];

            this.unsorted[index2] = _index1;
            this.unsorted[index1] = _index2;

            if(this.displayProcess)
            {
                Console.WriteLine($"After: {this.ToString()}\n");
            }
        }

        public override string ToString()
        {
            string n = "{ ";
            for(int i=0; i<this.unsorted.Length; i++)
            {
                n += Convert.ToString(this.unsorted[i]) + ((i == this.unsorted.Length - 1) ? "" : ", ");
            }
            n += " }";
            return n;
        }
    }
}
