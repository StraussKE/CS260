//  based on
//  heapSort.cpp
//
//  Created by BaileyJ on 5/15/19.
//
//  Transpiled by Katie Strauss 11/12/2019

namespace Sorts
{
    public class HeapSort
    {
        int[] mySortedHeap;
        public HeapSort(int[] theArray, int length)
        {
            mySortedHeap = DoHeapSort(theArray, length);
        }
        public int[] GetSortedHeap()
        {
            return mySortedHeap;
        }
        // private methods to get parent and children
        private int GetParent(int index)
        {
            return (index - 1) / 2;
        }
        private int GetLeft(int index)
        {
            return 2 * index + 1;
        }
        private int GetRight(int index)
        {
            return 2 * index + 2;
        }

        private void Swap(int [] theArray, int location1, int location2)
        {
            int temp = theArray[location1];
            theArray[location1] = theArray[location2];
            theArray[location2] = temp;
        }

        // recursive method to restore heap after adding an item
        private void BubbleUp(int [] theArray, int index)
        {
            // if we are at the root, no more work to do
            if (index == 0)
                return;

            // now see if need to do a swap with parent
            int parent = GetParent(index);

            if (theArray[parent] < theArray[index])
            {
                Swap(theArray, parent, index);

                // now go on up tree
                BubbleUp(theArray, parent);
            }

            // already in order, quit
            else
                return;
        }

        // recursive method to restore heap after removing an item
        private void TrickleDown(int [] theArray, int length, int index)
        {
            int left = GetLeft(index);
            int right = GetRight(index);

            // if no children, then a leaf node, quit
            if (left >= length)
                return;

            // only a left child
            if (right >= length)
            {
                // do we need to swap it?
                if (theArray[left] > theArray[index])
                {
                    Swap(theArray, left, index);

                    // and go on down
                    TrickleDown(theArray, length, left);
                }
                // do nothing otherwise

            }
            // two children
            else
            {
                // find out which is larger
                if (theArray[left] > theArray[right])
                {
                    // do we need to swap it?
                    if (theArray[left] > theArray[index])
                    {
                        Swap(theArray, left, index);

                        // and go on down
                        TrickleDown(theArray, length, left);
                    }
                }
                else
                {
                    // do we need to swap it?
                    if (theArray[right] > theArray[index])
                    {
                        Swap(theArray, right, index);

                        // and go on down
                        TrickleDown(theArray, length, right);
                    }
                }
            }
        }

        private int[] DoHeapSort(int[] theArray, int length)
        {
            // heapify the array

            for(int i = 0; i < length; i++)
                BubbleUp(theArray, i);

            for (int i = length - 1; i > 0; i--)
                TrickleDown(theArray, length, i);


            // sort the array
            for (int i = length - 1; i > 0; i--)
            {
                Swap(theArray, 0, i);
                TrickleDown(theArray, i, 0);
            }

            return theArray;
        }
    }
}
