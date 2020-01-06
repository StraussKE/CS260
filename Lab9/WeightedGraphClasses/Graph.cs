//  based on WGraph in
//  WGraph.h and WGraph.cpp
//  Example weighted graph
//
//  Created by Jim Bailey on 11/25/17.
//  Licensed under a Creative Commons Attribution 4.0 International License.
//
//  Transpiled by Katie Strauss 1/5/2020

using System;
using System.Collections.Generic;

namespace WeightedGraphClasses
{
    public class WGraph
    {
        private const int SIZE = 20;
        private int numNodes;
        private Node[] nodeList = new Node[SIZE];
        private int[,] edgeMatrix = new int[SIZE, SIZE];

        public WGraph()
        {
            // initialize number of nodes in list
            numNodes = 0;

            // set up edge Matrix to start with no edges
            for (int i = 0; i < SIZE; i++)
                for (int j = 0; j < SIZE; j++)
                    edgeMatrix[i,j] = 0;
        }


        // add a new node to the graph
        // only failure is if graph arrays are full
        public void AddNode(char name)
        {
            // alternately, double the size of everything and start over
            if (numNodes >= SIZE)
                throw new ArgumentOutOfRangeException("WGraph size exceeded!!");

            // create a node with this name
            // initialize it with no edges and not yet visited
            Node temp = new Node();
            temp.name = name;
            temp.visited = false;
            temp.connects = null;

            // add to the list of nodes in graph
            nodeList[numNodes++] = temp;
        }

        // add a new edge to the graph
        // return false and do nothing if either end is invalid
        // otherwise add to both nodes edge lists and to the matrix
        public bool AddWEdge(char starts, char ends, int weight)
        {
            if (starts == ends)
                return false;

            int startIndex = FindNode(starts);
            int endIndex = FindNode(ends);

            if (startIndex == -1 || endIndex == -1 )
        return false;

            // set both links in edgeMatrix
            edgeMatrix[startIndex,endIndex] = weight;
            edgeMatrix[endIndex,startIndex] = weight;

            // create two new edges (one for each direction)
            // and add one to each nodes list of edges
            WEdge startEnd = new WEdge();
            startEnd.startIndex = startIndex;
            startEnd.endIndex = endIndex;
            startEnd.weight = weight;
            startEnd.next = nodeList[startIndex].connects;
            nodeList[startIndex].connects = startEnd;

            WEdge endStart = new WEdge();
            endStart.startIndex = endIndex;
            endStart.endIndex = startIndex;
            endStart.weight = weight;
            endStart.next = nodeList[endIndex].connects;
            nodeList[endIndex].connects = endStart;

            return true;
        }
        // linear search for a node with this name
        // return -1 if not found
        // otherwise return its index in the nodeList
        private int FindNode(char name)
        {
            for (int i = 0; i < numNodes; i++)
                if (nodeList[i].name == name)
                    return i;
            return -1;
        }

        // listing of nodes in order added to array
        public string ListNodes()
        {
            string theList = "";
            for (int i = 0; i < numNodes; i++)
            {
                theList += nodeList[i].name;
                theList += " ";
            }
            return theList;
        }

        // for each node in graph, display its edges
        public string DisplayWEdges()
        {
            string wEdgeDisplay = "";
            for (int i = 0; i < numNodes; i++)
            {
                // add the node name to the display
                wEdgeDisplay += nodeList[i].name;
                wEdgeDisplay += "-";

                // walk down its list of edges and add them also
                WEdge ptr = nodeList[i].connects;
                while (ptr != null)
                {
                    wEdgeDisplay += nodeList[ptr.endIndex].name + "(" + ptr.weight + ") ";
                    ptr = ptr.next;
                }
                // end this line of output
                wEdgeDisplay += "\n";
            }
            return wEdgeDisplay;
        }

        // display the adjacency matrix
        // as 0 for no connection and 1 for connection
        public string DisplayMatrix()
        {
            string matrixDisplay = "";

            // output header line of destinations
            matrixDisplay += " ".PadRight(2);
            for (int i = 0; i < numNodes; i++)
                matrixDisplay +=nodeList[i].name.ToString().PadRight(4);
            matrixDisplay += "\n";

            // now output the array
            for (int i = 0; i < numNodes; i++)
            {
                // add the starting node
                matrixDisplay += nodeList[i].name.ToString().PadRight(2);

                // now add its connections
                for (int j = 0; j < numNodes; j++)
                    matrixDisplay += edgeMatrix[i,j].ToString().PadRight(4);

                // end the row
                matrixDisplay += "\n";
            }
            return matrixDisplay;
        }

