//
//  main.cpp
//  Array_project
//
//  Created by Jim Bailey on 9/30/17.
//  Licensed under a Creative Commons Attribution 4.0 International License.
//
//  Transpiled into C# by Katie Strauss 10/26/2019

using System;

namespace Lab2Dequeue
{
    class Driver
    {
        static void Main(string[] args)
        {
            const int DEF_SIZE = 10;

            // uncomment the lines for the tests
            // you want to run.  Each is separate

            //TestDequeueLifo(DEF_SIZE);                          // tests adding and removing from each side
            //TestDequeueFifo(DEF_SIZE);                          // testing adding from one side and removing from the other
            //TestDequeueWrap(DEF_SIZE);                          // test if the queue wraps from left to right and right to left
            //TestDequeueExcepts(DEF_SIZE);                       // testing removing from empty
            //TestDequeueGrow(DEF_SIZE);                          // testing adding to full queue
            //TestListDequeue();                                  // testing list function
            //TestStack(DEF_SIZE);                                // testing stack using dequeue

            Console.Write("Press Enter to exit console");
            Console.Read();
        }

        static void TestDequeueLifo(int size)
        {
            Console.Write("Testing double ended queue as two LIFOs:\n\n");
            Dequeue aQ = new Dequeue(size);

            Console.Write("Before testing array should be empty and it " + (aQ.IsEmpty() ? "is\n" : "is not\n"));

            Console.Write("first add left, get left\n");
            aQ.AddLeft(1);
            aQ.AddLeft(2);
            aQ.AddLeft(3);
            Console.Write("  last, sb 3 = " + aQ.GetLeft() + " ");
            Console.Write(" next, sb 2 = " + aQ.GetLeft() + " ");
            Console.Write(" first, sb 1 = " + aQ.GetLeft() + "\n");

            Console.Write("\nnext add right, get right\n");
            aQ.AddRight(6);
            aQ.AddRight(7);
            aQ.AddRight(8);
            Console.Write("  last, sb 8 = " + aQ.GetRight() + " ");
            Console.Write(" next, sb 7 = " + aQ.GetRight() + " ");
            Console.Write(" first, sb 6 = " + aQ.GetRight() + "\n");

            Console.Write("\nAfter testing array should be empty and it " + (aQ.IsEmpty() ? "is" : "is not") +"\n\n");

        }

        static void TestDequeueFifo(int size)
        {
            Console.Write("Testing double ended queue as two FIFOs:\n\n");
            Dequeue bQ = new Dequeue(size);

            Console.Write("Before testing array should be empty and it " + (bQ.IsEmpty() ? "is" : "is not") + "\n\n");

            Console.Write("first add left, get right\n");
            bQ.AddLeft(1);
            bQ.AddLeft(2);
            bQ.AddLeft(3);
            Console.Write("  first, sb 1 = " + bQ.GetRight() + " ");
            Console.Write(" next, sb 2 = " + bQ.GetRight() + " ");
            Console.Write(" last, sb 3 = " + bQ.GetRight() + "\n\n");

            Console.Write("\nnow add right, get left\n");
            bQ.AddRight(6);
            bQ.AddRight(7);
            bQ.AddRight(8);
            Console.Write("  first, sb 6 = " + bQ.GetLeft() + " ");
            Console.Write(" next, sb 7 = " + bQ.GetLeft() + " ");
            Console.Write(" last, sb 8 = " + bQ.GetLeft() + "\n");

            Console.Write("\nAfter testing array should be empty and it " + (bQ.IsEmpty() ? "is" : "is not")+ "\n\n");
        }

        static void TestDequeueWrap(int size)
        {
            Dequeue dq = new Dequeue(size);

            Console.Write("Testing wrap from left to right: + \n\n");
            Console.Write("Adding 10 even ints to left, removing four from right\n");
            for (int i = 0; i < 10; i++)
                dq.AddLeft(2 * i);
            Console.Write(" should be: 0  2  4  6  \n");
            Console.Write(" they are:");
            for (int i = 0; i < 4; i++)
                Console.Write(dq.GetRight().ToString().PadLeft(3));
            Console.Write("\n\n");

            Console.Write("Adding 3 more to left \n");
            for (int i = 10; i < 13; i++)
                dq.AddLeft(2 * i);

            Console.Write("Now removing all from the right \n should be: 8 10 12 14 16 18 20 22 24\n");
            Console.Write(" they are:");
            while (!dq.IsEmpty())
                Console.Write(dq.GetRight().ToString().PadLeft(3));
            Console.Write("\n\n");

            Console.Write("Now repeating test from right to left with odd numbers\n");
            for (int i = 0; i < 10; i++)
                dq.AddRight(2 * i + 1);
            Console.Write(" should be: 1  3  5  7 \n");
            Console.Write(" they are:");
            for (int i = 0; i < 4; i++)
                Console.Write(dq.GetLeft().ToString().PadLeft(3));
            Console.Write("\n\n");

            Console.Write("Adding 3 more to right \n");
            for (int i = 10; i < 13; i++)
                dq.AddRight(2 * i + 1);

            Console.Write("Now removing all from the left \n should be: 9 11 13 15 17 19 21 23 25 \n");
            Console.Write(" they are:");
            while (!dq.IsEmpty())
                Console.Write(dq.GetLeft().ToString().PadLeft(3));
            Console.Write("\n");

            Console.Write("\nDone with testing wrap on dequeue.\n\n");
        }

