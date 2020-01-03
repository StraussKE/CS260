using System.Linq;

namespace ChainHashClasses
{
    public class ChainedHash
    {
        private const int SIZE = 11;
        private ChainItem [] hashArray;
        private int arraySize;

        public ChainedHash(int size = SIZE)       // constructor
        {
            arraySize = size;
            hashArray = new ChainItem[arraySize];
    
            // initialize array to null
            for (int i = 0; i<arraySize; i++ )
                hashArray[i] = null;
        }

        public string DisplayTable()
        {
            string buffer;
            buffer = "Table: \n";

            for (int j = 0; j < arraySize; j++)
                if (hashArray[j] != null)
                {
                    ChainItem ptr = hashArray[j];
                    do
                    {
                        buffer += ptr.GetKey();
                        ptr = ptr.GetNext();
                        if (ptr != null)
                            buffer += " - ";
                    } while (ptr != null);
                    buffer += "\n";

                }
                else
                    buffer += "_empty_\n";

            buffer += "\n";
            return buffer;
        }
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
        }

        // add a new item in the list with key as value
        public void AddItem(string key)
        {
            // create a new item with that value
            ChainItem temp = new ChainItem(key);

            // find where to add it
            int hashVal = HashFunc(key);

            // add to head of list at that location
            temp.SetNext(hashArray[hashVal]);
            hashArray[hashVal] = temp;

        }  // end insert()
        public bool RemoveItem(string key)
        {
            // get the index
            int hashVal = HashFunc(key);

            // search linked list and delete if there
            if (hashArray[hashVal] != null)
            {
                ChainItem ptr = hashArray[hashVal];

                // single linked, so have to look ahead

                // special case first item
                if (ptr.GetKey() == key)
                {
                    // update list, delete item
                    hashArray[hashVal] = ptr.GetNext();
                    return true;
                }

                // not head, so walk down rest of list
                while (ptr.GetNext() != null)
                {
                    if (ptr.GetNext().GetKey() == key)
                    {
                        ptr.SetNext(ptr.GetNext().GetNext());
                        return true;
                    }
                    ptr = ptr.GetNext();
                }
                return false;
            }
            return false;                  // can't find item

        }  // end removeValue()

        // look for an item containing key
        public bool FindItem(string key)
        {
            int hashVal = HashFunc(key);  // hash the key

            // search linked list
            if (hashArray[hashVal] != null)
            {
                ChainItem ptr = hashArray[hashVal];
                while (ptr != null)
                {
                    if (ptr.GetKey() == key)
                    {
                        return true;
                    }
                    ptr = ptr.GetNext();
                }
                return false;
            }
            return false;                  // can't find item
        } // end findValue()
}
}
