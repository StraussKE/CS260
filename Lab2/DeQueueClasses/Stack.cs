

namespace DeQueueClasses
{
    public class Stack
    {
        private Dequeue theQueue;

        public Stack()
        {
            theQueue = new Dequeue();
        }
        public Stack(int size)
        {
             theQueue = new Dequeue(size);
        }

        public void Push(int value)
        {
            theQueue.AddLeft(value);
        }

        // if stack is empty, the queue will throw an exception
        public int Pop()
        {
            return theQueue.GetLeft();
        }

        // if stack is empty, the queue will throw an exception
        public int Peek()
        {
            int temp = Pop();
            Push(temp);
            return temp;
        }
    }
}
