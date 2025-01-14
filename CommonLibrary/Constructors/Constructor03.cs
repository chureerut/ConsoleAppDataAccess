using System;

namespace CommonLibrary.Constructors
{
    //Static Constructor
    public class Constructor03
    {
        // It is invoked before the first
        // instance constructor is run.
        static Constructor03()
        {

            // The following statement produces
            // the first line of output,
            // and the line occurs only once.
            Console.WriteLine("Static Constructor");
        }

        // Instance constructor.
        public Constructor03(int i)
        {
            Console.WriteLine("Instance Constructor " + i);
        }

        // Instance method.
        public string constructor03_detail(string name, int id)
        {
            return "Name:" + name + " id:" + id;
        }
    }
}
