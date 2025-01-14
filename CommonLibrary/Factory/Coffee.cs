using System;

namespace CommonLibrary.Factory
{
    public class Coffee : Beverage
    {
        public void brew()
        {
            make();
            Console.WriteLine("กาแฟได้แล้วครับ");
        }
        private void make()
        {
            Console.WriteLine("ฉีกซองเทใส่แก้วเติมน้ำร้อน");
        }
    }
}
