using System;
using ChainHashClasses;
using StringHashClasses;

namespace Lab6Hashing
{
    class Driver
    {
        const int NUM_VALUES = 10;

        static string [] string_values= new string[NUM_VALUES] { "dog", "god", "cat", "act", "horse", "cow", "elephant", "otter", "seal", "ales" };
        static void Main(string[] args)
        {
            // uncomment function to run tests

            // TestStringHash();
             TestChainedHash();

            Console.Write("Press Enter to close.");
            Console.Read();
        }

        static void TestStringHash()
        {
            // this tests the string hashing code
            // define standard sized table with 11 slots
            StringHash stringHash = new StringHash();

            // place 10 items in a hash table
            // should cause doubling to 22 slots
            for (int i = 0; i < NUM_VALUES; i++)
                stringHash.AddItem(string_values[i]);

            // dump the array
            Console.Write( "Displaying the array before find and delete\n");
            Console.Write( stringHash.DisplayTable() + "\n");

            // now see if find works
            Console.Write( "Looking for pig, should not find -- " + (stringHash.FindItem("pig") ? "found" : "not found") + "\n");
            Console.Write( "Looking for otter, should find -- " + (stringHash.FindItem("otter") ? "found" : "not found") + "\n");

            // now delete otter and see if still found
            Console.Write( "Deleting otter, should work -- " + (stringHash.RemoveItem("otter") ? "found" : "not found") + "\n");
            // now looking again
            Console.Write( "Looking for otter again, should not find -- " + (stringHash.FindItem("otter") ? "found" : "not found") + "\n");

            // dump the array
            Console.Write( "\nDisplaying the array after deleting otter, s/b replaced with _deleted_\n");
            Console.Write( stringHash.DisplayTable() + "\n");
        }

        static void TestChainedHash()
        {
            ChainedHash chainHash = new ChainedHash();

            // place 10 items in a hash table
            for (int i = 0; i < NUM_VALUES; i++)
                chainHash.AddItem(string_values[i]);

            // dump the array
            Console.Write( "Displaying the array before find and delete\n");
            Console.Write( chainHash.DisplayTable() + "\n");

            // now see if find works
            Console.Write( "Looking for pig, should not find -- " + (chainHash.FindItem("pig") ? "found" : "not found") + "\n");
            Console.Write( "Looking for otter, should find -- " + (chainHash.FindItem("otter") ? "found" : "not found") + "\n");

            // now delete otter and see if still found
            Console.Write( "Deleting otter, should work -- " + (chainHash.RemoveItem("otter") ? "found" : "not found") + "\n");
            Console.Write( "Looking for otter again, should not find -- " + (chainHash.FindItem("otter") ? "found" : "not found") + "\n");

            // dump the array
            Console.Write( "\nDisplaying the array after deleting otter, should no longer be there\n");
            Console.Write( chainHash.DisplayTable() + "\n");
        }
    }
}
