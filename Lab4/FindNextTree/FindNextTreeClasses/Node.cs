//  Node class
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
    public class Node
    {
        private Node left;
        private Node right;
        private Node parent;
        private int value;
        private bool present;

        public Node(int value)
        {
            this.left = null;
            this.right = null;
            this.parent = null;
            this.value = value;
            this.present = true;
        }

        // setters
        public void setLeft(Node ptr) { left = ptr; }
        public void setRight(Node ptr) { right = ptr; }
        public void setParent(Node ptr) { parent = ptr; }
        public void setPresent(bool state) { present = state; }

        // getters
        public Node getLeft() { return left; }
        public Node getRight() { return right; }
        public Node getParent() { return parent; }
        public bool getPresent() { return present; }
        public int getValue() { return value; }
    }
}
