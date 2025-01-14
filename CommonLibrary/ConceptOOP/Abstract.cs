using System;

namespace CommonLibrary.ConceptOOP
{
    // abstract class
    public abstract class Shape
    {
        // abstract method ไม่มีการนำไปใช้งานภายใน class นี้
        public abstract double GetArea();
    }

    // class ที่สืบทอดจาก Shape และต้อง implement method GetArea()
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
