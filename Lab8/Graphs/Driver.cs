//  Based on
//  main.cpp
//  CS260Lab8
//
//  Created by Jim Bailey on 11/25/17.
//  Licensed under a Creative Commons Attribution 4.0 International License.
//
//  Transpiled by Katie Strauss on 1/5/2020

using System;
using GraphClasses;

namespace Lab8
{
    class Driver
    {
        static void Main(string[] args)
        {
            // define graph
            Graph tree = new Graph();

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
            tree.AddEdge('A', 'C');
            tree.AddEdge('A', 'T');
            tree.AddEdge('A', 'Z');
            tree.AddEdge('X', 'C');
            tree.AddEdge('C', 'K');
            tree.AddEdge('T', 'Q');
            tree.AddEdge('K', 'Q');
            tree.AddEdge('Q', 'J');
            tree.AddEdge('J', 'M');
            tree.AddEdge('Z', 'X');

            Console.Write(tree.DisplayEdges() + "\n\n");

            Console.Write(tree.DisplayMatrix() + "\n\n");

            // display breadth first min tree
            Console.Write(tree.BreadthFirst('Q') + "\n");

            // display depth first min tree
            Console.Write(tree.DepthFirst('Q') + "\n");

            Console.Write("Press enter to close window.");
            Console.Read();
        }
    }
}
