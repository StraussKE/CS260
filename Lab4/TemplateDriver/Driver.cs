//  Based on
//
//  main.cpp
//  binary_search_tree
//
//  Created by Jim Bailey on 11/1/17.
//  Licensed under a Creative Commons Attribution 4.0 International License.
//
//  Transpiled by Katie Strauss 1/22/2020

using System;
using GenericTreeClasses;

namespace GenericDriver
{
    class Driver
    {
        static void Main(string[] args)
        {
            // uncomment function to select a given test

            IntegerTest();
            CharTest();
            StringTest();

            Console.Write("\nAll done");
            Console.Write("\nPress Enter to exit console");
            Console.Read();
        }



        static void IntegerTest() {
            GenericTree<int> fir = new GenericTree<int>();
            int[] int_values = new int[] { 20, 30, 25, 35, 10, 15, 5, 2, 7, 12, 22, 27, 32, 37, 17 };
            const int NUM_INTS = 15;

            Console.Write("\n Testing Tree for integers \n");

            // build a nice noble fir that is balanced
            Console.Write(" First add 15 integer values \n");
            for (int i = 0; i < NUM_INTS; i++)
                fir.InsertItem(int_values[i]);

            // check find
            Console.Write("\n Testing find, should find 5 and 25, not find 21 or 0: \n");
            Console.Write("Looking for 5 " + (fir.IsPresent(5) ? "found" : "not found") + "\n");
            Console.Write("Looking for 25 " + (fir.IsPresent(25) ? "found" : "not found") + "\n");
            Console.Write("Looking for 21 " + (fir.IsPresent(21) ? "found" : "not found") + "\n");
            Console.Write("Looking for 0 " + (fir.IsPresent(0) ? "found" : "not found") + "\n");

            // delete 10 and see if still there
            Console.Write("\n Now testing delete, 10 should be there and then gone \n");
            Console.Write("Looking for 10 " + (fir.IsPresent(10) ? "found" : "not found") + "\n");
            fir.RemoveItem(10);
            Console.Write("Looking for 10 " + (fir.IsPresent(10) ? "found" : "not found") + "\n");

            // Now add 10 back
            Console.Write("\n Now seeing if adding 10 back works \n");
            fir.InsertItem(10);
            Console.Write("Looking for 10 " + (fir.IsPresent(10) ? "found" : "not found") + "\n");

            Console.Write("\n Pre-order traversal \n Should be:  20   10    5    2    7   15   12   17   30   25   22   27   35   32   37 \n");
            Console.Write(" and is:  " + fir.preOrder() + "\n");
            Console.Write("\n In-order traversal \n Should be:   2    5    7   10   12   15   17   20   22   25   27   30   32   35   37 \n");
            Console.Write(" and is:  " + fir.inOrder() + "\n");
            Console.Write("\n Post-order traversal \n Should be:   2    7    5   12   17   15   10   22   27   25   32   37   35   30   20 \n");
            Console.Write(" and is:  " + fir.postOrder() + "\n");

            Console.Write("\n \n Done with integer tests \n \n");
        }