        // depth first traversal
        // starts at a given node
        // outputs a list of nodes visited
        // and a list of any unreached nodes
        private string DepthFirst(char name)
        {
            string depthFirstTrav = "";
            depthFirstTrav += "Depth First Traversal starting at " + name + "\n";

            // set all visited flags to false
            ResetFalse();

            // use a LIFO to keep track of nodes that are visited
            Stack<char> neighbors = new Stack<char>();

            // start with the starting node
            neighbors.Push(name);
            nodeList[FindNode(name)].visited = true;
            depthFirstTrav += name + " ";

            // as long as the stack has nodes
            while (neighbors.Count != 0)
            {
                // get the node at the top of the stack
                int index = FindNode(neighbors.Peek());

                // walk down the list of edges for that node
                // see if any connections are to unvisited nodes
                // if they are, add to stack and repeat
                WEdge ptr = nodeList[index].connects;
                while (ptr != null)
                {
                    int neighborIndex = ptr.endIndex;

                    // found one, put on stack and repeat
                    if (!nodeList[neighborIndex].visited)
                    {
                        char neighborName = nodeList[neighborIndex].name;
                        neighbors.Push(neighborName);
                        nodeList[neighborIndex].visited = true;

                        depthFirstTrav += neighborName + " ";
                        break;
                    }
                    ptr = ptr.next;
                }
                // no new neighbors, so remove this one from stack
                if (ptr == null)
                    neighbors.Pop();
            }
            depthFirstTrav += "\n";

            // now output anyone who was not reached
            depthFirstTrav += "Unreached Nodes are ";
            for (int i = 0; i < numNodes; i++)
                if (!nodeList[i].visited)
                    depthFirstTrav += nodeList[i].name + " ";
            depthFirstTrav += "\n";



            return depthFirstTrav;
        }

        // breadth first traversal
        // starts at a given node
        // outputs a list of nodes visited
        // and a list of any unreached nodes
        private string BreadthFirst(char name)
        {
            string bredthFirstTrav = "";
            bredthFirstTrav += "Breadth First Traversal starting at " + name + "\n";

            // set all visited flags to false
            ResetFalse();

            // use a FIFO to keep track of nodes to check out
            Queue<char> neighbors = new Queue<char>();

            // place starting node on the queue
            neighbors.Enqueue(name);
            nodeList[FindNode(name)].visited = true;
            bredthFirstTrav += name + " ";

            // as long as queue not empty
            while (neighbors.Count != 0)
            {
                // take the first one off
                int index = FindNode(neighbors.Dequeue());

                // add any unvisited neighbors to the queue
                WEdge ptr = nodeList[index].connects;
                while (ptr != null)
                {
                    int neighborIndex = ptr.endIndex;

                    if (!nodeList[neighborIndex].visited)
                    {
                        char neighborName = nodeList[neighborIndex].name;
                        neighbors.Enqueue(neighborName);
                        nodeList[neighborIndex].visited = true;

                        bredthFirstTrav += neighborName + " ";
                    }
                    ptr = ptr.next;
                }
            }
            bredthFirstTrav += "\n";

            // now see if anyone was not yet visited
            bredthFirstTrav += "Unreached Nodes are ";
            for (int i = 0; i < numNodes; i++)
                if (!nodeList[i].visited)
                    bredthFirstTrav += nodeList[i].name + " ";
            bredthFirstTrav += "\n";

            return bredthFirstTrav;
        }

        // min cost tree
        // breadth first traversal using a modified priority queue
        public string MinCostTree(char name)
        {
            string minCost = "";

            // check for valid starting node
            int nodeIndex = FindNode(name);
            if (nodeIndex == -1)
            {
                minCost += "Invalid starting node " + name + "\n";
                return minCost;
            }

            // good to go
            minCost += "Minimum cost tree starting at " + name + "\n";

            // set all visited flags to false
            ResetFalse();

            // use a priority queue to keep track of edges
            WeightedPQ neighbors = new WeightedPQ();

            nodeList[nodeIndex].visited = true;
            minCost += name + " ";

            // place starting nodes edges in the queue
            WEdge ptr = nodeList[nodeIndex].connects;
            while (ptr != null)
            {
                neighbors.AddWEdge(ptr);
                ptr = ptr.next;
            }

            // as long as queue not empty
            // get lowest edge and proceminCost its end
            while (!neighbors.Empty())
            {
                // get the minimum edge from queue
                WEdge next = neighbors.GetNext();


                // mark the end as visited
                // and display the link
                int endIndex = next.endIndex;
                nodeList[endIndex].visited = true;
                minCost += nodeList[next.startIndex].name + "-" + nodeList[endIndex].name + " ";


                // process its edges
                ptr = nodeList[endIndex].connects;
                while (ptr != null)
                {
                    if (!nodeList[ptr.endIndex].visited)
                    {
                        neighbors.AddWEdge(ptr);
                    }
                    ptr = ptr.next;
                }
            }

            minCost += "\n";

            // now see if anyone was not yet visited
            minCost += "Unreached Nodes are ";
            for (int i = 0; i < numNodes; i++)
                if (!nodeList[i].visited)
                    minCost += nodeList[i].name + " ";
            minCost += "\n";

            return minCost;
        }

        void ResetFalse()
        {
            for (int i = 0; i < numNodes; i++)
                nodeList[i].visited = false;
        }
    }
}
