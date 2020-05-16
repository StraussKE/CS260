//
//  PriorityQ.hpp
//  SortingLab
//
//  Create Priority Queue using Heap
//
//  Created by jim bailey on 11/15/19.
//  Copyright © 2019 jim bailey. All rights reserved.
//
//  Transpiled by Katie Strauss 05/16/2020

using System;
using System.Collections.Generic;
using System.Text;

namespace RecursiveSorts
{
    public class PriorityQueue
    {
        private Heap theHeap;
        private const int SIZE = 10;

        public PriorityQueue(int size = SIZE) { theHeap = new Heap(size); }

        public void AddItem(int value) { theHeap.AddItem(value); }
        public int GetItem() { return theHeap.GetItem(); }
    };
}
