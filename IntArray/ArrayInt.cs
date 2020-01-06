/*
 * Created by Katie Strauss for use by Jim Bailey 10/23/2019
 * 
 * notes: standard C# convention would be to use a list object instead of an array.
 * Because lists are so integrated into C#, many of the operations to work with an
 * array in this manner are very clunky.
 * 
 * Finalizers are seldom used in C# because the .NET Framework garbage collector takes
 * care of things for you.  Further implementation of the iDisposable interface is more
 * frequently used when explicit release of resources is required.  These elements are
 * not incorporated into this example because they aren't standard use.  Read up on them
 * if you want to know more!
 * 
 */

using System;

namespace Lab1ArrayIntConsoleApp
{
    public class ArrayInt
    {

        // private class variables
        private const int DEFAULT = 10;             // default size value set as a constant
        private int[] myArray;                      // instantiates the array that will be used
        private int arrSize;                        // stores the total size of the array
        public int nextIndex;                       // stores the value of the next index location in the array

        // default constructor
        public ArrayInt()
        {
            myArray = new int[DEFAULT];             // new array is created
            arrSize = DEFAULT;                      // array size tracker is set to the size of the array
            nextIndex = 0;                          // next array index value tracking variable is initialized
        }

        // constructor with one argument indicating the size of the array
        public ArrayInt(int size = DEFAULT)
        {
            if (size < 1)                           // minor input validation because negative array lengths are impossible
            {
                size = DEFAULT;                     // returns array size to default length
            }

            arrSize = size;                         // sets the array size to size
            myArray = new int[arrSize];             // creates array with size arrSize
            nextIndex = 0;                          // next array index value tracking variable is initialized
        }

        public int GetSize()
        {
            return arrSize;
        }

        // setSize method modifies the size of the array based on the size argument
        public void SetSize(int size)
        {
            if (size > arrSize)
            {
                int[] temp = myArray;               // temporary copy of array to store values
                myArray = new int[size];            // myArray is reinitialized as new array of length size
                for(int i = 0; i < arrSize; i++)    // foreach loop iterates through all indexes stored in temp
                {
                    myArray[i] = temp[i];           // values are added into new myArray
                }
                arrSize = size;                     // array size tracker is modified to reflect new size
            }
        }

        // gets the value from a designated index location in the array and returns it
        public int GetAt(int index)
        {
            if (index < 0 || index >= arrSize)      // checks to see if index exists in array and throws exception if it isn't
            {
                throw new IndexOutOfRangeException("Attempt to read at invalid location.");
            }
            return myArray[index];                  // returns the value contained at position index
        }

        // enters the selected value into the array at the selected index location
        public void SetAt(int index, int value)
        {
            if (index < 0 || index >= arrSize)      // checks to see if index exists in array and throws exception if it isn't
            {
                throw new IndexOutOfRangeException("Attempt to read at invalid location.");
            }
            myArray[index] = value;                 // sets the given value at the given position
            if (index > nextIndex)                  // moves the next index marker if the value is set at a higher index location
            {
                nextIndex = index + 1;              // next index tracker is moved for append function functionality
            }
        }

        // adds a value to the end of the array
        public void Append(int value)
        {
            if (nextIndex >= arrSize)               // makes the array grow if it's not large enough currently to append anything
            {
                SetSize(arrSize * 2);               // doubles array size
            }
            SetAt(nextIndex, value);                // sets the value in the next index location
            nextIndex++;                            // moves the next index tracker to the next location
        }

        //inserts a value at a given index
        public void InsertAt(int index, int value)
        {
            if (index < 0 || index >= arrSize)      // checks to see if index exists in array and throws exception if it isn't
            {
                throw new IndexOutOfRangeException("Attempt to read at invalid location.");
            }
            int tempSize = nextIndex - index;       // designating the size of the temporary array
            int[] temp = new int[tempSize];         // making temporary array with length of tempSize
            for (int i = 0; i<tempSize; i++)
            {
                temp[i] = myArray[index + i];       // values are transfered
            }
            SetAt(index, value);                    // value is inserted at designated index
            nextIndex = index + 1;                  // next index tracker is moved to the current location
            foreach (int i in temp)
            {
                Append(i);                          // values are moved from temporary array
            }
        }

        // removes a value from a given index
        public int RemoveAt(int index)
        {
            if (index < 0 || index >= arrSize)      // checks to see if index exists in array and throws exception if it isn't
            {
                throw new IndexOutOfRangeException("Attempt to read at invalid location.");
            }
            if (nextIndex == 0)                     // checks for empty array and throws error if it is
            {
                throw new IndexOutOfRangeException("Array is empty");
            }
            int temp = myArray[index];              // stores value being removed from the array
            for (int i = index; i < nextIndex; i++)              // moves array values
            {
                myArray[i] = myArray[i + 1];
            }
            nextIndex--;                            // next index tracker is moved
            return temp;                            // returns value removed from the array
        }
    }
}
