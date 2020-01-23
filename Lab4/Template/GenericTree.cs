//
//  Tree.h
//  binary_search_tree
//
//  Created by Jim Bailey on 11/1/17.
//  Licensed under a Creative Commons Attribution 4.0 International License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericParseTree
{
    // definition of Node class
    // using public variables rather than setters/getters
    public class GenericNode<T> where T : IComparable<T>
    {
        // definition of class
        // using public variables rather than setters/getters
        // constructor to build new node
        public GenericNode(T value)
        {
            left = null;
            right = null;
            this.value = value;
            present = true;
        }

        // public variables for contents
        public GenericNode<T> left;
        public GenericNode<T> right;
        public T value;
        public bool present;
    }

    // definition of binary search tree
    public class GenericTree<T> where T : IComparable<T>
    {
        private GenericNode<T> root;

        // for display function
        private const int SPACE = 8;

        // private functions for recursion
        private bool RecFind(T value, GenericNode<T> ptr)
        {
            // base case
            if (ptr == null)
                return false;
            switch (ptr.value.CompareTo(value))
            {
                case -1: // visit right subtree
                    return RecFind(value, ptr.right);
                case 0: // base, found
                    return true;
                case 1: // visit left subtree
                    return RecFind(value, ptr.left);
            }
        }
        private string RecPreOrder(GenericNode<T> ptr)
        {
            string buffer = "";

            // if done with branch, return empty
            if (ptr == null)
                return buffer;

            // get this nodes value
            string temp = "";
            temp += ptr.value.ToString().PadLeft(5);

            // build buffer in proper order
            buffer += temp;
            buffer += RecPreOrder(ptr.left);
            buffer += RecPreOrder(ptr.right);

            return buffer;
        }
        private string RecInOrder(GenericNode<T> ptr)
        {
            string buffer = "";

            // if done with branch, return empty
            if (ptr == null)
                return buffer;

            // get this nodes value
            string temp = "";
            temp += ptr.value.ToString().PadLeft(5);

            // build buffer in proper order
            buffer += RecInOrder(ptr.left);
            buffer += temp;
            buffer += RecInOrder(ptr.right);

            return buffer;
        }
        private string RecPostOrder(GenericNode<T> ptr)
        {
            string buffer = "";

            // if done with branch, return empty
            if (ptr == null)
                return buffer;

            // get this nodes value
            string temp = "";
            temp += ptr.value.ToString().PadLeft(5);

            // build buffer in proper order
            buffer += RecPostOrder(ptr.left);
            buffer += RecPostOrder(ptr.right);
            buffer += temp;

            return buffer;
        }

        // recursive method for display
        private string RecDisplay(GenericNode<T> ptr, int space)
        {
            // base case, quit on leaf
            if (ptr == null)
                return "";

            string buffer = "";
            space += SPACE;

            buffer += RecDisplay(ptr.right, space);
            buffer += "\n".PadLeft(space - SPACE) + " " + ptr.value.ToString().PadLeft(4);
            if (ptr.present)
                buffer += "\n";
            else
                buffer += " dele\n";
            buffer += RecDisplay(ptr.left, space);

            return buffer;
        }

        // constructor
        public GenericTree() { root = null; }

        // Add a node containing value
        public void InsertItem(T value)
        {
            // special case empty tree
            if (root == null)
            {
                root = new GenericNode<T>(value);
                return;
            }

            // now we start at root
            // find proper leaf location
            // and add it there
            GenericNode<T> ptr = root;
            while (true)
            {
                switch (ptr.value.CompareTo(value))
                {
                    case -1: // visit right subtree
                        // nothing there, leaf
                        if (ptr.right == null)
                        {
                            ptr.right = new GenericNode<T>(value);
                            return;
                        }
                        // need to go down branch further
                        else
                        {
                            ptr = ptr.right;
                        }
                        break;
                    case 0: // see if happens to have right value and deleted
                        if (!ptr.present)
                        {
                            ptr.present = true;
                            return;
                        }
                        break;
                    case 1: // see if add to the left
                        // nothing there, leaf
                        if (ptr.left == null)
                        {
                            ptr.left = new GenericNode<T>(value);
                            return;
                        }
                        // need to go down branch further
                        else
                        {
                            ptr = ptr.left;
                        }
                        break;
                }
            }
        }

        // return true if value is in the tree
        public bool IsPresent(T value)
        {
            return RecFind(value, root);
        }

        // delete by marking absent
        // based on non-recursive find
        public bool RemoveItem(T value)
        {
            // start at root
            GenericNode<T> ptr = root;

            // until done with path
            while (ptr != null)
                return false;
            switch (ptr.value.CompareTo(value))
            {
                case -1: // visit right subtree
                    ptr = ptr.right;
                    break;
                case 0: // base, found
                    if (ptr.present)
                    {
                        ptr.present = false;
                        return true;
                    }
                    break;
                case 1: // visit left subtree
                    ptr = ptr.left;
                    break;
            }
            return false;
        }

        // traversals
        public string preOrder()
        {
            return RecPreOrder(root);
        }
        public string inOrder()
        {
            return RecInOrder(root);
        }
        public string postOrder()
        {
            return RecPostOrder(root);
        }

        // graphical display
        public string displayTree()
        {
            return RecDisplay(root, 0);
        }
    }
}