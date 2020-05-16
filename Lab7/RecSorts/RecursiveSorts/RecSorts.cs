//
//  recSorts.cpp
//  SortingLab
//
//  code for heapSort and MergeSort
//  both will do min to max
//
//  Created by jim bailey on 11/15/19.
//  Copyright © 2019 jim bailey. All rights reserved.
//
//  Transpiled by Katie Strauss 5/16/2020

using System;

namespace RecursiveSorts
{
    public static class RecSorts
    {

        //===============
        // HEAP SORT
        //===============

        // private methods for heapSort
        // private methods to get parent and children
        private static int GetParent(int index)
        {
            return (index - 1) / 2;
        }
        private static int GetLeft(int index)
        {
            return 2 * index + 1;
        }
        private static int GetRight(int index)
        {
            return 2 * index + 2;
        }

        // helper function to swap array elements between two index locations
        private static void Swap(int[] theArray, int location1, int location2)
        {
            int temp = theArray[location1];
            theArray[location1] = theArray[location2];
            theArray[location2] = temp;
        }

        // recursive method to restore heap after adding an item
        private static void BubbleUp(int []theArray, int index)
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
                BubbleUp(theArray, parent);
            }

            // already in order, quit
            else
                return;
        }

        // recursive method to restore heap after removing an item
        private static void TrickleDown(int [] theArray, int length, int index)
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

        public static void HeapSort(int [] theArray, int length)
        {
            // heapify the array
            /*
            for(int i = 0; i < length; i++)
                BubbleUp(theArray, i);
             */
            for (int i = length - 1; i >= 0; i--)
                TrickleDown(theArray, length, i);


            // sort the array
            for (int i = length - 1; i > 0; i--)
            {
                Swap(theArray, 0, i);
                TrickleDown(theArray, i, 0);
            }
        }

        //===============
        // MERGE SORT
        //===============
        // private methods for Merge sort

        private static int[] Merge(int [] theArray, int low1, int high1, int low2, int high2)
        {
            int length = high2 - low1 + 1;

            int [] newArray = new int[length];

            int index1 = low1, index2 = low2, newIndex = 0;

            // copy smallest as long as one array still has values
            while (index1 <= high1 && index2 <= high2 )
    {
                if (theArray[index1] < theArray[index2])
                    newArray[newIndex++] = theArray[index1++];
                else
                    newArray[newIndex++] = theArray[index2++];
            }

            // now copy any remaining values
            while (index1 <= high1)
            {
                newArray[newIndex++] = theArray[index1++];
            }
            while (index2 <= high2)
            {
                newArray[newIndex++] = theArray[index2++];
            }
            return newArray;
        }

        private static void RecMergeSort(int [] theArray, int low, int high)
        {
            // base case, if array is length 1, return
            if (high - low < 1)
                return;

            int middle = (high - low) / 2 + low;

            RecMergeSort(theArray, low, middle);
            RecMergeSort(theArray, middle + 1, high);
            int [] newArray = Merge(theArray, low, middle, middle + 1, high);
            int index = 0;
            for (int i = low; i <= high; i++)
                theArray[i] = newArray[index++];

        }


        public static void MergeSort(int [] theArray, int length)
        {
            RecMergeSort(theArray, 0, length - 1);
        }

        //===============
        // QUICK SORT
        //===============
        // private methods for quick sort


        // simple partition.
        // Uses the first location for pivot
        //   better would be to use median of first, last, middle
        //
        // moves elements less than pivot to beginning of array
        //   more efficient use pointers from each side
        //
        private static int Partition(int [] a, int first, int last)
        {
            int p = first;
            int pivotElement = a[first];

            for (int i = first + 1; i <= last; i++)
            {
                /* If you want to sort the list in the other order, change "<=" to ">" */
                if (a[i] <= pivotElement)
                {
                    p++;
                    Swap(a, i, p);
                }
            }
            Swap(a, p, first);

            return p;
        }

        // recursive program that does quicksort
        // pass in the array
        // the lowest index and the highest index
        private static void RecQuickSort(int [] a, int first, int last)
        {
            // if the array is longer than length 1
            // partition it, then QuickSort each sub-array
            if (first < last)
            {
                // partition, then get index of properly placed pivot
                int pivot = Partition(a, first, last);

                //now sort each sub-array
                RecQuickSort(a, first, pivot - 1);
                RecQuickSort(a, pivot + 1, last);
            }
        }  // end recQuickSort()


        public static void QuickSort(int [] theArray, int length)
        {
            RecQuickSort(theArray, 0, length - 1);
        }

        //===============
        // FIND Nth
        //===============
        // private methods for finding the Nth value
        // this is based off of a quicksort, but stops
        // when a value is placed in the nth location


        // simple partition.
        // Uses same partition as quicksort

        // recursive program that does quicksort
        // pass in the array
        // the lowest index and the highest index
        private static void RecFindNth(int [] a, int first, int last, int n, ref int? value)
        {
            // if the array is longer than length 1
            // partition it, then QuickSort each sub-array
            if (first < last)
            {
                // partition, then get index of properly placed pivot
                int pivot = Partition(a, first, last);

                // if pivot in correct spot, we are done
                if (pivot == n)
                    value = a[pivot];

                else
                    // do we need to search lower
                    if (pivot > n)
                    RecFindNth(a, first, pivot - 1, n, ref value);
                // or higher
                else
                    RecFindNth(a, pivot + 1, last, n, ref value);
            }
            else
                value = a[first];

        }  // end recFindNth()


        public static int? FindNth(int [] theArray, int length, int n)
        {
            int? value = null;
            RecFindNth(theArray, 0, length - 1, n, ref value);
            return value;
        }


    }
}
