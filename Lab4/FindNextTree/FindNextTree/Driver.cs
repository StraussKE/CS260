//  Node class
//
//  Lab4 FindNextTree
//
//  Created by Jim Bailey on 4/25/20.
//  Licensed under a Creative Commons Attribution 4.0 International License.
//
//
//  Transpiled into C# by Katie Strauss 04/25/20

using System;
using FindNextTreeClasses;

namespace FindNextTreeDriver
{
    class Driver
    {
        static void Main(string[] args)
        {

            DisplayTest();
            FindTest();
            DeleteTest();
            FindNextTest();
            DelNextTest();

            Console.Write("\nAll done");
            Console.Write("\nPress Enter to exit console");
            Console.Read();
        }

        static void DisplayTest()
        {
            Tree fir = new Tree();
            int [] int_values = new int[] { 16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30 };
            const int NUM_EVENS = 15;

            Console.Write("\nTesting insertItem and displayTree\n");

            // build a nice noble fir that is balanced
            Console.Write(" Add and display 15 even integers\n");
            for (int i = 0; i < NUM_EVENS; i++)
                fir.insertItem(int_values[i]);

            // display the tree, should be even integers in order
            Console.Write("  " + fir.displayTree() + "\n");

            Console.Write("\nEnd test insertItem and displayTree\n" + "\n");
        }
        
        static void FindTest()
        {
            Tree oak = new Tree();
            int [] primes = new int[] { 19, 11, 29, 5, 3, 7, 13, 17, 23, 31, 37 };
            const int NUM_PRIMES = 11;

            Console.Write("\nTesting findItem\n");

            // build a nice prime oak
            Console.Write(" Add and display 11 primes\n");
            for (int i = 0; i < NUM_PRIMES; i++)
                oak.insertItem(primes[i]);

            Console.Write("  " + oak.displayTree() + "\n");

            // check find
            Console.Write("\n Should find 5 and 23, not find 21 or 2:\n");
            Console.Write("  Looking for 5 " + (oak.findItem(5) ? "found" : "not found") + "\n");
            Console.Write("  Looking for 23 " + (oak.findItem(23) ? "found" : "not found") + "\n");
            Console.Write("  Looking for 21 " + (oak.findItem(21) ? "found" : "not found") + "\n");
            Console.Write("  Looking for 2 " + (oak.findItem(2) ? "found" : "not found") + "\n");

            Console.Write("\nEnd of test findItem\n" + "\n");

        }

        static void DeleteTest()
        {
            Tree plum = new Tree();
            int []odds = new int[] { 15, 7, 23, 3, 11, 19, 27, 1, 5, 9, 13, 17, 21, 25, 29 };
            const int NUM_ODDS = 15;

            Console.Write("\nTesting deleteItem\n");

            // build a nice odd plum
            Console.Write(" Add and display 15 odd integers\n");
            for (int i = 0; i < NUM_ODDS; i++)
                plum.insertItem(odds[i]);

            Console.Write("  " + plum.displayTree() + "\n");

            // delete 9 && see if still there
            Console.Write("\n Now testing delete, 9 should be there and then gone" + "\n");
            Console.Write("  Looking for 9 " + (plum.findItem(9) ? "found" : "not found") + "\n");
            plum.deleteItem(9);
            Console.Write("  Looking for 9 " + (plum.findItem(9) ? "found" : "not found") + "\n");

            // Now add 9 back
            Console.Write("\n Now seeing if adding 9 back works" + "\n");
            plum.insertItem(9);
            Console.Write("  Looking for 9 " + (plum.findItem(9) ? "found" : "not found") + "\n");

            Console.Write("\nEnd of test deleteItem \n" + "\n");

        }

        static void FindNextTest()
        {
            Tree apple = new Tree();
            int []nums = new int[] { 30, 15, 45, 7, 23, 3, 10, 18, 24, 36, 52, 33, 40, 48, 64 };
            const int NUM_NUMS = 15;

            Console.Write("\nTesting findNext\n");

            // build a nice random apple
            Console.Write(" Add and display 15 integers\n");
            for (int i = 0; i < NUM_NUMS; i++)
                apple.insertItem(nums[i]);

            Console.Write("  " + apple.displayTree() + "\n");

            Console.Write("\n Now testing findNext" + "\n");
            Console.Write("  4 should return 7 and returns " + apple.findNext(4) + "\n");
            Console.Write("  12 should return 15 and returns " + apple.findNext(12) + "\n");
            Console.Write("  30 should return 30 and returns " + apple.findNext(30) + "\n");
            Console.Write("  43 should return 45 and returns " + apple.findNext(43) + "\n");
            Console.Write("  46 should return 48 and returns " + apple.findNext(46) + "\n");
            Console.Write("  90 should return -1 and returns " + apple.findNext(90) + "\n");

            Console.Write("\nEnd of testing findNext\n" + "\n");

        }

        static void DelNextTest()
        {
            Tree pear = new Tree();
            int []vals = new int[] { 15, 8, 24, 4, 11, 19, 30, 2, 7, 10, 13, 16, 22, 28, 34 };
            const int NUM_VALS = 15;

            Console.Write("\nTesting deleteNext\n");

            // build a nice random apple
            Console.Write(" Add and display 15 integers\n");
            for (int i = 0; i < NUM_VALS; i++)
                pear.insertItem(vals[i]);

            Console.Write("\n  " + pear.displayTree() + "\n");

            Console.Write(" Now testing deleteNext" + "\n");
            Console.Write("  5 should return 7 and returns " + pear.deleteNext(5) + "\n");
            Console.Write("   7 should be gone and is " + (pear.findItem(7) ? "found" : "not found") + "\n");
            Console.Write("  19 should return 19 and returns " + pear.deleteNext(19) + "\n");
            Console.Write("   19 should be gone and is " + (pear.findItem(19) ? "found" : "not found") + "\n");

            Console.Write("\nEnd of testing deleteNext\n" + "\n");
        }
    }
}
