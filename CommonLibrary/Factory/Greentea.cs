using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Factory
{
    public class Greentea : Beverage
    {
        public void brew()
        {
            collectingTeaLeaves();
            Console.WriteLine("ชาเขียวได้แล้วค่ะ");
        }

        private void collectingTeaLeaves()
        {
            Console.WriteLine("เก็บยอดอ่อนใบชาจากความสูง 1200 เมตร เหนือน้ำทะเล");
        }
    }
}
