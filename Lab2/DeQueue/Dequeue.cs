using System;

namespace Lab2Dequeue
{
    public class Dequeue
    {
        // default array size
        private const int SIZE = 100;
        // how many numbers per line for returning contents
        private const int NumPerLine = 10;

        private int [] theArray;
        private int theSize;
        private int left;
        private int right;
        private int numElements;

        //constructor, initialize all the variables
        public Dequeue(int size = SIZE)
        {
            theArray = new int[size];
            theSize = size;
            numElements = 0;
            right = theSize;
            left = -1;
        }

        // add to the right, wrapping if necessary
        public void AddRight(int value)
        {
            // full, so create a new array and copy items into it
            if (numElements == theSize)
            {
                Resize();
            }
            if (right == 0)
            {
                right = theSize;
            }
            theArray[--right] = value;
            numElements++;
        }

        // add to the left, wrapping if necessary
        public void AddLeft(int value)
        {

            // full, so create a new array and copy items into it
            if (numElements == theSize)
            {
                Resize();
            }

            if (left == theSize - 1)
            {
                left = -1;
            }
            theArray[++left] = value;
            numElements++;
        }

        // removing from right, wrapping if necessary
        public int GetRight()
        {
            if (numElements == 0)
            {
                throw new IndexOutOfRangeException("Array is empty!");
            }
            numElements--;
            if (right == theSize)
            {
                right = 0;
            }
            int temp = theArray[right++];
            return temp;
        }

        // removing from left, wrapping if necessary
        public int GetLeft()
        {
            if (numElements == 0)
            {
                throw new IndexOutOfRangeException("Array is empty!");
            }

            numElements--;
            if (left == -1)
            {
                left = theSize - 1;
            }
            int temp = theArray[left--];
            return temp;
        }

        // return how many items are there
        public bool IsEmpty()
        {
            return numElements == 0;
        }

        // say whether there is any room left
        public bool IsFull()
        {
            return numElements == theSize;
        }

        // list the current elements from right to left
        public string ListRightLeft()
        {
            string buffer;
            string output = "";
            int lineCount = 0;
            int current = right;
            for (int i = 0; i < numElements; i++)
            {
                buffer = theArray[current].ToString();
                output += buffer.PadRight(3);
                lineCount++;
                if (lineCount >= NumPerLine)
                {
                    lineCount = 0;
                    output += "\n";
                }
                current++;
                if (current == theSize)
                {
                    current = 0;
                }
            }
            output += "\n";
            return output;
        }


        // list the current elements from left to right
        public string ListLeftRight()
        {
            string buffer;
            string output = "";
            int lineCount = 0;
            int current = left;
            for (int i = 0; i < numElements; i++)
            {
                buffer = theArray[current].ToString();
                output += buffer.PadRight(3);
                lineCount++;
                if (lineCount >= NumPerLine)
                {
                    lineCount = 0;
                    output += "\n";
                }
                current--;
                if (current == -1)
                {
                    current = theSize - 1;
                }
            }
            output += "\n";
            return output;
        }

        // debug method that lists the array from 0 to theSize-1
        public string DumpArray()
        {
            string buffer;
            string output = "";
            output += "[";
            int lineCount = 0;
            for (int i = 0; i < theSize; i++)
            {
                buffer = theArray[i].ToString();
                buffer.PadRight(3);
                lineCount++;
                if (lineCount >= NumPerLine)
                {
                    lineCount = 0;
                    output += "\n";
                }
            }
            output += "  ]\n";
            return output;
        }

        // helper method that Resizes the array when full
        // create a new array that is twice as big
        // copy items into it from left to right
        // reset all the pointers
        public void Resize()
        {
            int [] tempArray = new int[2 * theSize];
            int saveCount = numElements;

            for (int i = 0; i < theSize * 2; i++)
                tempArray[i] = 0;

            // fill the array with values, from left to right
            for (int i = 0; i < theSize; i++)
            {
                tempArray[i] = GetRight();
            }

            // reset variables to new starting point
            theSize *= 2;

            numElements = saveCount;
            left = numElements - 1;
            right = theSize;
            theArray = tempArray;
        }
    }
}
