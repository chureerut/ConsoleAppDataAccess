Basic Structure of a C# Program
Data Type
Naming a variable
Basic operations
Value conversion
Control flow statements
Array
Methods

--**Basic Structure of a C# Program
Directive เป็นตัวบอกว่าเราจะใช้ namespace อะไรบ้าง
-> using System;

namespace มันคือ group ของ class ,interfaces, enums และ structs
->
namespace ConsoleAppDataAccess
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            log.Info("*********************************");
        }
    }
}

Statement หรือจะเรียกว่า Commands คำสั่ง
-> Console.WriteLine("SUMMER = {0}", y);

--**Data Type ประเภทของข้อมูล
Array 
DataType[] test;
ค่าเริ่มต้น =new DataType();

--**Value Type (มีการเก็บข้อมูลของตัวเอง) VS Reference Type อ้าง(ชี้)ไปหาข้อมูลแทน
==>Menthods

==>Delegates
Declaration of Delegates
[modifier] delegate [return_type] [delegate_name] ([parameter_list]);
EX. public delegate int GeeksForGeeks(int G, int F, int G);

Instantiation & Invocation of Delegates
[delegate_name]  [instance_name] = new [delegate_name](calling_method_name);
EX. GeeksForGeeks GFG = new GeeksForGeeks (Geeks);

==>Types of Constructor
Default Constructor
Parameterized Constructor
Copy Constructor
Private Constructor
Static Constructor

==>Arrays
Array Declaration
< Data Type > [ ] < Name_Array >

Array Initialization
type [ ] < Name_Array > = new < datatype > [size];
int[] intArray1 = new int[5];
int[] intArray2 = new int[5]{1, 2, 3, 4, 5};
int[] intArray3 = {1, 2, 3, 4, 5};

Accessing Array Elements
intArray[0] = 10;

--**ArrayList
ArrayList แสดงถึงคอลเลกชันแบบมีลำดับของอ็อบเจกต์ที่สามารถสร้างดัชนีได้ทีละรายการ ใน ArrayList

ArrayLiat -> IList Interface -> ICollection Interface -> IEnumerable Interface

//Creating ArrayList
ArrayList My_array = new ArrayList();

//Adding elements to ArrayList 
My_array.Add(1);

--**How to find the Capacity and Count of elements of the ArrayList?
//Displaying count of elements of ArrayList
myList.Count

//Displaying Current capacity of ArrayList
myList.Capacity

--**How to remove elements from the ArrayList?
//Remove the 'G' element
My_array.Remove('G');

//Remove the element present at index 8
My_array.RemoveAt(8);

//Remove 3 elements starting from index 1
My_array.RemoveRange(1, 3);

//Remove the all element 
My_array.Clear();

Sort 
 My_array.Sort();

//using IList Interface
IList arrlist1 = new ArrayList();

//using ICollection Interface
ICollection arrlist2 = new ArrayList();

//using IEnumerable Interface
IEnumerable arrlist3 = new ArrayList();

==> string
String [] array_variable  =  new  String[Length_of_array]

==> Tuple
// Constructor for single elements
Tuple <T1>(T1)

// Constructor for two elements
Tuple <T1, T2>(T1, T2)
.
.
.
 // Constructor for eight elements
Tuple <T1, T2, T3, T4, T5, T6, T7, TRest>(T1, T2, T3, T4, T5, T6, T7, TRest)

==> Indexers
[access_modifier] [return_type] this [argument_list]
{
  get 
  {
     // get block code
  }
  set 
  {
    // set block code
  }
}
public static int count_geeks { get; set; }

==> Interface

==> Multithreading

==> Exception

==> การสืบทอด Inheritance
-Polymorphism

==>Abstract Class แม่แบบของคลาส หรือ Template class นั่นเอง มีแค่โครงสร้างต่างๆไว้ให้

OOP CONCEPTS
1. Encapsulation การห่อหุ้มข้อมูล / การซ่อนข้อมูล
2. Abstraction การรู้แค่ที่จำเป็น
3. Inheritance การสืบทอดคุณสมบัติ
4. Polymorphism การมีหลายรูปแบบ