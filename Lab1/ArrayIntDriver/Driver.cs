/*
 * Directly transpiled from Jim Bailey's C++ driver for this assignment 
 */

using System;
using IntArray;

namespace ArrayIntDriver
{
    class Driver
    {
        static void Main(string[] args)
        {
            // Uncomment test functions to run

            //TestConstructor();
            //TestSetGet();
            //TestAppend();
            //TestMakeRoom();
            //TestInsertRemove();

            Console.Write("Press Enter to exit console");
            Console.Read();
        }

        static void TestConstructor()
        {
            const int DEFAULT = 10;
            const int OVERLOAD = 15;
            Console.Write("Testing default and overloaded constructors.\n");

            ArrayInt defaultSize = new ArrayInt();
            ArrayInt defineSize = new ArrayInt(OVERLOAD);

            Console.Write("Default size should be " + DEFAULT + " and is " + defaultSize.GetSize() + "\n");
            Console.Write("Overload size should be " + OVERLOAD + " and is " + defineSize.GetSize() + "\n");
            Console.Write("\n\n");
        }

        static void TestSetGet()
        {
            Console.Write("Testing setting values and reading them back\n\n");

            ArrayInt SetGet = new ArrayInt(7);
            Console.Write("Testing invalid SetAt index of -1\n");
            try
            {
                SetGet.SetAt(-1, 12);
                Console.Write("Should have thrown an exception\n");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.Write("Caught out of range with message: " + e.Message + "\n");
            }
            catch (Exception)
            {
                Console.Write("Caught something weird \n");
            }

            Console.Write("\nNow loading some values and displaying themn");
            SetGet.SetAt(0, 3);
            SetGet.SetAt(2, 7);
            SetGet.SetAt(1, 5);
            SetGet.SetAt(4, 13);
            SetGet.SetAt(3, 11);
            SetGet.SetAt(5, 17);

            Console.Write("The values should be:  3, 5, 7, 11, 13, 17, unknown value\n");
            Console.Write("The values really are: ");
            for (int i = 0; i < 6; i++)
                Console.Write(SetGet.GetAt(i) + ", ");
            Console.Write(SetGet.GetAt(6) + "\n");

            Console.Write("\nTesting invalid GetAt index that is larger than array size\n");
            try
            {
                SetGet.GetAt(7);
                Console.Write("Should have thrown an exception\n");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.Write("Caught out of range with message: " + e.Message + "\n");
            }
            catch (Exception)
            {
                Console.Write("Caught something weird \n");
            }
            Console.Write("\n\n");
        }

        static void TestAppend()
        {
            Console.Write("Testing append with mix of appends and sets\n\n");

            ArrayInt appends = new ArrayInt();

            appends.Append(2);
            appends.Append(4);
            appends.SetAt(3, 16);
            appends.Append(32);

            Console.Write("The array should be: 2, 4, unknown, 16, 32\n");
            Console.Write("The array really is: ");
            for (int i = 0; i < 4; i++)
                Console.Write(appends.GetAt(i) + ", ");
            Console.Write(appends.GetAt(4) + "\n");

            Console.Write("\n\n");
        }

        static void TestMakeRoom()
        {
            const int START = 7;
            const int UPDATE = 12;
            Console.Write("Testing SetSize and auto expansion on appends\n\n");

            ArrayInt room = new ArrayInt(START);
            Console.Write("Starting size should be " + START + " and is " + room.GetSize() + "\n");
            room.SetSize(UPDATE);
            Console.Write("After SetSize, size should be " + UPDATE + " and is " + room.GetSize() + "\n");
            Console.Write("\nGet at 8 should succeed, get at 12 should fail \n");
            try
            {
                room.GetAt(8);
                Console.Write("Get at 8 succeeded\n");
            }
            catch (Exception)
            {
                Console.Write("Get at 8 failed\n");
            }
            try
            {
                room.GetAt(12);
                Console.Write("Get at 12 succeeded\n");
            }
            catch (Exception)
            {
                Console.Write("Get at 12 failed\n");
            }

            Console.Write("\nNow going to fill array and see if expands\n");
            for (int i = 0; i < UPDATE; i++)
                room.Append(2 * i + 1);
            Console.Write("Filled with 12 values, no problem\n");
            Console.Write("Size should still be " + UPDATE + " and is " + room.GetSize() + "\n");
            Console.Write("\nAdding one more\n");
            room.Append(25);
            Console.Write("Size should now be " + 2 * UPDATE + " and is " + room.GetSize() + "\n");

            Console.Write("\nDisplaying values, should be odd numbers 1 - 25\n");
            for (int i = 0; i <= UPDATE; i++)
                Console.Write(room.GetAt(i) + " ");

            Console.Write("\n\n");
        }

        static void TestInsertRemove()
        {
            const int BEGIN = 10;
            Console.Write("Testing insert and remove \n\n");

            ArrayInt insertRemove = new ArrayInt();
            for (int i = 0; i < BEGIN; i++)
                insertRemove.Append(2 * i);
            Console.Write("Array starting with: ");
            for (int i = 0; i < BEGIN; i++)
                Console.Write(insertRemove.GetAt(i) + " ");
            Console.Write("\nSize should be " + BEGIN + " and is " + insertRemove.GetSize() + "\n");

            Console.Write("\nNow inserting the numbers 5, 9, and 13\n");
            insertRemove.InsertAt(7, 13);
            insertRemove.InsertAt(5, 9);
            insertRemove.InsertAt(3, 5);
            Console.Write("Size should be " + 2 * BEGIN + " and is " + insertRemove.GetSize() + "\n");
            Console.Write("The values should be:  0 2 4 5 6 8 9 10 12 13 14 16 18\n");
            Console.Write("The values really are: ");
            for (int i = 0; i < BEGIN + 3; i++)
                Console.Write(insertRemove.GetAt(i) + " ");

            Console.Write("\n\nNow removing the values: ");
            Console.Write(insertRemove.RemoveAt(8) + " "
                        + insertRemove.RemoveAt(5) + " "
                        + insertRemove.RemoveAt(0) + "\n");
            Console.Write("The array should be: 2 4 5 6 9 10 13 14 16 18 \n");
            Console.Write("The array really is: ");
            for (int i = 0; i < BEGIN; i++)
                Console.Write(insertRemove.GetAt(i) + " ");

            Console.Write("\n\nNow testing illegal inserts and removes \n");
            Console.Write("\nTesting invalid InsertAt at index larger than array size\n");
            try
            {
                insertRemove.InsertAt(BEGIN * 3, -1);
                Console.Write("Should have thrown an exception\n");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.Write("Caught out of range with message: " + e.Message + "\n");
            }
            catch (Exception)
            {
                Console.Write("Caught something weird \n");
            }
            Console.Write("\nTesting RemoveAt on empty array\n");
            try
            {
                for (int i = 0; i < BEGIN * 3; i++)
                    insertRemove.RemoveAt(0);
                Console.Write("Should have thrown an exception\n");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.Write("Caught out of range with message: " + e.Message + "\n");
            }
            catch (Exception)
            {
                Console.Write("Caught something weird \n");
            }
            Console.Write("\n\n");

        }
    }
}
