//  Console Test Driver
//
//  Test Program for Lab3
//
//  Created by Jim Bailey on 4/20/17.
//  Licensed under a Creative Commons Attribution 4.0 International License.
//
//
//  Transpiled into C# by Katie Strauss 11/4/2019

using System;
using System.Linq;
using StudentListClasses;
using TextClassClasses;

namespace Lab3LinkedList
{
    class Driver
    {
        static void Main(string[] args)
        {
            // uncomment function to select a given test

            // TextClassTest();
            // IterTest();
            // AppendTest();
            // StudentListTest();

            Console.Write("\nAll done");
            Console.Write("\nPress Enter to exit console");
            Console.Read();
        }

        // testing TextClass
        static void TextClassTest()
        {
            //  testing TextClass

            Console.Write("\nTesting TextClass\n\n");

            TextClass textList1 = new TextClass();

            // check for add and delete head
            textList1.InsertHead('a');
            textList1.InsertHead('b');
            textList1.InsertHead('c');
            Console.Write("\nTesting Insert and delete head, output s/b cba -- is: ");
            Console.Write(textList1.DeleteHead());
            Console.Write(textList1.DeleteHead());
            Console.Write(textList1.DeleteHead() + "\n");

            Console.Write("Testing delete head from an empty list: ");
            try
            {
                textList1.DeleteHead();
                Console.Write("Failed to throw exception\n");
            }
            catch (InvalidOperationException err) {
                Console.Write("Caught error: " + err.Message + "\n");
            }
            catch (Exception) {
                Console.Write("Caught something other than InvalidOperation\n");
            }


            // check for add and delete tail
            textList1.InsertTail('x');
            textList1.InsertTail('y');
            textList1.InsertTail('z');
            Console.Write("\nTesting Insert and delete tail, output s/b zyx -- is: ");
            Console.Write(textList1.DeleteTail());
            Console.Write(textList1.DeleteTail());
            Console.Write(textList1.DeleteTail() + "\n");

            Console.Write("Testing delete tail from an empty list: ");
            try
            {
                textList1.DeleteTail();
                Console.Write("Failed to throw exception\n");
            }
            catch (InvalidOperationException err) {
                Console.Write("Caught error: " + err.Message + "\n");
            }
            catch (Exception) {
                Console.Write("Caught something other than InvalidOperation\n");
            }

            // check for add tail, delete head
            textList1.InsertTail('x');
            textList1.InsertTail('y');
            textList1.InsertTail('z');
            Console.Write("\nTesting Insert tail and delete head, output s/b xyz -- is: ");
            Console.Write(textList1.DeleteHead());
            Console.Write(textList1.DeleteHead());
            Console.Write(textList1.DeleteHead() + "\n");
        }

        static void IterTest()
        {
            TextClass textList2 = new TextClass();

            Console.Write("\nTesting Iter methods \n\n");
            // testing iter methods
            textList2.InsertTail('0');
            textList2.InsertTail('3');
            textList2.InsertTail('5');
            textList2.InsertTail('3');

            // iter find
            Console.Write("\nTesting Iter find, should find 3 and 5 and not find 4\n");
            Console.Write(((textList2.FindKey('3')) ? " found 3" : " did not find 3") + "\n");
            Console.Write(((textList2.FindKey('4')) ? " found 4" : " did not find 4") + "\n");
            Console.Write(((textList2.FindKey('5')) ? " found 5" : " did not find 5") + "\n");

            // iter Insert
            Console.Write("\nTesting Insert, starting string should be 0353, is: " + textList2.DisplayList() + "\n");
            textList2.FindKey('3');
            textList2.InsertKey('1');
            textList2.FindKey('3');
            textList2.InsertKey('6');
            textList2.FindKey('3');
            textList2.InsertKey('2');
            textList2.FindKey('4');
            textList2.InsertKey('7');
            Console.Write("Ending string should be 0123563, is: " + textList2.DisplayList() + "\n");

            //iter delete
            textList2.FindKey('5');
            textList2.DeleteIter();
            Console.Write("\nTesting DeleteIter, ending string should be 012363, is: " + textList2.DisplayList() + "\n");

            // delete key
            textList2.DeleteKey('6');
            Console.Write("\nTesting DeleteKey, ending string should be 01233, is: " + textList2.DisplayList() + "\n");

            //changing a string
            TextClass stringList = new TextClass();
            string stringOne = "That is a test";
            int lengthOne = stringOne.Count();

            for (int i = 0; i < lengthOne; i++)
            {
                stringList.InsertTail(stringOne[i]);
            }
            Console.Write("\nString list starts as: " + stringList.DisplayList() + "\n");
            stringList.FindKey('i');
            stringList.InsertKey('w');
            stringList.InsertKey('a');
            stringList.DeleteIter();
            Console.Write("After changing 'i' to 'wa', list now reads: " + stringList.DisplayList() + "\n");
        }

