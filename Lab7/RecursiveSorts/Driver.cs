//  Based on
//  main.cpp
//  HeapSort Lab
//  and
//  MergeSort Problem from Spring term 2019
//
//  Created by Jim Bailey on 5/15/19.
//
//  Transpiled by Katie Strauss 11/13/2019

using System;
using Sorts;

namespace Lab7HeapSort
{
    class Driver
    {
        static void Main()
        {
            // Uncomment line to run test

            // TestHeapSort();
            // TestMergeSort();

            Console.Write("Press Enter to exit.");
            Console.Read();
        }

        // generic Display method
        static void Display(int[] theArray, int length)
        {
            const int LINE_LEN = 10;
            const int NUM_WID = 4;

            for (int i = 0; i < length; i++)
            {
                Console.Write(theArray[i].ToString().PadLeft(NUM_WID));
                if ((i + 1) % LINE_LEN == 0)
                    Console.Write("\n");
            }
            Console.Write("\n");
        }

        // load array with random numbers
        static void Init(int[] theArray, int length)
        {
            var rand = new Random();

            const int MAX = 99;
            const int MIN = 1;

            for (int i = 0; i < length; i++)
                theArray[i] = rand.Next(MIN, MAX);
        }

        static void TestHeapSort()
        {
            // create the array
            const int SIZE = 20;
            int[] values = new int[SIZE];

            // Initialize it with random numbers
            Init(values, SIZE);

            Console.Write("The unsorted data is \n");
            Display(values, SIZE);

            // sort it
            values = new HeapSort(values, SIZE).GetSortedHeap();

            Console.Write("The sorted data is \n");
            Display(values, SIZE);
        }

        static void TestMergeSort()
        {
            // define arrays
            const int SIZE1 = 7;
            const int SIZE2 = 5;
            int[] arr1 = new int[SIZE1] { 0, 1, 3, 5, 7, 9, 10 };
            int[] arr2 = new int[SIZE2] { 2, 4, 8, 11, 12 };

            Console.Write("Array one is \n");
            Display(arr1, SIZE1);
            Console.Write("Array two is \n");
            Display(arr2, SIZE2);

            Console.Write("\nThe merged result is \n");
            int[] result = new int[SIZE1 + SIZE2];
            result = new MergeSort(result, arr1, arr2, SIZE1, SIZE2).GetSortedArray();
            Display(result, SIZE1 + SIZE2);

            // create the array
            const int SIZE = 50;
            int[] values = new int[SIZE];

            // Initialize it with random numbers
            Init(values, SIZE);

            Console.Write("The unsorted data is \n");
            Display(values, SIZE);

            // sort it
            values = new MergeSort(values, SIZE).GetSortedArray();

            Console.Write("The sorted data is \n");
            Display(values, SIZE);
        }
    }
}