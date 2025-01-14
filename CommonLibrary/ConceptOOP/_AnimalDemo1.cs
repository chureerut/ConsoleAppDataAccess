using System;

namespace CommonLibrary.ConceptOOP
{
    public class _AnimalDemo1
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public virtual void MakeSound()
        {
            Console.WriteLine("The animal makes a sound.");
        }
    }

    public class Mammal : _AnimalDemo1
    {
        public void FeedMilk()
        {
            Console.WriteLine("FeedMilk.");
        }
        public override void MakeSound()
        {
            Console.WriteLine("The animal makes a sound.");
        }
    }
    public class Bird : _AnimalDemo1
    {
        public void Fly()
        {
            Console.WriteLine("FeedMilk.");
        }
        public override void MakeSound()
        {
            Console.WriteLine("The animal makes a sound.");
        }
    }
    public class Reptile : _AnimalDemo1
    {
        public override void MakeSound()
        {
            Console.WriteLine("The reptile hisses.");
        }
    }
}
