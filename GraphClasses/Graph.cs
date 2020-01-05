//  based on
//  Graph.hpp and Graph.cpp
//  Example Non-directed, non-weighted graph
//
//  Created by Jim Bailey on 11/25/17.
//  Licensed under a Creative Commons Attribution 4.0 International License.
//
//  Transpiled by Katie Strauss 1/5/2020


using System;
using System.Collections.Generic;

namespace GraphClasses
{
    public class Graph
    {
        const int SIZE = 20;
        int numNodes;
        Node[] nodeList = new Node[SIZE];
        int[,] edgeMatrix = new int[SIZE, SIZE];

        public Graph()
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
                throw new ArgumentOutOfRangeException("Graph size exceeded!!");

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
        public bool AddEdge(char starts, char ends)
        {
            if (starts == ends)
                return false;

            int startIndex = findNode(starts);
            int endIndex = findNode(ends);

            if (startIndex == -1 || endIndex == -1 )
        return false;

            // set both links in edgeMatrix
            edgeMatrix[startIndex , endIndex] = 1;
            edgeMatrix[endIndex , startIndex] = 1;

            // create two new edges (one for each direction)
            // and add one to each nodes list of edges
            Edge startEnd = new Edge();
            startEnd.endIndex = endIndex;
            startEnd.next = null;
            startEnd.next = nodeList[startIndex].connects;
            nodeList[startIndex].connects = startEnd;

            Edge endStart = new Edge();
            endStart.endIndex = startIndex;
            endStart.next = null;
            endStart.next = nodeList[endIndex].connects;
            nodeList[endIndex].connects = endStart;
            return true;
        }
        // linear search for a node with this name
        // return -1 if not found
        // otherwise return its index in the nodeList
        private int findNode(char name)
        {
            for (int i = 0; i < numNodes; i++)
                if (nodeList[i].name == name)
                    return i;
            return -1;
        }

        // listing of nodes in order added to array
        public string ListNodes()
        {
            string theList = "The Nodes are: ";
            for (int i = 0; i < numNodes; i++)
            {
                theList += nodeList[i].name;
                theList += " ";
            }
            return theList;
        }

        // for each node in graph, display its edges
        public string DisplayEdges()
        {
            string edgeList = "";
            edgeList += "The EdgeList is: (Node: its edges)\n";

            for (int i = 0; i < numNodes; i++)
            {
                // add the node name to the display
                edgeList += nodeList[i].name;
                edgeList += ": ";

                // walk down its list of edges and add them also
                Edge ptr = nodeList[i].connects;
                while (ptr != null)
                {
                    edgeList += nodeList[ptr.endIndex].name;
                    edgeList += " ";
                    ptr = ptr.next;
                }
                // end this line of output
                edgeList += "\n";
            }
            return edgeList;
        }

        // display the adjacency matrix
        // as 0 for no connection and 1 for connection
        public string DisplayMatrix()
        {
            string edgeMatrixDisp = "";
            edgeMatrixDisp += "The edgeMatrix is: \n";

            // output header line of destinations
            edgeMatrixDisp += " ".PadRight(2);
            for (int i = 0; i < numNodes; i++)
                edgeMatrixDisp += nodeList[i].name.ToString().PadRight(4);
            edgeMatrixDisp += "\n";

            // now output the array
            for (int i = 0; i < numNodes; i++)
            {
                // add the starting node
                edgeMatrixDisp += nodeList[i].name.ToString().PadRight(2);

                // now add its connections
                for (int j = 0; j < numNodes; j++)
                    edgeMatrixDisp += edgeMatrix[i, j].ToString().PadRight(4);

                // end the row
                edgeMatrixDisp += "\n";
            }
            return edgeMatrixDisp;
        }

        // depth first traversal
        // starts at a given node
        // outputs a list of nodes visited
        // and a list of any unreached nodes
        public string DepthFirst(char name)
        {
            string depthFirstTrav = "";
            depthFirstTrav += "Depth First Traversal starting at " + name + "\n";

            // uses a stack to keep track of nodes to visit
            // could use Node * pointers to the nodes || names of nodes
            // instead am using index into nodeList
            Stack<int> theStack = new Stack<int>();

            // get index of starting node
            int index = findNode(name);

            // if node does not exist, quit with error
            if (index == -1)
                return "Invalid starting node for Depth First Traversal";

            // set all nodes to not yet visited
            resetVisited();

            // process node (mark visited, add to stack, output name)
            nodeList[index].visited = true;
            theStack.Push(index);
            depthFirstTrav += name + " : ";

            // as long as stack is not empty of nodes
            while (theStack.Count != 0)
    {
                // get the node at the top of the stack
                index = theStack.Peek();

                // walk down list of edges for that node
                // see if any are unvisited
                // if they are, add to stack and repeat
                Edge ptr = nodeList[index].connects;
                while (ptr != null)
                {
                    int neighborIndex = ptr.endIndex;

                    // found one, add to stack, mark as visited, & output
                    if (!nodeList[neighborIndex].visited)
                    {
                        theStack.Push(neighborIndex);
                        nodeList[neighborIndex].visited = true;
                        depthFirstTrav += nodeList[neighborIndex].name + " ";

                        // stop traversal of edgelist for now
                        break;
                    }
                    ptr = ptr.next;

                }   // end of nodeList traversal

                // no new neighbors added to queue,
                //  so remove this one from stack
                if (ptr == null)
                    theStack.Pop();

            }   // end stack not empty

            // add terminating "\n"ine and return string
            depthFirstTrav += "\n";

            // add not visited nodes
            depthFirstTrav += "Not reached: ";
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
        public string BreadthFirst(char name)
        {
            string breadthFirstTrav = "";
            breadthFirstTrav += "Breadth First Traversal starting at " + name + "\n";

            // set all visited flags to false
            resetVisited();

            // get index of starting node
            int index = findNode(name);

            // if node does not exist, quit with error
            if (index == -1)
                return "Invalid starting node for Breadth First Traversal";

            // use a FIFO to keep track of nodes to check out
            // this time using a pointer to the node
            Queue<Node> theQueue = new Queue<Node>();

            // process this node, add to queue, mark as visited, output
            Node nodePtr = nodeList[index];
            theQueue.Enqueue(nodePtr);
            nodePtr.visited = true;
            breadthFirstTrav += nodePtr.name + " : ";

            // as long as queue not empty
            while (theQueue.Count != 0)
            {
                // take the first one off
                nodePtr = theQueue.Dequeue();

                // add all unvisited neighbors to the queue
                Edge edgePtr = nodePtr.connects;
                while (edgePtr != null)
                {
                    // get a neigbor
                    int neighborIndex = edgePtr.endIndex;

                    // if not visited, process
                    if (!nodeList[neighborIndex].visited)
                    {
                        Node neighbor = nodeList[neighborIndex];
                        theQueue.Enqueue(neighbor);
                        neighbor.visited = true;
                        breadthFirstTrav += neighbor.name + " ";
                    }
                    edgePtr = edgePtr.next;

                }   // end of traversing edge list

            }   // end of processing queue

            // add terminal "\n"ine and return string
            breadthFirstTrav += "\n";

            // add not visited nodes
            breadthFirstTrav += "Not reached: ";
            for (int i = 0; i < numNodes; i++)
                if (!nodeList[i].visited)
                    breadthFirstTrav += nodeList[i].name + " ";
            breadthFirstTrav += "\n";

            return breadthFirstTrav;
        }

        private void resetVisited()
        {
            for (int i = 0; i < numNodes; i++)
                nodeList[i].visited = false;
        }
    }
}
