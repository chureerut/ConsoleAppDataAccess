using System;

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
