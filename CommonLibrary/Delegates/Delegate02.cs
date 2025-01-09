using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Delegates
{
    //Multicasting of a Delegate
    public class Delegate02
    {
        public delegate void rectDelegate(double height,double width);

        // "area" method
        public void area(double height, double width)
        {
            Console.WriteLine("Area is: {0}", (width * height));
        }

        // "perimeter" method
        public void perimeter(double height, double width)
        {
            Console.WriteLine("Perimeter is: {0} ", 2 * (width + height));
        }

        public void ml(double height, double width)
        {
            Console.WriteLine("ml is: {0} ", 3 * (width + height));
        }
    }
}
