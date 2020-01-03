//  Student class
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
    public class Student
    {
        private string name;
        private int age;

        // constructor
        public Student(string n = "", int a = 0) { name = n; age = a; }
        //setters
        public void SetName(string n) { name = n; }
        public void SetAge(int a) { age = a; }
        // getters
        public string GetName() { return name; }
        public int GetAge() { return age; }

    }
}
