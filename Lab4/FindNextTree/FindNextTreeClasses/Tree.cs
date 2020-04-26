//  Tree class
//
//  Lab4 FindNextTree
//
//  Created by Jim Bailey on 4/25/20.
//  Licensed under a Creative Commons Attribution 4.0 International License.
//
//
//  Transpiled into C# by Katie Strauss 04/25/20

namespace FindNextTreeClasses
{
    public class Tree
    {
        private Node root;

        // constructor
        public Tree() { root = null; }

        // for display function
        public const int SPACE = 8;

        // private functions for recursion

        // walk down tree, until end of branch
        // find is true, less is left, more is right
        private bool recFind(int value, Node ptr)
        {
            if (ptr == null)
                return false;

            if (ptr.getValue() == value && ptr.getPresent())
        return true;

            if (ptr.getValue() > value)
                return recFind(value, ptr.getLeft());
            else
                return recFind(value, ptr.getRight());
        }

        // self, left, right
        private string recPreOrder(Node ptr)
        {
            if (ptr == null)
                return "";

            string buffer = "";

            buffer += ptr.getValue().ToString() + " ";
            buffer += recPreOrder(ptr.getLeft());
            buffer += recPreOrder(ptr.getRight());

            return buffer;
        }

        // left, self, right
        private string recInOrder(Node ptr)
        {
            if (ptr == null)
                return "";

            string buffer = "";

            buffer += recInOrder(ptr.getLeft());
            buffer += ptr.getValue().ToString() + " ";
            buffer += recInOrder(ptr.getRight());

            return buffer;
        }

        // left, right, self
        private string recPostOrder(Node ptr)
        {
            if (ptr == null)
                return "";

            string buffer = "";

            buffer += recInOrder(ptr.getLeft());
            buffer += recInOrder(ptr.getRight());
            buffer += ptr.getValue().ToString() + " ";

            return buffer;
        }


        // recursive method for display
        private string recDisplay(Node ptr, int level)
        {
            return "Not yet implemented";
        }

        // add new item in proper location
        // iterative method, place left if smaller, else right
        public void insertItem(int value)
        {
            // create a new node
            Node temp = new Node(value);

            // special case empty tree
            if (root == null)
            {
                root = temp;
                return;
            }

            // now walk down the tree looking for where to go
            Node ptr = root;

            bool done = false;
            while (!done)
            {
                if (ptr.getValue() > value)
                {
                    if (ptr.getLeft() == null)
                    {
                        ptr.setLeft(temp);
                        temp.setParent(ptr);
                        done = true;
                    }
                    else
                    {
                        ptr = ptr.getLeft();
                    }
                }
                else
                {
                    if (ptr.getRight() == null)
                    {
                        ptr.setRight(temp);
                        temp.setParent(temp);
                        done = true;
                    }
                    else
                    {
                        ptr = ptr.getRight();
                    }
                }
            }
        }

        // see if something is there
        // call recursive method
        public bool findItem(int value)
        {
            return recFind(value, root);
        }

        // delete by marking not present
        // iterative find
        public bool deleteItem(int value)
        {
            // start at the root
            Node ptr = root;

            // walk down some branch until find it
            // or run out of branch
            while (ptr != null)
            {
                if (ptr.getValue() == value && ptr.getPresent())
        {
                    ptr.setPresent(false);
                    return true;
                }
                if (ptr.getValue() > value)
                    ptr = ptr.getLeft();
                else
                    ptr = ptr.getRight();
            }
            return false;
        }

        // delete by removing
        public bool removeItem(int value)
        {
            return true;
        }

        // find value or next largest
        public int findNext(int value)
        {
            int result = -1;
            Node ptr = root;

            // walk down branch
            while (ptr != null)
            {
                if (ptr.getValue() == value)
                {
                    return value;
                }
                if (ptr.getValue() > value)
                {
                    result = ptr.getValue();
                    ptr = ptr.getLeft();
                }
                else
                {
                    ptr = ptr.getRight();
                }
            }
            return result;
        }

        // findNext with delete
        public int deleteNext(int value)
        {
            int result = findNext(value);
            if (result != -1)
                deleteItem(result);
            return result;
        }

        // traversals
        public string preOrder()
        {
            return recPreOrder(root);
        }
        public string inOrder()
        {
            return recInOrder(root);
        }
        public string postOrder()
        {
            return recPostOrder(root);
        }

        // display for lab
        public string displayTree() { return inOrder(); }

        // graphical display
        public string showTree()
        {
            return recDisplay(root, 0);
        }
    }
}
