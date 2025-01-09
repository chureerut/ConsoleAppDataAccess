using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.ConceptOOP
{
    //Polymorphism (ความหลากหลาย)
    public class Polymorphism
    {
        public virtual void Speak()  // method virtual ที่สามารถ override ได้
        {
            Console.WriteLine("The animal speaks.");
        }
    }
    public class Dog2 : Polymorphism
    {
        public override void Speak() // override method ใน class Dog
        {
            Console.WriteLine("The dog barks.");
        }
    }

    public class Cat2 : Polymorphism
    {
        public override void Speak() // override method ใน class Cat
        {
            Console.WriteLine("The cat meows.");
        }
    }
}
