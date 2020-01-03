//  Student link class SLink
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

namespace StudentListClasses
{
    public class SLink
    {
        private Student value;
        private SLink next;

        // constructor
        public SLink(Student v, SLink n = null) { value = v; next = n; }

        // setter
        public void SetNext(SLink n) { next = n; }

        // getters
        public SLink GetNext() { return next; }
        public Student getValue() { return value; }
    };
}