        static void TestDequeueExcepts(int size)
        {
            Console.Write("\nNow testing exceptions\n\n");
                Dequeue eq = new Dequeue(size);

            Console.Write("\nTesting get left on empty queue, should throw exception\n");
            try
            {
                eq.GetLeft();
                Console.Write("Should thrown exception, did not\n");
            }
            catch (IndexOutOfRangeException err) {
                Console.Write("Caught error with message " + err.Message + "\n");
            }
            catch (Exception) {
                Console.Write("Caught some other exception\n");
            }

            Console.Write("\nTesting get right on empty queue, should throw exception\n");
            try
            {
                eq.GetRight();
                Console.Write("Should thrown exception, did not\n");
            }
            catch (IndexOutOfRangeException err) {
                Console.Write("Caught error with message " + err.Message + "\n");
            }
            catch (Exception) {
                Console.Write("Caught some other exception\n");
            }

            Console.Write("\nDone testing exceptions+ \n\n");
        }

        static void TestDequeueGrow(int size)
        {
            Console.Write("Now testing adding to a full array\n\n");

            Dequeue fq = new Dequeue(size);
            Console.Write("Testing overflow when adding to the left\n");
            Console.Write("Adding first ten odd integers to left side of Dequeue \n");
            for (int i = 0; i < 10; i++)
                fq.AddLeft(2 * i + 1);

            Console.Write(" and removing three of them" + "\n should be: 1  3  5 \n");
            Console.Write(" they are:");
            for (int i = 0; i < 3; i++)
                Console.Write(fq.GetRight().ToString().PadLeft(3));
            Console.Write("\n");

            Console.Write("\nNow adding five more, should cause wrap with growth\n");
            for (int i = 10; i < 15; i++)
                fq.AddLeft(2 * i + 1);

            Console.Write("when we remove the remaining values,\n should be: 7  9 11 13 15 17 19 21 23 25 27 29 \n");
            Console.Write(" they are:");
            while (!fq.IsEmpty())
                Console.Write(fq.GetRight().ToString().PadLeft(3));
            Console.Write("\n\n");

            Dequeue gq = new Dequeue(size);

            Console.Write("Now testing overflow when adding to the right\n\n");
            Console.Write("Adding first ten even integers to right side of Dequeue \n");
            for (int i = 0; i < 10; i++)
                gq.AddRight(2 * i);

            Console.Write("First removing three of them" + "\n should be: 0  2  4 \n");
            Console.Write(" they are:");
            for (int i = 0; i < 3; i++)
                Console.Write(gq.GetLeft().ToString().PadLeft(3));
            Console.Write("\n");

            Console.Write("\nNow adding five more, should cause wrap with growth\n");
            for (int i = 10; i < 15; i++)
                gq.AddRight(2 * i);

            Console.Write("when we remove the remaining values" + "\n should be:  6  8 10 12 14 16 18 20 22 24 26 28 \n");
            Console.Write(" they are: ");
            while (!gq.IsEmpty())
                Console.Write(gq.GetLeft().ToString().PadLeft(3));
            Console.Write("\n\n");

            Console.Write("\nDone testing adding to full dequeue\n\n");
        }

        static void TestListDequeue()
        {
            Dequeue cQ = new Dequeue();
            Console.Write("\nNow testing list function:\n\n");
            cQ.AddLeft(33);
            cQ.AddRight(43);
            cQ.AddLeft(34);
            cQ.AddRight(47); ;
            Console.Write("listing left to right:\n  should be   34 33 43 47 \n");
            Console.Write("  actually is " + cQ.ListLeftRight());

            Console.Write("\nEnd of testing list functions\n\n");
        }

        static void TestStack(int size)
        {
            Console.Write("\nNow testing Stack based on Dequeue\n\n");
                Stack aStack = new Stack(size);

            Console.Write("Pushing 6 followed by 7\n");
            aStack.Push(6);
            aStack.Push(7);

            Console.Write(" first Peek, sb 7 = " + aStack.Peek() + "\n");
            Console.Write(" next Pop, sb 7 = " + aStack.Pop() + "\n");
            Console.Write(" final Pop, sb 6 = " + aStack.Pop() + "\n");

            Console.Write("\nNow testing exception on empty stack\n");
            try
            {
                aStack.Pop();
                Console.Write("Should thrown exception, did not\n");
            }
            catch (IndexOutOfRangeException err)
            {
                Console.Write("Caught error with message " + err.Message + "\n");
            }
            catch (Exception)
            {
                Console.Write("Caught some other exception\n");
            }
            Console.Write("\nEnd of testing Stack\n");
        }
    }
}
/*      
        # ifdef TEST_STACK
                
        #endif //TEST_STACK


                return 0;
                }

        }
        }
}
*/
