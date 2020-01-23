//  Based on
//  Tree234.h and Tree234.cpp
//  Lab5
//
//  Created by Jim Bailey on 5/12/17.
//  Copyright © 2017 jim. All rights reserved.
//
//  Transpiled by Katie Strauss

namespace Tree234Classes
{
    public class Tree234
    {
        private Node234 root;

        public string inOrder()
        {
            return recInOrder(root);
        }

        private string recInOrder(Node234 ptr)
        {
            // if we hit the end of a branch, quit
            if (ptr == null)
                return " ";

            // otherwise process this node


            // create the buffer we will use
            string buffer = "";

            // get the number of values for later reference
            int numValues = ptr.getNumValues();

            // loop through, adding subtrees and values
            for (int i = 0; i < numValues; i++)
            {
                // add the next subtree
                buffer += recInOrder(ptr.getChild(i));

                // add the next value
                buffer += ptr.getValue(i).ToString();
            }
            // now add the final subtree
            buffer += recInOrder(ptr.getChild(numValues));

            // return the built up buffer
            return buffer;
        }

        public Tree234()
        {
            // initialize tree with an empty node
            root = new Node234();
        }

        // recursive find
        private bool recFind(int value, Node234 ptr)
        {
            if (ptr == null)
                return false;

            int num = ptr.getNumValues();
            // otherwise, look at the node
            for (int i = 0; i < num; i++)
            {
                if (ptr.getValue(i) == value)
                    return true;
                if (ptr.getValue(i) > value)
                    return recFind(value, ptr.getChild(i));
            }

            return recFind(value, ptr.getChild(num));
        }

        // recursive in order traversal
        

        // split a node
        private void split(Node234 ptr)
        {
            int valueB, valueC;
            Node234 parent;
            Node234 child2;
            Node234 child3;
            int valueIndex;

            // remove two largest values
            valueC = ptr.removeValue();
            valueB = ptr.removeValue();
            // remove two rightmost children
            child2 = ptr.removeChild(2);
            child3 = ptr.removeChild(3);

            // create a new node
            // and put rightmost stuff in it
            Node234 newRight = new Node234();
            newRight.insertValue(valueC);
            newRight.addChild(0, child2);
            newRight.addChild(1, child3);

            // special case root
            if (ptr == root)
            {
                // make a new root and attach this node to it
                root = new Node234();
                parent = root;
                root.addChild(0, ptr);
            }
            else
                parent = ptr.getParent();

            // now modify parent
            // move second value up to it
            // and connect newRight appropriately
            valueIndex = parent.insertValue(valueB);

            // move child links to the right as needed
            for (int i = parent.getNumValues() - 1; i > valueIndex; i--)
            {
                Node234 temp = parent.removeChild(i);
                parent.addChild(i + 1, temp);
            }

            // now add new link in remaining slot
            parent.addChild(valueIndex + 1, newRight);
        }

        // get the next higher child
        private Node234 getNextChild(Node234 theNode, int value)
        {
            for (int i = 0; i < theNode.getNumValues(); i++)
                if (value < theNode.getValue(i))
                    return theNode.getChild(i);
            return theNode.getChild(theNode.getNumValues());
        }

        // add value to tree
        public void insert(int value)
        {
            Node234 ptr = root;

            // break out when we find proper leaf
            while (true)
            {
                // if full, split it
                if (ptr.isFull())
                {
                    // split it up
                    split(ptr);
                    // go up to parent to start over
                    ptr = ptr.getParent();

                    // go back down proper branch
                    ptr = getNextChild(ptr, value);
                }

                // not full, then see if leaf
                else if (ptr.isLeaf())
                    break;

                // not leaf, not full, go on down
                else
                    ptr = getNextChild(ptr, value);

            }

            // found a leaf, put value in it
            ptr.insertValue(value);
        }

        // find a value,
        public bool find(int value)
        {
            return recFind(value, root);
        }
    }
}
