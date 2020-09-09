using System;
using System.Collections.Generic;

namespace HelloWorld
{
    // Here is my simple object that support object cloning.
    // I already build a function called copyclone to clone this object.
    public class Person
    {
        public string Name;

        public Person CopyClone()
        {
            return (Person)this.MemberwiseClone();
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            // firstly we build a object using new instantiation
            Person person = new Person();

            //next time we will clone that object by theh function copyclone.
            // we will also pass the name param dynamically.
            // clone1
            Person person1 = person.CopyClone();
            person1.Name = "Hlaing";

            // clone2
            Person person2 = person.CopyClone();
            person2.Name = "Tin";


            Console.WriteLine(person1.Name);
            Console.WriteLine(person2.Name);
        }

        
    }

}
