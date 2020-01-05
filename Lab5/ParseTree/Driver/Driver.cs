//
//  main.cpp
//  CS260Lab5
//
//  Created by Jim Bailey on 5/3/18.
//  Copyright © 2018 Jim Bailey. All rights reserved.
//

using System;
using ParseTreeClasses;

namespace Main
{
    class Driver
    {
        static void Main(string[] args)
        {
            // uncomment function to run test

             TestParseTree();
             TestParseInOrder();

            Console.Write("Press enter to close window.");
            Console.Read();
        }

        static void TestParseTree()
        {
            Console.Write("Testing Parse Tree\n\n");

            string expression1 = "AB+CD-*";
            string expression2 = "AB-C+DE/*";

            ParseTree ptree1 = new ParseTree(expression1);
            Console.Write("Input is AB+CD-* \n");
            Console.Write("In Order should be ((A+B)*(C-D)) or (((A)+(B))*((C)-(D))) and is " + ptree1.InOrder() + "\n");
            Console.Write("Post Order should be AB+CD-* and is " + ptree1.PostOrder() + "\n");
            Console.Write("Pre Order should be *+AB-CD and is " + ptree1.PreOrder() + "\n\n");

            ParseTree ptree2 = new ParseTree(expression2);
            Console.Write("Input is AB-C+DE/* \n");
            Console.Write("In Order output should be (((A-B)+C)*(D/E)) or ((((A)-(B))+(C))*((D)/(E))) and is " + ptree2.InOrder() + "\n");
            Console.Write("Post Order should be AB-C+DE/* and is " + ptree2.PostOrder() + "\n");
            Console.Write("Pre Order should be *+-ABC/DE and is " + ptree2.PreOrder() + "\n");

            Console.Write("Done with Parse Tree test\n\n");
        }

        static void TestParseInOrder()
        {
            Console.Write("Testing In Order Parse Tree\n\n");
    
            string expression3 = "(A+B)*C+D";
            ParseTree ptree3 = new ParseTree("");

            ptree3.ParseInOrder(expression3);
            Console.Write("Input is (A+B)*C+D\n");
            Console.Write("In Order should be (((A+B)*C)+D) or ((((A)+(B))*(C))+(D)) and is " + ptree3.InOrder() + "\n\n");
            Console.Write("Post Order should be AB+C*D+ and is " + ptree3.PostOrder() + "\n");
            Console.Write("Pre Order should be +*+ABCD and is " + ptree3.PreOrder() + "\n\n");
        }
    }
}
