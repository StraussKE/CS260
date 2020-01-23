//  Char link class CLink
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
    public class CLink
    {
        private char value;
        private CLink next;
        private CLink prev;

        // constructor
        public CLink(char v, CLink n = null, CLink p = null) { value = v; next = n; prev = p; }

        // Getters
        public char GetValue() { return value; }
        public CLink GetNext() { return next; }
        public CLink GetPrev() { return prev; }
        // Setters
        public void SetNext(CLink n) { next = n; }
        public void SetPrev(CLink p) { prev = p; }
    }
}
