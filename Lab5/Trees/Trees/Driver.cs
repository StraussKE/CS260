using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree234Classes;
using WordTreeClasses;

namespace Lab5Trees
{
    class Driver
    {
        static void Main(string[] args)
        {
            // uncomment to run selected test

            // Test234Tree();
            // TestWordTree();

            Console.Write("Press Enter to close window.");
            Console.Read();
        }

        static void Test234Tree()
        {
            Console.Write( "\n\nTesting 234 Tree\n");
            // define the tree
            Tree234 the234Tree = new Tree234();

            the234Tree.insert(50);
            the234Tree.insert(40);
            the234Tree.insert(60);
            the234Tree.insert(30);
            the234Tree.insert(70);
            the234Tree.insert(80);
            the234Tree.insert(90);
            the234Tree.insert(10);
            the234Tree.insert(20);

            // testing find
            Console.Write( "Looking for 50, should find: " + (the234Tree.find(50) ? "found" : "not found") + "\n");
            Console.Write("Looking for 40 should find: " + (the234Tree.find(40) ? "found" : "not found") + "\n");
            Console.Write("Looking for 55 should not find: " + (the234Tree.find(55) ? "found" : "not found") + "\n");
            Console.Write("Looking for should find: 30 " + (the234Tree.find(30) ? "found" : "not found") + "\n");

            // testing in-order
            Console.Write( the234Tree.inOrder() + "\n");
        }
        static void TestWordTree()
        {
            Console.Write( "\n\nTesting word Tree\n");
            // define the tree
            WordTree theTree = new WordTree();

            // define the data we are using to test
            const int WORDCOUNT = 7;
            string [] data = new string[WORDCOUNT] { "middle", "grape", "apple", "house", "pine", "tree", "never" };

            // load the tree with the data
            for (int i = 0; i < WORDCOUNT; i++)
                theTree.addValue(data[i]);

            // now display it and see how it goes
            Console.Write( "Pre-Order s/b: middle grape apple house pine never tree\n");
            Console.Write( "actually is: " + theTree.preOrder() + "\n\n");

            Console.Write( "In-Order s/b: apple grape house middle never pine tree\n");
            Console.Write( "actually is: " + theTree.inOrder() + "\n\n");

            Console.Write( "Post-Order s/b: apple house grape never tree pine middle\n");
            Console.Write( "actually is: " + theTree.postOrder() + "\n\n");
        }
    }
}
