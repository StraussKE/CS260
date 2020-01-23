//  Based on Node class in
//
//  Tree.h
//  binary_search_tree
//
//  Created by Jim Bailey on 11/1/17.
//  Licensed under a Creative Commons Attribution 4.0 International License.
//
//  Transpiled by Katie Strauss 1/22/2020

using System;

namespace GenericTreeClasses
{
    // definition of Node class
    // using public variables rather than setters/getters
    public class GenericNode<T> where T : IComparable
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
}
