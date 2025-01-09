using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Observer
{
    public interface ISubscriber
    {
        void Update(string msg);
    }

    public class Student : ISubscriber
    {
        public void Update(string msg) => Console.WriteLine($"นักเรียนได้รับข้อความใหม่ว่า, {msg}");
    }

    public class Teacher : ISubscriber
    {
        public void Update(string msg) => Console.WriteLine($"อาจารย์ได้รับข้อความใหม่ว่า, {msg}");
    }
}
