using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.ConceptOOP
{
    //Inheritance (การสืบทอด)
    // Class พื้นฐาน (Base class)
    public class Inheritance
    {
        public string Name { get; set; }

        public void Speak()
        {
            Console.WriteLine("The animal makes a sound.");
        }
    }

    // Class ที่สืบทอดจาก Animal
    public class Dog : Inheritance
    {
        public void Bark()
        {
            Console.WriteLine("The dog barks.");
        }
    }
}
