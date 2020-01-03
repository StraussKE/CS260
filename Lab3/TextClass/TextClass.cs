//  TextClass
//
//  Lab3
//
//  Created by Jim Bailey on 4/20/17.
//  Copyright © 2017 jim. All rights reserved.
//
//
//  Transpiled into C# by Katie Strauss 11/4/2019

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextClassClasses
{
    public class TextClass
    {
        private CLink head;        // ref to first item
        private CLink tail;        // ref to last item
        private CLink iter;        // last item found

            // constructor and destructor
        public TextClass() { head = tail = iter = null; }

        // basic add and remove
        public void InsertHead(char c)              // add new link at head of list
        {
            // check for empty list
            if (head == null)
                head = tail = new CLink(c);
            else
            {
                // create link and set up internal pointers
                CLink temp = new CLink(c, head, null);

                // set up external pointers
                head.SetPrev(temp);
                head = temp;
            }
        }
        public void InsertTail(char c)              // add new link at tail of list
        {
            // check for empty list
            if (tail == null)
                head = tail = new CLink(c);
            else
            {
                // create link and set up internal pointers
                CLink temp = new CLink(c, null, tail);

                // set up external pointers
                tail.SetNext(temp);
                tail = temp;
            }
        }
        public char DeleteHead()                    // delete first link and return its value
        {
            // error if list is empty
            if (head == null)
                throw new InvalidOperationException("Empty List");

            // something there, so process it
            CLink temp = head;
            char value = head.GetValue();

            // check for need to reset iter
            if (head == iter)
                iter = null;

            // list has one item
            if (head == tail)
            {
                head = tail = null;
            }

            // regular list, set pointers around it
            else
            {
                head = head.GetNext();
                head.SetPrev(null);
            }

            return value;
        }
        public char DeleteTail()                    // delete last link and return its value
        {
            // error if list is empty
            if (tail == null)
                throw new InvalidOperationException("Empty List");

            // something there, so process it
            CLink temp = tail;
            char value = tail.GetValue();

            // check for need to reset iter
            if (tail == iter)
                iter = null;

            // list has one item
            if (head == tail)
            {
                head = tail = null;
            }

            // regular list, set pointers around it
            else
            {
                tail = tail.GetPrev();
                tail.SetNext(null);
            }

            return value;
        }

        // maintenance methods
        public bool IsEmpty()                       // is the list empty
        {
            return head == null;
        }
        public string DisplayList()                 // convert to a string and return
        {
            string output = "";
            CLink ptr = head;
            while (ptr != null)
            {
                output += ptr.GetValue();
                ptr = ptr.GetNext();
            }
            return output;
        }

        // find methods
        public bool FindKey(char key)               // find a key and set iter
        {
            // empty list, give up
            if (head == null)
                return false;

            // local variables
            CLink ptr;
            bool firstTime;

            // now see if first time searching
            if (iter == null)
            {
                ptr = head;
                firstTime = true;
            }
            // last search was for something else
            else if (iter.GetValue() != key)
            {
                ptr = head;
                firstTime = true;
                iter = null;
            }
            else
            {
                if (iter == tail)
                    ptr = head;
                else
                    ptr = iter.GetNext();
                firstTime = false;
            }

            // now we do the actual search
            while (ptr != null)
            {
                // we found it, save ptr and return
                if (ptr.GetValue() == key)
                {
                    iter = ptr;
                    return true;
                }

                // not found yet, move on
                ptr = ptr.GetNext();

                // if not first time, loop
                if (ptr == null && !firstTime )
                    ptr = head;
            }
            return false;
        }
        public bool InsertKey(char value)           // Insert before iter
        {
            // make sure we have a valid iter, otherwise fail
            if (iter == null)
                return false;

            // special case head
            if (iter == head)
            {
                InsertHead(value);
            }

            // normal case, now just Insert it
            else
            {
                CLink temp = new CLink(value, iter, iter.GetPrev());
                iter.GetPrev().SetNext(temp);
                iter.SetPrev(temp);
            }

            return true;
        }

        public bool DeleteIter()                    // delete link pointed to by iter; fail if not set
        {
            // make sure we have a valid iter, otherwise fail
            if (iter == null)
                return false;

            // special case head and tail
            if (iter == head)
                DeleteHead();
            else if (iter == tail)
                DeleteTail();

            // typical case, deal with it
            else
            {
                iter.GetPrev().SetNext(iter.GetNext());
                iter.GetNext().SetPrev(iter.GetPrev());
            }
            return true;
        }
        public bool DeleteKey(char key)             // find and delete a link
        {
            // check for empty list
            if (head == null)
                return false;

            // special case head
            if (head.GetValue() == key)
                DeleteHead();

            //otherwise, look for the first instance
            else
            {
                // start after head, since it was already checked
                CLink ptr = head.GetNext();
                while (ptr != null)
                {
                    // found it, so delete
                    if (ptr.GetValue() == key)
                    {
                        // special case tail
                        if (ptr == tail)
                            DeleteTail();

                        // normal case, deal with it
                        else
                        {
                            // if deleting iter, set to null
                            if (ptr == iter)
                                iter = null;

                            // set links around
                            ptr.GetNext().SetPrev(ptr.GetPrev());
                            ptr.GetPrev().SetNext(ptr.GetNext());
                        }
                    }
                    ptr = ptr.GetNext();
                }
            }
            return true;
        }

        //  join two lists
        public void AppendList(TextClass other)         // join two lists by copying second
        {
            // start at the head of the other list
            CLink ptr = other.head;

            // and append all of the values
            while (ptr != null)
            {
                this.InsertTail(ptr.GetValue());
                ptr = ptr.GetNext();
            }
        }
    }
}
