//  based on WeightedPQ in
//  WGraph.h and WGraph.cpp
//  Example weighted graph
//
//  Created by Jim Bailey on 11/25/17.
//  Licensed under a Creative Commons Attribution 4.0 International License.
//
//  Transpiled by Katie Strauss 1/5/2020

namespace WeightedGraphClasses
{
    public class WeightedPQ
    {
        private WEdge[] theArray;
        private const int DEF_SIZE = 10;
        private int size;
        private int howMany;

        // Priority Queue for Min Cost Tree

        // constructor builds the array
        public WeightedPQ(int size = DEF_SIZE)
        {
            theArray = new WEdge[size];
            this.size = size;
            howMany = 0;
        }

        // add a new edge
        // verify lowest cost with that destination
        public void AddWEdge(WEdge theEdge)
        {
            for (int i = 0; i < howMany; i++)
                if (theArray[i].endIndex == theEdge.endIndex)
                {
                    if (theArray[i].weight > theEdge.weight)
                        theArray[i] = theEdge;
                    return;
                }
            theArray[howMany++] = theEdge;

            if (howMany == size)
            {
                WEdge[] tempArray = new WEdge[size * 2];
                for (int i = 0; i < howMany; i++)
                    tempArray[i] = theArray[i];
                theArray = tempArray;
                size *= 2;
            }
            return;
        }

        // return lowest cost edge
        public WEdge GetNext()
        {
            if (howMany == 0)
                return null;

            int minIndex = 0;
            for (int i = 0; i < howMany; i++)
                if (theArray[i].weight < theArray[minIndex].weight)
                    minIndex = i;
            WEdge minEdge = theArray[minIndex];
            theArray[minIndex] = theArray[--howMany];
            return minEdge;
        }

        public bool Empty()
        {
            return howMany == 0;
        }
    }
}