        static void AppendTest()
        {
            //Testing append

            Console.Write("\nTesting append\n\n");

            TextClass catList = new TextClass();

            string stringCat = "This is a cat";
            int lengthCat = stringCat.Count();

            for (int i = 0; i < lengthCat; i++)
            {
                catList.InsertTail(stringCat[i]);
            }
            Console.Write("Cat list starts as: " + catList.DisplayList() + "\n");


            TextClass dogList = new TextClass();

            string stringDog = "That is a dog";
            int lengthDog = stringDog.Count();

            for (int i = 0; i < lengthDog; i++)
            {
                dogList.InsertTail(stringDog[i]);
            }
            Console.Write("Dog list starts as: " + dogList.DisplayList() + "\n");

            catList.AppendList(dogList);
            Console.Write("\nAfter append, cat list is: " + catList.DisplayList() + "\n");

            catList.FindKey('T');
            catList.FindKey('T');
            catList.InsertKey(' ');
            catList.InsertKey('a');
            catList.InsertKey('n');
            catList.InsertKey('d');
            catList.InsertKey(' ');
            catList.InsertKey('t');
            catList.DeleteIter();

            Console.Write("After changes, cat list is: " + catList.DisplayList() + "\n");
            Console.Write("\nDog list should be unchanged and is: " + dogList.DisplayList() + "\n");
        }
        static void StudentListTest()
        {
            //Testing student list functions

            Console.Write("\nTesting StudentList\n\n");

            // create a list to play with
            StudentList sList = new StudentList();

            // create some students
            Student frodo = new Student("Frodo", 50);
            Student bilbo = new Student("Bilbo", 111);
            Student gandalf = new Student("Gandalf", 500);
            Student pippen = new Student("Pippen", 30);
            Student sam = new Student("Samwise", 40);

            // load the list
            sList.InsertHead(frodo);
            sList.InsertTail(bilbo);
            sList.InsertHead(gandalf);
            sList.InsertTail(pippen);
            sList.InsertHead(sam);

            // check empty
            Console.Write("Checking IsEmpty, should not be empty, is: " + (sList.IsEmpty() ? "empty" : "not empty") + "\n");

            // check find
            Console.Write("Checking find with Sam, should find: " + (sList.FindKey("Samwise") ? "found" : "not found") + "\n");
            Console.Write("Checking find with Merry, should not find: " + (sList.FindKey("Merry") ? "found" : "not found") + "\n");

            // check DeleteKey
            Console.Write("Checking DeleteKey with Pippen, should find: " + (sList.DeleteKey("Pippen") ? "found" : "not found") + "\n");
            Console.Write("Checking DeleteKey with Merry, should not find: " + (sList.DeleteKey("Merry") ? "found" : "not found") + "\n");

            // check DeleteHead
            Console.Write("Checking delete head, should show in order: Samwise Gandalf Frodo Bilbo\n");
            Console.Write("Actually showed: ");
            while (true)
            {
                try
                {
                    Student temp = sList.DeleteHead();
                    Console.Write(temp.GetName() + " ");
                }

                catch (InvalidOperationException err ) {
                    Console.Write("\nCaught error: " + err.Message + "\n");
                    break;
                }
        catch (Exception)
                {
                    Console.Write("\nCaught something other than underflow\n");
                    break;
                }
            }

            // checkikng empty again
            Console.Write("Checking IsEmpty again, should now be empty, is: " + (sList.IsEmpty() ? "empty" : "not empty") + "\n");
        }
    }
}