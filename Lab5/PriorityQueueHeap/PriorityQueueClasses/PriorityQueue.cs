//  Transpiled from Katie Strauss Lab 5 Priority Queue
//  Created 5/6/2018
//
//  Transpiled by Katie Strauss 11/6/2019

using HeapClasses;

namespace PriorityQueueClasses
{
    public class PriorityQueue
    {
        private Heap my_heap; // heap that is being used for the queue

        public PriorityQueue()
        {
            my_heap = new Heap(); // create a heap of default size
        }

        public PriorityQueue(int queue_size)
        {
            my_heap = new Heap(queue_size); // create a heap of specified size
        }


        public void Insert(int value)
        {
            my_heap.Insert(value); // use the function in heap since we're wrapping heap
        }

        public int Peek()
        {
            return my_heap.Largest(); // also calling a heap function
        }

        public int Remove()
        {
            return my_heap.Remove(); // yet another call to an already written heap function
        }
    }
}
