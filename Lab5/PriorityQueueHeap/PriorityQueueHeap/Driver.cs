//  Based on select sections from
//  main.cpp
//  CS260Lab5
//
//  Created by Jim Bailey on 5/3/18.
//  Copyright © 2018 Jim Bailey. All rights reserved.
//
//  Transpiled by Katie Strauss 11/6/2019

using System;
using HeapClasses;
using PriorityQueueClasses;

namespace Lab5PriorityQueueHeap
{
    class Driver
    {
        static void Main(string[] args)
        {
            // uncomment line to run test

            // TestHeap();
            // TestPriorityQueue();

            Console.Write("Press Enter to close window.");
            Console.Read();
        }

        static void TestHeap()
        {
            Console.Write("Testing heap \n\n");
            const int NUM_HEAP_VALS = 10;
            const int SMALL_HEAP = 5;
            int[] heapValues = new int[NUM_HEAP_VALS] { 10, 5, 30, 15, 20, 40, 60, 25, 50, 35 };

            Heap pile = new Heap(SMALL_HEAP);

            // load the heap with first SMALL_HEAP values
            Console.Write("Loading it with 10, 5, 30, 15, 20\n");
            for (int i = 0; i < SMALL_HEAP; i++)
                pile.Insert(heapValues[i]);

            // display the Largest one
            Console.Write("Displaying Largest value \n");
            Console.Write("Should be 30 and is " + pile.Largest() + "\n\n");

            // now add more values, causing doubling
            Console.Write("Now adding 40, 60, 25, 50, 35, should have doubled size\n\n");
            for (int i = SMALL_HEAP; i < NUM_HEAP_VALS; i++)
                pile.Insert(heapValues[i]);

            // Remove values, should be in descending order
            Console.Write("Removing from Largest to smallest\nExpected results: 60 50 40 35 30 25 20 10 15 5\n");
            Console.Write("Actual results:   ");
            for (int i = 0; i < NUM_HEAP_VALS; i++)
                Console.Write(pile.Remove() + " ");
            Console.Write("\n\n");

            // now test removing from empty heap
            Console.Write("Removing from empty heap\n");
            try
            {
                pile.Remove();
                Console.Write("Failed to catch error\n");
            }
            catch (IndexOutOfRangeException ex) {
                Console.Write("Caught length error with message: " + ex.Message + "\n");
            }
            catch (Exception) {
                Console.Write("Caught something unexpected\n");
            }

            Console.Write("\nDone with Heap Testing\n\n");
        }

        static void TestPriorityQueue()
        {
            Console.Write("Testing Priority Queue of size 15\n\n");

            const int PQ_NUM_VALUES = 15;
            int [] pq_values = new int[PQ_NUM_VALUES] { 1, 13, 21, 3, 5, 7, 9, 11, 15, 23, 17, 19, 25, 27, 29 };

            PriorityQueue theQueue = new PriorityQueue(PQ_NUM_VALUES);

            // load the heap with values
            Console.Write("Loading the queue with first 15 odd numbers in scrambled order\n\n");
            for (int i = 0; i < PQ_NUM_VALUES; i++)
                theQueue.Insert(pq_values[i]);

            Console.Write("Displaying Largest, should be 29 and it is " + theQueue.Peek() + "\n\n");

            // Remove values, should be in ascending order
            Console.Write("Now removing values, should be in descending order\n");
            Console.Write("Actual order: ");
            for (int i = 0; i < PQ_NUM_VALUES; i++)
                Console.Write(theQueue.Remove() + " ");
            Console.Write("\n\n");

            Console.Write("Done with Priority Queue Test. \n\n");
        }
    }
}
