using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Factory
{
    public class Cola : Beverage
    {
        public void brew()
        {
            openBottle();
            Console.WriteLine("โคล่าได้แล้วครับ");
        }

        private void openBottle()
        {
            Console.WriteLine("เปิดขวดแล้วเทใส่แก้ว");
        }
    }
}
