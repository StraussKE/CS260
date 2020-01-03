using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringHashClasses
{
    public class StringHash
    {
        private const int SIZE = 11;
        private string [] hashArray;
        private int arraySize;
        private int numItems;
        private const string EMPTY = "_empty_";
        private const string DELE = "_deleted_";

        public StringHash(int size = SIZE)       // constructor
        {
            arraySize = size;
            numItems = 0;
            hashArray = new string[arraySize];
    
            // initialize array to empty
            for (int i = 0; i<arraySize; i++ )
                hashArray[i] = EMPTY;
        }

        // create a string containing table contents
        public string DisplayTable()
        {
            string buffer = "";
            buffer += "Table:\n";

            for (int i = 0; i < arraySize; i++)
                buffer += (hashArray[i] + "\n");

            buffer += "\n";
            return buffer;
        } // end DisplayTable


        // create integer from string
        public int HashFunc(string key)
        {
            int hashValue = 0;
            for (int i = 0; i < key.Count(); i++)
            {
                hashValue = hashValue * 128;
                hashValue = hashValue + key[i];
                hashValue = hashValue % arraySize;
            }
            return hashValue;
        } // end HashFunc


        // add a new string to the table
        public void AddItem(string key)
        {
            // Rehash if array is over 1/2 full
            if (numItems > arraySize / 2)
            {
                Rehash();
            }

            // get an index from the key
            int index = HashFunc(key);

            // until empty cell or removed cell,
            while (hashArray[index] != EMPTY && hashArray[index] != DELE)
            {
                index++;                // go to next cell
                index %= arraySize;      // wraparound if necessary
            }

            // increment count if not replacing deleted item
            if (hashArray[index] != DELE)
                numItems++;

            // insert new item
            hashArray[index] = key;


        }  // end AddItem()


        // remove an item from the table
        // return true if succeeds
        public bool RemoveItem(string key)
        {
            // get index from hash
            int index = HashFunc(key);

            // search until we find a nullptr
            while (hashArray[index] != EMPTY)
            {
                // if we find it,
                // replace with nonItem
                // return found
                if (hashArray[index] == key)
                {
                    hashArray[index] = DELE;
                    return true;
                }

                // otherwise keep looking
                // wrap as needed
                index++;
                index %= arraySize;
            }

            /// reached end of array without finding it
            return false;

        }  // end RemoveItem()


        // find a string, return true if found
        public bool FindItem(string key)
        {
            // get integer from key
            int index = HashFunc(key);

            // look until we find it or run out of space
            while (hashArray[index] != EMPTY)
            {
                // check for the key (nonitem is checked also)
                // return true if found
                if (hashArray[index] == key)
                    return true;

                // otherwise keep looking
                // increment index and wrap as needed
                index++;
                index %= arraySize;
            }

            /// reached end of array without finding it
            return false;

        } // end FindItem()


        // create new larger table and Rehash into it
        // this version just doubles it, better to use prime numbers
        private void Rehash()
        {
            int oldSize = arraySize;
            arraySize *= 2;
            string [] oldArray = hashArray;
            hashArray = new string[arraySize];

            // initialize array to empty
            for (int i = 0; i < arraySize; i++)
                hashArray[i] = EMPTY;

            // reset numItems for new array
            numItems = 0;

            // now move old items into new table
            for (int i = 0; i < oldSize; i++)
            {
                if (oldArray[i] != EMPTY && oldArray[i] != DELE )
                AddItem(oldArray[i]);
            }

        }
    }
}
