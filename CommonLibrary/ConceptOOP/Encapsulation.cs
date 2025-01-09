using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.ConceptOOP
{
    //Encapsulation (การห่อหุ้มข้อมูล)
    public class Encapsulation
    {
        private string name;  // ซ่อนตัวแปร name
        private int age;      // ซ่อนตัวแปร age

        // Method สำหรับการเข้าถึงและเปลี่ยนแปลงข้อมูล
        public string GetName() { return name; }
        public void SetName(string value) { name = value; }

        public int GetAge() { return age; }
        public void SetAge(int value)
        {
            if (value > 0) // เงื่อนไขการตั้งค่าอายุ
            {
                age = value;
            }
        }
    }
}
