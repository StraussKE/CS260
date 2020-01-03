//  based on
//  heap_example
//
//  Created by Jim Bailey on 5/15/17.
//  Copyright © 2017 jim. All rights reserved.
//
//  Also based on Katie Strauss Lab 5
//  Created 5/6/2018
//
//  Transpiled by Katie Strauss 11/6/2019

using System;

namespace HeapClasses
{
    public class Heap
    {
        private const int SIZE = 16;
        private int [] theArray;
        private int heap_size;
        private int counter;

        // Constructor, initialize all things
        public Heap(int heap_size = SIZE)
        {
            this.heap_size = heap_size;
            this.counter = 0;
            this.theArray = new int[heap_size];
        }

        // Remove the Largest value from root
        public int Remove()
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
        public void Insert(int value)
        {
            // if array is full, make new one twice as big
            // and copy items to it
            if (counter >= heap_size)
            {
                int [] temp = new int[heap_size * 2];
                for (int i = 0; i < heap_size; i++)
                    temp[i] = theArray[i];
                theArray = temp;
                heap_size *= 2;
            }

            // add item in next spot
            theArray[counter++] = value;

            // and restore heap condition
            BubbleUp(counter - 1);
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

        // helper function to swap array elements between two index locations
        private void Swap(int location1, int location2)
        {
            int temp = theArray[location1];
            theArray[location1] = theArray[location2];
            theArray[location2] = temp;
        }

        // recursive method to restore heap after adding an item
        private void BubbleUp(int index)
        {
            // if we are at the root, no more work to do
            if (index == 0)
                return;

            // now see if need to do a Swap with parent
            int parent = GetParent(index);

            if (theArray[parent] < theArray[index])
            {
                Swap(parent, index);

                // now go on up tree
                BubbleUp(parent);
            }

            // already in order, quit
            else
                return;
        }

        // recursive method to restore heap after removing an item
        private void TrickleDown(int index)
        {
            int left = GetLeft(index);
            int right = GetRight(index);

            // if no children, then a leaf node, quit
            if (left >= counter)
                return;

            // only a left child
            if (left >= counter)
            {
                // do we need to swap it?
                if (theArray[left] < theArray[index])
                {
                    Swap(left, index);

                    // and go on down
                    TrickleDown(left);
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
                        Swap(left, index);

                        // and go on down
                        TrickleDown(left);
                    }
                }
                else
                {
                    // do we need to Swap it?
                    if (theArray[right] > theArray[index])
                    {
                        Swap(right, index);

                        // and go on down
                        TrickleDown(right);
                    }
                }
            }
        }

        public int Largest()
        {
            return theArray[0];
        }
    }
}
