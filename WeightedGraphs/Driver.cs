//  based on
//  main.cpp
//  Weighted Graph
//
//  Created by Jim Bailey on 11/25/17.
//  Licensed under a Creative Commons Attribution 4.0 International License.
//
//  This demonstrates the methods of the simple graph class
//
//  Transpiled by Katie Strauss 1/5/2020

using System;
using WeightedGraphClasses;

namespace Lab9
{
    class Driver
    {
        static void Main(string[] args)
        {
            // define graph
            WGraph tree = new WGraph();

            // add ad list nodes
            tree.AddNode('A');
            tree.AddNode('C');
            tree.AddNode('T');
            tree.AddNode('Z');
            tree.AddNode('X');
            tree.AddNode('K');
            tree.AddNode('Q');
            tree.AddNode('J');
            tree.AddNode('M');
            tree.AddNode('U');

            Console.Write(tree.ListNodes() + "\n\n");

            // add and list edges
            // add edges to the tree
            tree.AddWEdge('A', 'C', 3);
            tree.AddWEdge('A', 'T', 4);
            tree.AddWEdge('A', 'Z', 2);
            tree.AddWEdge('X', 'C', 4);
            tree.AddWEdge('C', 'K', 8);
            tree.AddWEdge('T', 'Q', 4);
            tree.AddWEdge('K', 'Q', 3);
            tree.AddWEdge('Q', 'J', 6);
            tree.AddWEdge('J', 'M', 5);
            tree.AddWEdge('Z', 'X', 6);

            Console.Write("The edge list is: \n");
            Console.Write(tree.DisplayWEdges() + "\n\n");

            Console.Write("The adjacency or edge matrix is: \n");
            Console.Write(tree.DisplayMatrix() + "\n\n");

            Console.Write("The min-cost tree starting at Q is: \n");
            Console.Write(tree.MinCostTree('Q') + "\n");

            Console.Write("Press enter to close window.");
            Console.Read();
        }
    }
}