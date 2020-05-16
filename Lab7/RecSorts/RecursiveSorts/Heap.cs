using System;
using System.Collections.Generic;
using System.Text;

namespace RecursiveSorts
{
    public class Heap
    {
        private const int SIZE = 10;
        private int [] theArray;
        private int size;
        private int counter = 0;

        public Heap(int size = SIZE)
        {
            this.size = size;
            this.counter = 0;
            this.theArray = new int[size];
        }

        // private methods to get parent and children of an item
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

        // helper function to swap array elements between two index locations
        private void Swap(int[] theArray, int location1, int location2)
        {
            int temp = theArray[location1];
            theArray[location1] = theArray[location2];
            theArray[location2] = temp;
        }

        // recursively trickle down from root to proper place
        // recursive method to restore heap after removing an item
        private void TrickleDown(int index)
        {
            int left = GetLeft(index);
            int right = GetRight(index);

            // if no children, then a leaf node, quit
            if (left >= counter)
                return;

            // only a left child
            if (right >= counter)
            {
                // do we need to swap it?
                if (theArray[left] < theArray[index])
                {
                    Swap(theArray, left, index);

                    // and go on down
                    TrickleDown(left);
                }
                // do nothing otherwise
            }
            // two children
            else
            {
                // find out which is larger
                if (theArray[left] < theArray[right])
                {
                    // do we need to swap it?
                    if (theArray[left] < theArray[index])
                    {
                        Swap(theArray, left, index);

                        // and go on down
                        TrickleDown(left);
                    }
                }
                else
                {
                    // do we need to swap it?
                    if (theArray[right] < theArray[index])
                    {
                        Swap(theArray, right, index);

                        // and go on down
                        TrickleDown(right);
                    }
                }
            }
        }

        // recursively bubble up from last to proper place
        // recursive method to restore heap after adding an item
        private void BubbleUp(int index)
        {
            // if we are at the root, no more work to do
            if (index == 0)
                return;

            // now see if need to do a swap with parent
            int parent = GetParent(index);

            if (theArray[parent] > theArray[index])
            {
                Swap(theArray, parent, index);

                // now go on up tree
                BubbleUp(parent);
            }

            // already in order, quit
            else
                return;
        }

        // remove the smallest value from root
        public int GetItem()
        {
            // can not take from something that is empty
            if (counter <= 0)
                throw new IndexOutOfRangeException("Removal from empty heap.");

            // save the value for later return
            int value = theArray[0];

            // move last item to root
            theArray[0] = theArray[--counter];

            // restore heap condition
            TrickleDown(0);

            return value;
        }
        // add a new value and update Heap
        public void AddItem(int value)
        {
            // if array is full, make new one twice as big
            // and copy items to it
            if (counter >= size)
            {
                int [] temp = new int[size * 2];
                for (int i = 0; i < size; i++)
                    temp[i] = theArray[i];
                theArray = temp;
                size *= 2;
            }

            // add item in next spot
            theArray[counter++] = value;

            // and restore heap condition
            BubbleUp(counter - 1);
        }
    }
}
