using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperateOverloading
{
    public class Student
    {
        public Student(string name,string lastName,int age,int number)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            Number = number;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Number { get; set; }

        public static bool operator ==(Student s1, Student s2)
        {
            return s1.LastName == s2.LastName;
        }

        public static bool operator !=(Student s1, Student s2)
        {
            return !(s1 == s2);
        }
        public static int operator +(Student s1, Student s2)
        {
            var result = s1.Age + s2.Age;
            if (result < 30)
            {
                result += 10;
            }

            return result;
        }
        public static int operator -(Student s1, Student s2)
        {
            var result = s1.Age + s2.Age;
            if (result > 30)
            {
                result -= 10;
            }

            return result;
        }

        public static int operator +(Student s1, int a)
        {
            var result = s1.Age + a;
            return result;
        }
    }
}
