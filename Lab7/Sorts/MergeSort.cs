//  Based on
//  main.cpp
//  MergeSort Problem from Spring term 2019
//
//  Created by Jim Bailey]
//
//  Transpiled by Katie Strauss 11/12/2019

namespace Sorts
{
    public class MergeSort
    {
        int[] sortedArray;
        public MergeSort(int[] theArray, int length)
        {
            DoMergeSort(theArray, length);
            sortedArray = theArray;
        }

        public MergeSort(int[] result, int[] arr1, int[] arr2, int length1, int length2)
        {
            Merger(result, arr1, arr2, length1, length2);
            sortedArray = result;
        }
        public int[] GetSortedArray()
        {
            return sortedArray;
        }

        public void DoMergeSort(int[] theArray, int length)
        {
            if (length == 1)
                return;

            int sub1 = length / 2;
            int sub2 = length - sub1;

            int[] arr1 = new int[sub1];
            int[] arr2 = new int[sub2];

            int index = 0;
            for (int i = 0; i < sub1; i++)
                arr1[i] = theArray[index++];
            for (int i = 0; i < sub2; i++)
                arr2[i] = theArray[index++];

            DoMergeSort(arr1, sub1);
            DoMergeSort(arr2, sub2);

            Merger(theArray, arr1, arr2, sub1, sub2);
        }

        public void Merger(int[] result, int[] arr1, int[] arr2, int length1, int length2)
        {
            int index1 = 0, index2 = 0, indexRes = 0;

            while (index1 < length1 && index2 < length2)
                if (arr1[index1] < arr2[index2])
                    result[indexRes++] = arr1[index1++];
                else
                    result[indexRes++] = arr2[index2++];

            while (index1 < length1)
                result[indexRes++] = arr1[index1++];

            while (index2 < length2)
                result[indexRes++] = arr2[index2++];
        }
    }
}
