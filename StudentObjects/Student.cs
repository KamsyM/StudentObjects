﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentObjects
{
    public class Student
    {
        public Student(int number, string first, string last, DateTime dob)
        {
            Number = number;
            FirstName = first;
            LastName = last;
            DateOfBirth = dob;

        }
        public int Number { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public int Ages { get; private set; }
        public char Grade { get; set; }
        public bool IsOverAge(int requiredAge) { return DateOfBirth.AddYears(requiredAge) >= DateTime.Today; }
        public override string ToString()
        {
            return Number.ToString() + "\t" + FirstName.ToString() + "," + LastName.ToString() + "\t" + DateOfBirth.ToString("d");
        }
    }
}