        static void CharTest() {
            GenericTree<char> apple = new GenericTree<char>();
            char[] char_values = new char[] { 'M', 'G', 'T', 'D', 'J', 'Q', 'X', 'B', 'F', 'I', 'K', 'O', 'S', 'W', 'Y' };
            const int NUM_CHARS = 15;

            Console.Write("\n Testing Tree for characters  \n");

            // build a nice apple fir that is balanced
            Console.Write(" First add 15 character values  \n");
            for (int i = 0; i < NUM_CHARS; i++)
                apple.InsertItem(char_values[i]);

            // check find
            Console.Write("\n Testing find, should find T and M, not find R or A:  \n");
            Console.Write("Looking for T " + (apple.IsPresent('T') ? "found" : "not found") + "\n");
            Console.Write("Looking for M " + (apple.IsPresent('M') ? "found" : "not found") + "\n");
            Console.Write("Looking for R " + (apple.IsPresent('R') ? "found" : "not found") + "\n");
            Console.Write("Looking for A " + (apple.IsPresent('A') ? "found" : "not found") + "\n");

            // delete 10 and see if still there
            Console.Write("\n Now testing delete, J should be there and then gone \n");
            Console.Write("Looking for J " + (apple.IsPresent('J') ? "found" : "not found") + "\n");
            apple.RemoveItem('J');
            Console.Write("Looking for J " + (apple.IsPresent('J') ? "found" : "not found") + "\n");

            // Now add 10 back
            Console.Write("\n Now seeing if adding J back works \n");
            apple.InsertItem('J');
            Console.Write("Looking for J " + (apple.IsPresent('J') ? "found" : "not found") + "\n");

            Console.Write("\n Pre-order traversal \n Should be:   M    G    D    B    F    J    I    K    T    Q    O    S    X    W    Y \n");
            Console.Write(" and is:  " + apple.preOrder() + "\n");
            Console.Write("\n In-order traversal \n Should be:   B    D    F    G    I    J    K    M    O    Q    S    T    W    X    Y \n");
            Console.Write(" and is:  " + apple.inOrder() + "\n");
            Console.Write("\n Post-order traversal \n Should be:   B    F    D    I    K    J    G    O    S    Q    W    Y    X    T    M \n");
            Console.Write(" and is:  " + apple.postOrder() + "\n");

            Console.Write("\n \n Done with character tests \n \n");
        }

        static void StringTest()
        {
            GenericTree<string> oak = new GenericTree<string>();
            string[] string_values = new string[]{ "Oak", "Fir", "Ash", "Lime", "Pear", "Pine", "Yew" };
            const int NUM_STRINGS = 7;

            Console.Write("\n Testing Tree for strings  \n");

            // build a nice oak fir that is balanced
            Console.Write(" First add 7 tree names  \n");
            for (int i = 0; i < NUM_STRINGS; i++)
                oak.InsertItem(string_values[i]);

            // check find
            Console.Write("\n  Testing find, should find Oak and Pine, not find Spruce or Maple:  \n");
            Console.Write("Looking for Oak " + (oak.IsPresent("Oak") ? "found" : "not found") + "\n");
            Console.Write("Looking for Pine " + (oak.IsPresent("Pine") ? "found" : "not found") + "\n");
            Console.Write("Looking for Spruce " + (oak.IsPresent("Spruce") ? "found" : "not found") + "\n");
            Console.Write("Looking for Maple " + (oak.IsPresent("Maple") ? "found" : "not found") + "\n");

            // delete 10 and see if still there
            Console.Write("\n Now testing delete, Fir should be there and then gone \n");
            Console.Write("Looking for Fir " + (oak.IsPresent("Fir") ? "found" : "not found") + "\n");
            oak.RemoveItem("Fir");
            Console.Write("Looking for Fir " + (oak.IsPresent("Fir") ? "found" : "not found") + "\n");

            // Now add 10 back
            Console.Write("\n  Now seeing if adding Fir back works \n");
            oak.InsertItem("Fir");
            Console.Write("Looking for Fir " + (oak.IsPresent("Fir") ? "found" : "not found") + "\n");

            Console.Write("\n Pre-order traversal \n Should be: Oak  Fir  Ash Lime Pear Pine  Yew \n");
            Console.Write(" and is:  " + oak.preOrder() + "\n");
            Console.Write("\n In-order traversal \n Should be: Ash  Fir Lime  Oak Pear Pine  Yew \n");
            Console.Write(" and is:  " + oak.inOrder() + "\n");
            Console.Write("\n Post-order traversal \n Should be: Ash Lime  Fir  Yew Pine Pear  Oak \n");
            Console.Write(" and is:  " + oak.postOrder() + "\n");

            Console.Write("\n \n Done with string tests \n \n");

            Console.Write("\n" + oak.displayTree() + "\n");
        }
    }
}