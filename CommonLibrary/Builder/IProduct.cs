using System;
using System.Collections.Generic;

namespace CommonLibrary.Builder
{
    public interface IProduct
    {
        IList<string> Parts { get; set; }
        void DescribeYourself();
    }
    public class House : IProduct
    {
        public IList<string> Parts { get; set; }

        public void DescribeYourself()
        {
            foreach (var item in Parts)
            {
                Console.WriteLine(item);
            }
        }
    }
}
