//  StudentList class
//
//  Lab3
//
//  Created by Jim Bailey on 4/21/17.
//  Copyright © 2017 jim. All rights reserved.
//
//
//  Transpiled into C# by Katie Strauss 11/4/2019

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentListClasses
{
    public class StudentList
    {
        private SLink head;
        private SLink tail;


        // constructor
        public StudentList()
        {
            head = tail = null;
        }

        // add a new link at the head
        public void InsertHead(Student s)
        {
            // if empty, set up properly for head and tail
            if (head == null)
                head = tail = new SLink(s);

            // otherwise create link and set in place
            else
                head = new SLink(s, head);

        }

        // add a new link at the tail
        public void InsertTail(Student s)
        {
            // if empty, set up properly for head and tail
            if (tail == null)
                head = tail = new SLink(s);

            // otherwise create link and set in place
            else
            {
                SLink temp = new SLink(s);
                tail.SetNext(temp);
                tail = temp;
            }
        }

        // remove first link, returning its value
        // if list is empty, thow an exception
        public Student DeleteHead()
        {
            // if list empty, fail with exception
            if (head == null)
                throw new InvalidOperationException("Empty List");


            // otherwise, get value, update list, delete link
            SLink temp = head;
            Student value = temp.getValue();

            head = head.GetNext();
            //delete temp;

            // fix tail if now empty
            if (head == null)
                tail = null;

            // done, return
            return value;
        }

        // true if list is empty
        public bool IsEmpty()
        {
            return head == null;
        }

        // see if a given student is on the list
        public bool FindKey(string name)
        {
            // if empty, fail
            if (head == null)
                return false;

            // otherwise walk down the list, checking items
            for (SLink ptr = head; ptr != null; ptr = ptr.GetNext())
                // found it, go home happy
                if (ptr.getValue().GetName() == name)
                    return true;

            // done with list without finding
            return false;
        }


        // if a student is present, delete first such link
        public bool DeleteKey(string name)
        {
            // if empty, fail
            if (head == null)
                return false;

            // special case head
            if (head.getValue().GetName() == name)
            {
                DeleteHead();
                return true;
            }

            // now walk list, using nextPtr code
            SLink nextPtr = head;
            while (nextPtr.GetNext() != null)
            {
                // found it
                if (nextPtr.GetNext().getValue().GetName() == name)
                {
                    // save the link and route around it
                    SLink temp = nextPtr.GetNext();
                    nextPtr.SetNext(temp.GetNext());

                    // check for tail, update if necessary
                    if (temp == tail)
                        tail = nextPtr;

                    return true;
                }
                nextPtr = nextPtr.GetNext();
            }

            // done with list without finding
            return false;
        }
    }
}