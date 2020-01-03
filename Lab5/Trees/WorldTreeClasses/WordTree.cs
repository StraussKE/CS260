//
//  WordTree.cpp
//  Lab5_260
//
//  Created by Jim Bailey on 5/12/17.
//  Copyright © 2017 jim. All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordTreeClasses
{
    public class WordTree
    {
        private WordNode root;

        // constructor
        public WordTree()
        {
            root = null;
        }


        // add a new value
        // not recursive to show iterative approach
        public void addValue(string value)
        {
            // make a new node to containing information
            WordNode temp = new WordNode();
            temp.value = value;
            temp.left = temp.right = null;

            // now place it in tree

            // first check for empty tree
            if (root == null)
            {
                root = temp;
                return;
            }

            // tree is not empty, so start walking down it
            WordNode ptr = root;

            // will return from loop after inserting node in proper place
            while (true)
            {
                // go left young adder
                if (string.Compare(ptr.value, value) > 0)
                {
                    // this is leaf, so add here
                    if (ptr.left == null)
                    {
                        ptr.left = temp;
                        return;
                    }
                    // not leaf, continue on down
                    ptr = ptr.left;
                }
                // had to go right instead
                else
                {
                    // is this a leaf?
                    if (ptr.right == null)
                    {
                        ptr.right = temp;
                        return;
                    }

                    // not leaf, continue on down
                    ptr = ptr.right;
                }
            }
        }

        // find a value - recursive as example
        public bool find(string value)
        {
            return recFind(value, root);
        }
        // does the real work of find
        private bool recFind(string value, WordNode ptr)
        {
            // see if at end of branch, if so -- not here
            if (ptr == null)
                return false;

            // at a real node, so check it for value
            if (ptr.value == value)
                return true;

            // not here, keep looking
            if (string.Compare(ptr.value, value) > 0)
                return recFind(value, ptr.left);
            else
                return recFind(value, ptr.right);
        }

        // the three traversals
        // each calls appropriate recursive one
        public string inOrder()
        {
            return recInOrder(root);
        }
        public string preOrder()
        {
            return recPreOrder(root);
        }
        public string postOrder()
        {
            return recPostOrder(root);
        }

        // recursive traversals
        private string recInOrder(WordNode ptr)
        {
            if (ptr == null)
                return "";

            // define the buffer to collect subtree in
            string buffer = "";
            // add stuff to buffer in proper order
            buffer += recInOrder(ptr.left);
            buffer += (ptr.value + " ");
            buffer += recInOrder(ptr.right);

            // done, now return it
            return buffer;
        }
        private string recPreOrder(WordNode ptr)
        {
            if (ptr == null)
                return "";

            // define the buffer to collect subtree in
            string buffer = "";
            // add stuff to buffer in proper order
            buffer += (ptr.value + " ");
            buffer += recPreOrder(ptr.left);
            buffer += recPreOrder(ptr.right);

            // done, now return it
            return buffer;
        }
        private string recPostOrder(WordNode ptr)
        {
            if (ptr == null)
                return "";

            // define the buffer to collect subtree in
            string buffer = "";
            // add stuff to buffer in proper order
            buffer += recPostOrder(ptr.left);
            buffer += recPostOrder(ptr.right);
            buffer += (ptr.value + " ");

            // done, now return it
            return buffer;
        }
    }
}