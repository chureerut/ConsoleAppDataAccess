using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.ConceptOOP
{
    public class _EmployeeDemo2
    {
        public string Name { get; set; }
        public int Id { get; set; }
        //public int Salary { get; set; }
        public string Department { get; set; }

        private int salary;  // ซ่อน Salary ไว้ไม่ให้เข้าถึงโดยตรง

        public virtual void Work()
        {
            Console.WriteLine($"{Name} is managing the team.");
        }

        // Method สำหรับการเข้าถึง Salary
        public int GetSalary()
        {
            return salary;
        }

        // Method สำหรับการปรับเพิ่มเงินเดือน
        public void IncreaseSalary(int amount)
        {
            if (amount > 0)
            {
                salary += amount;
                Console.WriteLine($"Salary increased by {amount}. New salary: {salary}");
            }
            else
            {
                Console.WriteLine("Increase amount must be positive.");
            }
        }

        // Method สำหรับการลดเงินเดือน แต่ห้ามลดน้อยกว่า 0
        public void DecreaseSalary(int amount)
        {
            if (amount > 0 && salary - amount >= 0)
            {
                salary -= amount;
                Console.WriteLine($"Salary decreased by {amount}. New salary: {salary}");
            }
            else
            {
                Console.WriteLine("Decrease amount is invalid or salary would be negative.");
            }
        }
    }

    public class Manager : _EmployeeDemo2
    {       
        public List<_EmployeeDemo2> TeamMembers = new List<_EmployeeDemo2>();
        public void AddTeamMember(_EmployeeDemo2 employee)
        {
            TeamMembers.Add(employee);
            Console.WriteLine($"{employee.Name} has been added to {Name}'s team.");
        }

        public override void Work()
        {
            Console.WriteLine($"{Name} is managing the team.");
        }

        public List<_EmployeeDemo2> GetTeamMembers()
        {
            return TeamMembers;
        }
    }
    public class Developer : _EmployeeDemo2
    {
        public string Project { get; set; }
        public override void Work()
        {
            Console.WriteLine($"{Name} is writing code.");
        }
    }
}
