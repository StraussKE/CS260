//
//  Node234.h
//  Lab5
//
//  Created by Jim Bailey on 5/12/17.
//  Copyright © 2017 jim. All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree234Classes
{
    // Node for a 234 tree of integers
    public class Node234
    {
        // defines the max number of children
        public const int DEGREE = 4;

        // current number of values present
        private int numValues;

        // array holding the values
        private int [] values = new int[DEGREE - 1];

        // array holding pointers to children
        private Node234 [] children = new Node234[DEGREE];

        // pointer to our parent
        private Node234 parent;

        public Node234()
        {
            for (int i = 0; i < DEGREE; i++)
                children[i] = null;
            numValues = 0;
        }

        // add or remove a child node
        public void addChild(int index, Node234 child)
        {
            children[index] = child;
            if (child != null)
                child.parent = this;
        }

        public Node234 removeChild(int index)
        {
            Node234 temp = children[index];
            children[index] = null;
            return temp;
        }

        // given an index, return that child pointer
        public Node234 getChild(int index)
        {
            return children[index];
        }

        // given an index, return that value
        public int getValue(int index)
        {
            return values[index];
        }

        // return the parent pointer
        public Node234 getParent()
        {
            return parent;
        }

     // information about this node
        // are there any children?
        public bool isLeaf()
        {
            return children[0] == null;
        }

        //how many values are present?
        public int getNumValues()
        {
            return numValues;
        }

        // room for more values?
        public bool isFull()
        {
            return numValues == DEGREE - 1;
        }

        // add a new value
        // assume the node is not full
        // return index where stored
        public int insertValue(int value)
        {
            // insert value in proper place
            int index = numValues - 1;
            while (index >= 0 && values[index] > value )
    {
                values[index + 1] = values[index];
                index--;
            }
            values[++index] = value;
            numValues++;

            return index;
        }
        // remove the largest value present
        public int removeValue()
        {
            return values[--numValues];
        }
        // find an item, return -1 if not present, index otherwise
        public int findValue(int value)
        {
            for (int i = 0; i < numValues; i++)
                if (values[i] == value)
                    return i;
            return -1;
        }
    }
}
