using System;
using ConsoleAppDataAccess.commonlibrary;
using System.Reflection;
using CommonLibrary;
using CommonLibrary.Delegates;
using static CommonLibrary.Delegates.Delegate01;
using static CommonLibrary.Delegates.Delegate02;
using CommonLibrary.Constructors;
using System.Collections;
using System.Threading;
using CommonLibrary.ConceptOOP;
using System.Collections.Generic;
using CommonLibrary.Factory;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using CommonLibrary.Observer;
using CommonLibrary.Builder;
using CommonLibrary.Singleton;
using CommonLibrary.Adapter;
using System.IO;
using CommonLibrary.Facade;
using CommonLibrary.Template;
using ClassLibrary.Repository;
using ClassLibrary.Properties;
using System.Globalization;
using System.Linq;
using System.Data;

namespace ConsoleAppDataAccess
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        //private readonly IUnitOfWork _uow;
        static void Main(string[] args)
        {
            //TEST01
            //TEST02
            //TEST03
            //TEST04
            //TEST05
            //TEST06

            designLog();

            CustomRepository TEST = new CustomRepository();
            var TEST2 = TEST.TestConnectWeb("3");
            //var tesrt = IUnitOfWork.Custom.TestConnectWeb("55");
            CommonUtils.SetCurrentCultureToEnUS();
            log.Info("Set CurrentThread to EN");

            string policyno = "11002-151-230511162";
            string mobileno = "0870541156";
            EffrenewfollowSmsAuto(policyno, mobileno);

            Class1 ob = new Class1();
            ob.sayHello();

            #region Delegate
            Delegate01 delegate01 = new Delegate01();
            addnum _addnum = new addnum(delegate01.sum);
            subnum _subnum = new subnum(delegate01.subtract);

            _addnum(100, 40);
            _subnum(100, 60);

            Delegate02 delegate02 = new Delegate02();
            rectDelegate _rectDelegate = new rectDelegate(delegate02.area);

            _rectDelegate += delegate02.perimeter;
            _rectDelegate += delegate02.ml;

            _rectDelegate.Invoke(1, 2); //ร้องขอ
            _rectDelegate.Invoke(2, 2); //ร้องขอ            
            _rectDelegate.Invoke(3, 3); //ร้องขอ
            #endregion

            //Constructor
            #region Copy Constructor
            // Create a new Geeks object.
            Constructor01 g1 = new Constructor01("June", 2018);
            // here is g1 details is copied to g2.
            Constructor01 g2 = new Constructor01(g1);
            Console.WriteLine(g2.Details);
            #endregion

            #region Private Constructor
            Constructor02.count_geeks = 99;

            // Accessing without any
            // instance of the class
            Constructor02.geeks_Count();

            Console.WriteLine(Constructor02.count_geeks);

            // Accessing without any
            // instance of the class
            Constructor02.geeks_Count();

            Console.WriteLine(Constructor02.count_geeks);
            #endregion

            #region Static Constructor
            // Here Both Static and instance
            // constructors are invoked for
            // first instance
            Constructor03 obj = new Constructor03(1);

            Console.WriteLine(obj.constructor03_detail("GFG", 1));

            // Here only instance constructor
            // will be invoked
            Constructor03 obj1 = new Constructor03(2);

            Console.WriteLine(obj1.constructor03_detail("GeeksforGeeks", 2));
            #endregion

            #region ArrayList
            // Creating ArrayList
            ArrayList My_array = new ArrayList();

            // Adding elements in the 
            // My_array ArrayList
            // This ArrayList contains elements
            // of different types
            My_array.Add(12.56);
            My_array.Add("GeeksforGeeks");
            My_array.Add(null);
            My_array.Add('G');
            My_array.Add(1234);

            // Accessing the elements 
            // of My_array ArrayList
            // Using foreach loop
            foreach (var elements in My_array)
            {
                Console.WriteLine(elements);
            }
            // Displaying count of elements of ArrayList 
            Console.WriteLine("Number of elements: " + My_array.Count);

            // Displaying Current capacity of ArrayList 
            Console.WriteLine("Current capacity: " + My_array.Capacity);
            #endregion

            #region Remove ArrayList
            // Creating ArrayList
            ArrayList Remove_array = new ArrayList();

            // Adding elements in the 
            // My_array ArrayList
            // This ArrayList contains elements
            // of the same types
            Remove_array.Add('G');
            Remove_array.Add('E');
            Remove_array.Add('E');
            Remove_array.Add('K');
            Remove_array.Add('S');
            Remove_array.Add('F');
            Remove_array.Add('O');
            Remove_array.Add('R');
            Remove_array.Add('G');
            Remove_array.Add('E');
            Remove_array.Add('E');
            Remove_array.Add('K');
            Remove_array.Add('S');

            Console.WriteLine("Initial number of elements : "
                                           + Remove_array.Count);

            // Remove the 'G' element 
            // from the ArrayList
            // Using Remove() method
            Remove_array.Remove('G');
            Console.WriteLine("After Remove() method the " +
                  "number of elements: " + Remove_array.Count);

            // Remove the element present at index 8
            // Using RemoveAt() method
            Remove_array.RemoveAt(8);
            Console.WriteLine("After RemoveAt() method the " +
                    "number of elements: " + Remove_array.Count);

            // Remove 3 elements starting from index 1
            // using RemoveRange() method
            Remove_array.RemoveRange(1, 3);
            Console.WriteLine("After RemoveRange() method the" +
                     " number of elements: " + Remove_array.Count);

            // Remove the all element 
            // present in ArrayList
            // Using Clear() method
            Remove_array.Clear();
            Console.WriteLine("After Clear() method the " +
                "number of elements: " + Remove_array.Count);
            #endregion

            #region Tuple
            // Tuple with one element
            Tuple<string> My_Tuple1 = new Tuple<string>("GeeksforGeeks");

            // Tuple with three elements
            Tuple<string, string, int> My_Tuple2 = new Tuple<string, string, int>("Romil", "Python", 29);

            // Tuple with eight elements
            Tuple<int, int, int, int, int, int, int, Tuple<int>> My_Tuple3 = new Tuple<int, int, int, int, int, int, int, Tuple<int>>(1, 2, 3, 4, 5, 6, 7, new Tuple<int>(8));
            #endregion

            #region Multithreading
            // create a new thread
            Thread t = new Thread(Worker);

            // start the thread
            t.Start();

            // do some other work in the main thread
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main thread doing some work");
                Thread.Sleep(100);
            }

            // wait for the worker thread to complete
            t.Join();

            Console.WriteLine("Done");

            // queue a work item to the thread pool
            ThreadPool.QueueUserWorkItem(Worker2, "Hello, world!");

            // do some other work in the main thread
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main thread doing some work");
                Thread.Sleep(100);
            }

            Console.WriteLine("Done");

            #endregion


            Mammal _mammal = new Mammal();
            _mammal.FeedMilk();

            List<_AnimalDemo1> _animalDemo1 = new List<_AnimalDemo1>
            {
                new Mammal { Name = "Lion", Age = 5 },
                new Bird { Name = "Eagle", Age = 3 },
                new Reptile { Name = "Snake", Age = 2 }
            };

            foreach (var animal in _animalDemo1)
            {
                Console.WriteLine($"{animal.Name} ({animal.Age} years old)");
                animal.MakeSound();
                Console.WriteLine();
            }


            Factory();
            Builder();
            Singleton();
            Adapter();
            Facade();
            Observer();
            //Template();



            Customer test = new Customer();
            int param = 6;
            //Customer _test = CustomerService(param);


            #region linq
            //ObjectClass obj1 = new ObjectClass();
            //obj1.insert(101, "Tommy");
            //obj1.display();

            ////Structs
            //Rectangle r = new Rectangle();
            //r.width = 4;
            //r.height = 5;
            //Console.WriteLine("Area of Rectangle is: " + (r.width * r.height));

            //int x = (int)Season.WINTER;
            //x = 79;
            //int y = (int)Season.SUMMER;
            //Console.WriteLine("WINTER = {0}", x);
            //Console.WriteLine("SUMMER = {0}", y);

            //Programmer pro = new Programmer();
            //Console.WriteLine("Salary:" + pro.salary);
            //Console.WriteLine("Bonus:" + pro.bonus);

            //#region Generics
            //Generics<string> gen = new Generics<string>("This is generic class");
            //Generics<int> genI = new Generics<int>(101);
            //Generics<char> getCh = new Generics<char>('I');

            //Generics genC = new Generics();
            //genC.Show("This is generic method");
            //genC.Show(101);
            //genC.Show('I');
            //#endregion

            //#region Delegates
            //Calculator c1 = new Calculator(Delegates.add);//instantiating delegate  
            //Calculator c2 = new Calculator(Delegates.mul);
            //c1(20);//calling method using delegate  
            //Console.WriteLine("After c1 delegate, Number is: " + Delegates.getNumber());
            //c2(3);
            //Console.WriteLine("After c2 delegate, Number is: " + Delegates.getNumber());
            //#endregion

            //#region Reflection
            ////Get Type
            //int a = 10;
            //Type type = a.GetType();
            //Console.WriteLine(type.Name);
            ////Get Assembly
            //Type t = typeof(System.String);
            //Console.WriteLine(t.Assembly);
            ////Print Type Information
            //Type t2 = typeof(System.String);
            //Console.WriteLine(t2.FullName);
            //Console.WriteLine(t2.BaseType);
            //Console.WriteLine(t2.IsClass);
            //Console.WriteLine(t2.IsEnum);
            //Console.WriteLine(t2.IsInterface);
            //#endregion

            //Func<int> simpleMethod = () => 99;
            //int test = simpleMethod();

            //var stack = new Stack<int>();
            //stack.Push(5);
            //stack.Push(9);
            //var lastedValue = stack.Pop();
            //Console.WriteLine(lastedValue);

            ////string test3 = "";
            ////if (string.IsNullOrWhiteSpace(test3))
            ////{
            ////    throw new ArgumentNullException("name", "กรุณากำหนดชื่อเข้ามาด้วย");
            ////}

            ////where
            //var collection = Enumerable.Range(1, 100);
            //var qry = collection.Where(it => it % 5 == 0 && it % 7 == 0);
            //Console.WriteLine(qry);

            ////select 
            //var collection1 = new int[] { 1, 2, 3, 4, 5 };
            //var qry1 = collection1.Select(it => it * 10);
            //Console.WriteLine(qry1);

            //var collection2 = new[]
            //{
            //    new { Id = 1, Name = "A", Age = 10 },
            //    new { Id = 2, Name = "B", Age = 15 },
            //    new { Id = 3, Name = "C", Age = 20 },
            //};
            //var qry2 = collection2.Select(it => it.Name);
            //Console.WriteLine(qry2);

            ////SelectMany 
            //var collection3 = new[]
            //{
            //    new [] { 1, 2, 3, 4 },
            //    new [] { 5, 6, 7, 8 },
            //};
            //var qry3 = collection3.SelectMany(it => it);
            //Console.WriteLine(qry3);

            //var collection4 = Enumerable.Range(1, 100);
            ////First - เอาเฉพาะตัวแรกออกมา
            //var result = collection4.First();

            ////FirstOrDefault - เหมือนกับ First ทุกประการ ต่างกันแค่ถ้ามันดึงค่าออกมาไม่ได้มันจะส่งค่า default ของ data type นั้นๆกลับมา
            ////LastOrDefault - เหมือนกับ Last ทุกประการ ต่างกันแค่ถ้ามันดึงค่าออกมาไม่ได้มันจะส่งค่า default ของ data type นั้นๆกลับมา
            ////ElementAtOrDefault - เหมือนกับ ElementAt ทุกประการ ต่างกันแค่ถ้ามันดึงค่าออกมาไม่ได้มันจะส่งค่า default ของ data type นั้นๆกลับมา
            ////โดยปรกติผมจะแนะนำให้ใช้คำสั่ง FirstOrDefault, LastOrDefault, ElementAtOrDefault แทนมากกว่า เพราะค่า overhead ในการจัดการกับ error มันสูงกว่า
            //var result2 = collection4.FirstOrDefault();

            ////Last - เอาเฉพาะตัวสุดท้ายออกมา
            //var result3 = collection4.Last();

            ////ElementAt - เป็นการดึงค่าที่อยู่ใน index ที่กำหนดออกมา
            //var result4 = collection4.ElementAt(3);
            //Console.WriteLine(result4);

            ////Take - เป็นการสั่งให้ดึงข้อมูลจาก data source ออกมาเท่าที่เรากำหนดไว้ เช่น เราอยากดึงข้อมูลมาแค่ 5 ตัวแรกก่อน เราก็จะเขียนได้ว่า
            ////TakeLast - เหมือนกับ Take แต่จะดึงมาจากด้านหลังสุด เช่น อยากจะดึงข้อมูล 5 ตัวจากด้านหลังสุดออกมา
            //var qry4 = collection4.Take(5);
            //Console.WriteLine(qry4);

            ////TakeWhile - เป็นการสั่งให้มันดึงข้อมูลจาก data source ออกมาเรื่อยๆจนกว่าจะเจอตัวแรกที่ทำให้เงื่อนไขไม่เป็นจริง เช่น ให้ดึงมาเรื่อยๆถ้าเลขที่ดึงมามันยังน้อยกว่า 8
            //var qry5 = collection4.TakeWhile(it => it < 8);

            //var collection5 = Enumerable.Empty<int>();
            //var qry6 = collection5.DefaultIfEmpty(8);
            //qry6 = collection5.DefaultIfEmpty(9);
            //// ผลลัพท์: { 9 }

            //// สร้างเธรดใหม่และกำหนดเมธอดที่จะทำงาน
            //Thread thread1 = new Thread(DoWork);
            //Thread thread2 = new Thread(DoWork2);

            //// เริ่มต้นเธรดทั้งสอง
            //thread1.Start();
            //thread2.Start();

            //// รอให้เธรดทั้งหมดทำงานเสร็จ
            //thread1.Join();
            //thread2.Join();

            //Console.WriteLine("Main thread has finished.");
            #endregion



            int[] johnWallets = new int[] { 10 };
            int[] elonWallets = johnWallets;
            elonWallets[0] = 99;
            Console.WriteLine(johnWallets[0]); // Output:
            Console.WriteLine(elonWallets[0]);

            int age = 3;
            string name = "Saladpuk";
            string text = $"{name} is {age} year old";

            const double number = 1000.23;
            var cultures = new[] { "en-us", "th-th", "ja-jp", "de-de", "ru-ru" };

            foreach (var item in cultures)
            {
                var culture = CultureInfo.CreateSpecificCulture(item);
                var name2 = culture.EnglishName;
                var nativeNumber = number.ToString("N", culture);
                Console.WriteLine($"{name2,-25} {nativeNumber}");
            }

            string[] alphabets = new[] { "A", "B", "C", "D", "E" };

            string result2 = string.Join("then", alphabets);
            Console.WriteLine(result2);

            string path = Path.Combine("C:", "Users", "John", "Documents");



            //            1.string.Empty:
            //คืนค่าสตริงว่าง("") ใช้แทนการสร้างสตริงว่างด้วยเครื่องหมายคำพูด("")
            string emptyString = string.Empty; // สตริงว่าง
            Console.WriteLine(emptyString == ""); // True

            //            2.string.Join():
            //เชื่อมต่อองค์ประกอบในอาร์เรย์หรือคอลเลกชันเข้าด้วยกันโดยใช้ตัวคั่นที่กำหนด เช่น ช่องว่างหรือเครื่องหมายจุลภาค
            string[] words = { "Hello", "world" };
            string joinedString = string.Join(" ", words); // "Hello world"

            //            3.string.Concat():
            //นำสตริงหลายตัวมาต่อกันเพื่อให้ได้สตริงใหม่
            string part1 = "Hello";
            string part2 = "World";
            string resultConcat = string.Concat(part1, " ", part2); // "Hello World"

            //            4.string.Format():
            //ใช้สร้างสตริงจากรูปแบบที่กำหนด โดยสามารถแทรกค่าแปรผันต่าง ๆ ลงไปได้
            string nameFormat = "John";
            string formattedString = string.Format("Hello, {0}!", nameFormat); // "Hello, John!"

            //            5.string.IsNullOrEmpty():
            //ตรวจสอบว่าสตริงที่กำหนดเป็น null หรือเป็นค่าว่างหรือไม่
            string str = null;
            bool isNullOrEmpty = string.IsNullOrEmpty(str); // True

            //            6.string.IsNullOrWhiteSpace():
            //ตรวจสอบว่าสตริงเป็น null ค่าว่าง หรือประกอบด้วยช่องว่าง(space) เท่านั้นหรือไม่
            string strIsNullOrWhiteSpace = "  ";
            bool isNullOrWhiteSpace = string.IsNullOrWhiteSpace(strIsNullOrWhiteSpace); // True

            //            7.string.Compare():
            //เปรียบเทียบสตริงสองตัว หากเท่ากันจะคืนค่า 0 หากสตริงแรกเล็กกว่าให้ค่าติดลบ และหากมากกว่าจะคืนค่าบวก
            int resultCompare = string.Compare("apple", "banana"); // Returns -1 (because "apple" < "banana")

            //            8.string.Copy():
            //สร้างสำเนาของสตริง ใช้เมื่อต้องการสำเนาที่ไม่อ้างอิงถึงตัวเดิม
            string original = "Hello";
            string copy = string.Copy(original);
            Console.WriteLine(copy); // "Hello"

            //            9.string.Equals():
            //ตรวจสอบว่าสตริงสองตัวเท่ากันหรือไม่
            string str1 = "hello";
            string str2 = "hello";
            bool isEqual = str1.Equals(str2); // True

            //            10.string.Normalize():
            //คืนค่าสตริงที่ถูกจัดรูปแบบใหม่ตามมาตรฐาน Unicode(ใช้ในงานที่ต้องการรูปแบบ Unicode ที่คงที่)
            string unicodeStr = "Café";
            string normalizedStr = unicodeStr.Normalize(); // "Café" (Normalized to Unicode form C)

            //            11.string.Remove():
            //ลบส่วนหนึ่งของสตริง โดยเริ่มจากตำแหน่งที่ระบุและลบไปจนจบสตริง
            string originalRemove = "Hello World!";
            string removed = originalRemove.Remove(5); // "Hello"

            //            12.string.Contains():
            //ตรวจสอบว่าสตริงที่กำหนดมีสตริงที่เรากำหนดอยู่ภายในหรือไม่
            string sentence = "This is a test.";
            bool containsTest = sentence.Contains("test"); // True

            //            13.string.EndsWith():
            //ตรวจสอบว่าสตริงลงท้ายด้วยสตริงที่กำหนดหรือไม่
            string filename = "report.txt";
            bool endsWithTxt = filename.EndsWith(".txt"); // True

            //            14.string.IndexOf():
            //คืนค่าตำแหน่งแรกของสตริงย่อยที่พบในสตริงใหญ่ หากไม่พบจะคืนค่า -1
            string sentenceIndexOf = "Hello World!";
            int index = sentenceIndexOf.IndexOf("World"); // 6

            //            15.string.Insert():
            //แทรกสตริงเข้าไปในสตริงหลักที่ตำแหน่งที่ระบุ
            string originalInsert = "Hello World";
            string inserted = originalInsert.Insert(5, ","); // "Hello, World"

            //            16.string.LastIndexOf():
            //คืนค่าตำแหน่งสุดท้ายของสตริงย่อยในสตริงใหญ่
            string sentenceLastIndexOf = "Hello World!";
            int lastIndex = sentenceLastIndexOf.LastIndexOf("l"); // 9

            //            17.string.PadLeft():
            //เพิ่มตัวอักษรทางด้านซ้ายของสตริงเพื่อให้สตริงมีความยาวที่กำหนด
            string numberPadLeft = "42";
            string padded = numberPadLeft.PadLeft(5, '0'); // "00042"

            //            18.string.PadRight():
            //เพิ่มตัวอักษรทางด้านขวาของสตริงเพื่อให้สตริงมีความยาวที่กำหนด
            string namePadRight = "John";
            string paddedRight = namePadRight.PadRight(10, '-'); // "John------"

            //            19.string.Replace():
            //แทนที่ข้อความย่อยในสตริงด้วยข้อความใหม่
            string sentenceReplace = "Hello World!";
            string replaced = sentenceReplace.Replace("World", "C#"); // "Hello C#!"

            //            20.string.Split():
            //แยกสตริงออกเป็นอาร์เรย์ของสตริง โดยใช้ตัวแบ่งที่กำหนด เช่น ช่องว่างหรือจุลภาค
            string sentenceSplit = "apple,banana,cherry";
            string[] fruits = sentenceSplit.Split(','); // ["apple", "banana", "cherry"]

            //            21.string.StartsWith():
            //ตรวจสอบว่าสตริงเริ่มต้นด้วยข้อความที่กำหนดหรือไม่
            string sentenceStartsWith = "Hello World!";
            bool startsWithHello = sentenceStartsWith.StartsWith("Hello"); // True

            //            22.string.Substring():
            //ตัดสตริงจากตำแหน่งที่กำหนดจนถึงความยาวที่ระบุ
            string sentenceSubstring = "Hello World!";
            string sub = sentenceSubstring.Substring(6, 5); // "World"

            //            23.string.ToCharArray():
            //แปลงสตริงเป็นอาร์เรย์ของตัวอักษร(char)
            string strToCharArray = "Hello";
            char[] chars = strToCharArray.ToCharArray(); // ['H', 'e', 'l', 'l', 'o']

            //            24.string.ToLower():
            //แปลงตัวอักษรทั้งหมดในสตริงเป็นตัวพิมพ์เล็ก
            string strToLower = "HELLO";
            string lowerStr = strToLower.ToLower(); // "hello"

            //            25.string.ToUpper():
            //แปลงตัวอักษรทั้งหมดในสตริงเป็นตัวพิมพ์ใหญ่
            string strToUpper = "hello";
            string upperStr = strToUpper.ToUpper(); // "HELLO"

            //            26.string.Trim():
            //ลบช่องว่างที่อยู่ด้านหน้าและด้านหลังของสตริง
            string strTrim = "  Hello World!  ";
            string trimmed = strTrim.Trim(); // "Hello World!"

            //            27.string.TrimEnd():
            //ลบช่องว่างที่อยู่ท้ายสตริง
            string strTrimEnd = "  Hello World!  ";
            string trimmedEnd = strTrimEnd.TrimEnd(); // "  Hello World!"

            //            28.string.TrimStart():
            //ลบช่องว่างที่อยู่หน้าสตริง
            string strTrimStart = "  Hello World!  ";
            string trimmedStart = strTrimStart.TrimStart(); // "Hello World!  "

            //            คำสั่งในคลาส Path:

            //29.Path.Combine():
            //รวมส่วนต่าง ๆ ของพาธ(Path) เข้าด้วยกันเป็นพาธเดียวที่ถูกต้องตามรูปแบบของระบบปฏิบัติการ
            string pathCombine = Path.Combine("C:", "Users", "John", "Documents"); // "C:\Users\John\Documents"

            //            30.Path.GetFileName():
            //คืนชื่อไฟล์จากพาธเต็ม
            string filePath2 = @"C:\Users\John\Documents\report.txt";
            string fileName2 = Path.GetFileName(filePath2); // "report.txt"

            //            31.Path.GetPathRoot():
            //คืนส่วนของพาธที่เป็นไดเรกทอรีราก เช่น "C:\"
            string filePathGetPathRoot = @"C:\Users\John\Documents\report.txt";
            string root = Path.GetPathRoot(filePathGetPathRoot); // "C:\"

            //            32.Path.GetExtension():
            //คืนค่านามสกุลไฟล์จากพาธ
            string filePathGetExtension = @"report.txt";
            string extension = Path.GetExtension(filePathGetExtension); // ".txt"

            //            33.Path.GetDirectoryName():
            //คืนชื่อไดเรกทอรีจากพาธที่ระบุ
            string filePathGetDirectoryName = @"C:\Users\John\Documents\report.txt";
            string directory = Path.GetDirectoryName(filePathGetDirectoryName); // "C:\Users\John\Documents"

            //            34.Path.GetFullPath():
            //คืนค่าพาธเต็มจากพาธสัมพัทธ์
            string relativePath = @"..\Documents\report.txt";
            string fullPath = Path.GetFullPath(relativePath); // "C:\Users\John\Documents\report.txt" (based on current directory)

            //            35.Path.HasExtension():
            //ตรวจสอบว่าพาธมีนามสกุลไฟล์หรือไม่
            string filePathHasExtension = @"report.txt";
            bool hasExtension = Path.HasExtension(filePathHasExtension); // True

            //            36.Path.IsPathRooted():
            //ตรวจสอบว่าพาธเป็นพาธที่เริ่มต้นจากราก(root) หรือไม่(เช่น พาธที่เริ่มต้นด้วย "C:\")
            string filePathIsPathRooted = @"C:\report.txt";
            bool isRooted = Path.IsPathRooted(filePathIsPathRooted); // True

            //var culture2 = CultureInfo.CreateSpecificCulture("en-US");
            //Thread.CurrentThread.CurrentCulture = culture2;

            #region การหารตัวเลขและจัดการข้อผิดพลาด
            try
            {
                Console.Write("Enter the numerator: ");
                int numerator = int.Parse(Console.ReadLine());

                Console.Write("Enter the denominator: ");
                int denominator = int.Parse(Console.ReadLine());

                // การคำนวณที่อาจทำให้เกิดข้อผิดพลาด
                int result3 = numerator / denominator;
                Console.WriteLine($"Result: {result3}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Error: Cannot divide by zero!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: Please enter a valid number!");
            }
            finally
            {
                Console.WriteLine("End of calculation.");
            }
            #endregion

            #region การจัดการไฟล์และข้อผิดพลาด
            //try
            //{
            //    // พยายามอ่านไฟล์ที่ระบุ
            //    string filePath0 = "test.txt";
            //    string content = File.ReadAllText(filePath0);
            //    Console.WriteLine(content);
            //}
            //catch (FileNotFoundException ex)
            //{
            //    // จัดการข้อผิดพลาดหากไฟล์ไม่พบ
            //    Console.WriteLine("Error: File not found!");
            //}
            //catch (UnauthorizedAccessException ex)
            //{
            //    // จัดการข้อผิดพลาดหากไม่สามารถเข้าถึงไฟล์ได้
            //    Console.WriteLine("Error: Access to the file is denied!");
            //}
            //finally
            //{
            //    // ทำงานเสมอ ไม่ว่าจะเกิดข้อผิดพลาดหรือไม่
            //    Console.WriteLine("File reading operation finished.");
            //}
            #endregion

            #region การโยนข้อผิดพลาดด้วย throw
            try
            {
                CheckNumber(-5);  // จะทำให้เกิดข้อผิดพลาดที่เราโยนเอง
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

            ArrayList arr = new ArrayList();
            string line = @"D|7303662                  |099956|001|80901109600000047628|234336|N|19062024|11:19:57|51|095697|0001000000|C|0000035000|14001-169-230165154 |14001-169-230165154 |2         |I         |B         |0000000002|PATipForU |01|000000|        |InsureW|0|20240619|11:19:57|3101500044443|นาย|สรชัช||ศรีลมูล||||26011978|-|Supalai Premier Asoke Condominium 1750/579 ชั้น 34 บางกะปิ ห้วยขวาง กรุงเทพมหานคร|บางกะปิ|ห้วยขวาง|กรุงเทพมหานคร|0829166665|||||ห้วยขวาง|กรุงเทพมหานคร|10310";
            if (line.StartsWith("D|"))
            {
                string substringLine = line.Substring(2);
                string modifiedString = substringLine.Replace("|", ",");
                int colCountNum = modifiedString.ToString().Split(',').Count();
                if (colCountNum == 49)
                {
                    modifiedString += ",";
                }
                arr.Add(modifiedString);
                Console.WriteLine(modifiedString);
            }

            Dog test3 = new Dog();
            test3.MakeSound();


        }

        private static void designLog()
        {
            log.Info("*********************************");
            log.Info("************* BEGIN *************");
            log.Info(AppDomain.CurrentDomain.FriendlyName);
            //Info: บันทึกเหตุการณ์สำคัญ
            //แอปเริ่มต้นทำงาน
            //ผู้ใช้เข้าสู่ระบบสำเร็จ
            try
            {
                string strPR = "CSV";
                log.Debug($"Debugging process started. Input value: {strPR}");
                //Debug: ใช้ในระหว่างพัฒนา
                //การตรวจสอบค่าที่ส่งเข้าในระหว่างการทดสอบ
                //การแสดงข้อมูลระหว่างการเรียก API

                var memoryUsage0 = 85;
                if (memoryUsage0 > 80)
                {
                    log.Warn($"Memory usage is high. Current usage: {memoryUsage0} MB");
                    //Warn: บันทึกเหตุการณ์ที่อาจมีปัญหา
                    //การแจ้งเตือน Memory หรือ Disk ที่ใกล้เต็ม
                    //การเรียกใช้ Service ภายนอกล่าช้ากว่าปกติ
                }

            }
            catch (Exception ex)
            {
                log.Error(ex);
                //Error: บันทึกข้อผิดพลาดที่ส่งผลต่อการทำงาน
                //การเชื่อมต่อฐานข้อมูลล้มเหลว
                //Exception ระหว่างการประมวลผล
                throw;
            }

            var userId = "Nong";
            #region Info
            //log.Info
            //1. บันทึกการเริ่มต้นระบบ
            //บันทึกเมื่อแอปพลิเคชันเริ่มต้นทำงาน เพื่อใช้ตรวจสอบช่วงเวลาที่แอปทำงาน
            log.Info($"Application started at {DateTime.Now}");

            //2. บันทึกเมื่อผู้ใช้เข้าสู่ระบบสำเร็จ
            //ใช้บันทึกการเข้าสู่ระบบของผู้ใช้ เพื่อช่วยในการตรวจสอบกิจกรรมของระบบ
            log.Info($"User {userId} logged in successfully at {DateTime.Now}.");

            //3. บันทึกเหตุการณ์ที่สำคัญ
            //ใช้บันทึกการส่งออกข้อมูลสำเร็จ พร้อมระบุชื่อไฟล์และขนาด
            var fileName = "DataFile";
            var fileSize = "3 MB";
            log.Info($"Data export completed. File name: {fileName}, Size: {fileSize} MB.");

            //4. บันทึกกิจกรรมในระบบ (Business Operation)
            //ใช้บันทึกการดำเนินการสำคัญ เช่น การสั่งซื้อสำเร็จ
            string orderId = "12453";
            string totalAmount = "10,000";
            log.Info($"Order ID {orderId} processed successfully for User ID {userId}. Total amount: {totalAmount} THB.");

            //5. บันทึกการตั้งค่าหรือค่าคอนฟิก
            //ใช้บันทึกค่าคอนฟิกของระบบ เพื่อช่วยในการวิเคราะห์หากมีปัญหาในภายหลัง
            string environment = "UAT";
            string appVersion = "9";
            log.Info($"Configuration loaded. Environment: {environment}, Version: {appVersion}.");

            //6.บันทึกกิจกรรมจาก API
            //ใช้บันทึกการเรียก API เพื่อช่วยตรวจสอบกิจกรรมของผู้ใช้งาน
            string apiName = "APIPAYMENT";
            string parameters = "BACK";
            log.Info($"API {apiName} called by User ID {userId}. Parameters: {parameters}.");

            //คำแนะนำเพิ่มเติม
            //Log สำหรับเหตุการณ์สำคัญเท่านั้น: ไม่ควรใช้ Log.Information ในสถานการณ์ที่ไม่สำคัญ เพื่อไม่ให้เกิด "Log Noise"
            #endregion

            #region Warn
            //ตัวอย่างการใช้งาน
            //1.แจ้งเตือน Memory Usage ที่สูง
            //Memory ใกล้ถึงระดับที่อาจทำให้ระบบช้าหรือไม่เสถียร
            var memoryUsage = 85; // ตัวอย่าง Memory Usage ใน %
            if (memoryUsage > 80)
            {
                log.Warn($"Memory usage is high. Current usage: {memoryUsage}%");
            }

            //2.แจ้งเตือนการพยายามเข้าถึงไฟล์ที่ไม่มีอยู่
            //ระบบพยายามเข้าถึงไฟล์แต่หาไม่เจอ
            var filePath = "data.txt";
            if (!File.Exists(filePath))
            {
                log.Warn($"File not found: {filePath}. Please check if the file exists.");
            }
            //3. แจ้งเตือนการใช้ API ที่ไม่รองรับ
            //ผู้ใช้เรียก API รุ่นเก่าที่อาจไม่มีการสนับสนุนอีกต่อไป
            var apiVersion = "v1";
            if (apiVersion != "v2")
            {
                log.Warn($"Unsupported API version used: {apiVersion}. Recommend upgrading to v2.");
            }

            //4. แจ้งเตือนพฤติกรรมที่อาจผิดปกติ
            //ผู้ใช้ใส่รหัสผิดหลายครั้ง อาจบ่งชี้ความพยายามโจมตี
            var loginAttempts = 5;
            if (loginAttempts > 3)
            {
                log.Warn($"Multiple login attempts detected: {loginAttempts} attempts for User ID {userId}.");
            }

            //5. แจ้งเตือน Disk Usage ใกล้เต็ม
            //พื้นที่ในดิสก์ใกล้เต็ม อาจทำให้การบันทึกข้อมูลล้มเหลว
            var diskUsage = 92; // ตัวอย่าง Disk Usage ใน %
            if (diskUsage > 90)
            {
                log.Warn($"Disk usage is critically high: {diskUsage}%. Consider cleaning up space.");
            }
            //คำแนะนำเพิ่มเติม
            //บริบทใน Log สำคัญมาก: เพิ่มข้อมูลเพิ่มเติม เช่น User ID, Request ID, หรือ Operation ID เพื่อช่วยในการวิเคราะห์
            //ใช้เงื่อนไขเพื่อลด Noise: Log Warning เฉพาะเมื่อปัญหานั้นสำคัญจริง ๆ
            #endregion

            #region Debug
            //ตัวอย่างการใช้งาน Log.Debug
            //1. ตรวจสอบค่าพารามิเตอร์ที่ส่งเข้า
            //ใช้บันทึกค่าเริ่มต้นของพารามิเตอร์ที่ส่งเข้าไปในฟังก์ชัน เพื่อดูว่าค่าที่ส่งมาถูกต้องหรือไม่
            string inputValue = "input3";
            log.Debug($"Starting process with input: {inputValue}");

            //2. บันทึกค่าระหว่างการทำงาน
            //ใช้บันทึกค่าระหว่างขั้นตอนการประมวลผลในโค้ด เช่น ค่าที่ได้จากการคำนวณ หรือค่าที่คืนกลับจากฟังก์ชันย่อย
            string stepNumber = "012345";
            string resultValue = "Success";
            log.Debug($"Intermediate result at step {stepNumber}: {resultValue}");

            //3. ติดตามการทำงานของโค้ด
            //ใช้บันทึกการเรียกใช้เมธอด เพื่อช่วยติดตามลำดับการทำงาน
            string ClassName = "SUB";
            log.Debug($"Executing method {MethodBase.GetCurrentMethod()} in class {ClassName}");

            //4. ตรวจสอบการเชื่อมต่อกับฐานข้อมูล
            //ใช้บันทึกข้อมูลที่เกี่ยวข้องกับการตั้งค่าการเชื่อมต่อฐานข้อมูล เพื่อช่วยตรวจสอบปัญหาการเชื่อมต่อ
            string connectionString = "LinkUAT";
            log.Debug($"Attempting to connect to database with connection string: {connectionString}");

            //5. ตรวจสอบการส่งข้อมูลไปยัง API
            //ใช้บันทึกข้อมูลที่ส่งไปยัง API เพื่อช่วยวิเคราะห์ปัญหาที่เกี่ยวข้องกับการส่งหรือรับข้อมูล
            log.Debug($"Sending API request to {"apiEndpoint"} with payload: {"payload"}");

            //6. ตรวจสอบผลลัพธ์จากการเรียกฟังก์ชัน
            //ใช้บันทึกผลลัพธ์ที่ได้จากฟังก์ชัน เพื่อช่วยตรวจสอบค่าที่ผิดปกติ
            var result = "SomeFunction";
            log.Debug($"Result from SomeFunction: {result}");

            //คำแนะนำเพิ่มเติม
            //ใช้ในสภาพแวดล้อมการพัฒนา(Development Only): ควรตั้งค่าระดับ Debug ในระบบ Production ให้แสดงผลเฉพาะเมื่อจำเป็นเท่านั้น
            //บันทึกเฉพาะจุดสำคัญ: ควรโฟกัสไปที่ข้อมูลที่ช่วยในการวิเคราะห์ปัญหา เช่น พารามิเตอร์, ค่ากลาง, หรือผลลัพธ์ของฟังก์ชัน
            //อย่าบันทึกข้อมูลที่มีความอ่อนไหว: เช่น รหัสผ่าน, Token, หรือข้อมูลส่วนบุคคลใน Log.Debug
            #endregion

            #region Error
            //log.Error
            //1. บันทึก Exception
            //ใช้บันทึกข้อผิดพลาดที่เกิดขึ้นจาก Exception พร้อมกับข้อความที่อธิบายเหตุการณ์

            try
            {
                // Simulate a process
                throw new InvalidOperationException("Invalid operation encountered.");
            }
            catch (Exception ex)
            {
                log.Error($"{ex} An error occurred while processing the request.");
            }
            //2. บันทึกเมื่อการเชื่อมต่อฐานข้อมูลล้มเหลว
            //ใช้บันทึกข้อมูลการเชื่อมต่อที่ล้มเหลว เช่น Connection String หรือ Database Name
            try
            {
                // Simulate database connection
                throw new Exception("Unable to connect to the database.");
            }
            catch (Exception ex)
            {
                log.Error($"{ex} Failed to connect to database. Connection string: {connectionString}");
            }

            //3. บันทึกข้อผิดพลาดจาก API
            //ใช้บันทึกข้อผิดพลาดจากการเรียก API พร้อมกับ URL ที่เกี่ยวข้อง

            try
            {
                // Simulate API call
                throw new Exception("API response returned 500 Internal Server Error.");
            }
            catch (Exception ex)
            {
                log.Error($"{ex} Error occurred while calling API: {"https://www.google.co.uk/"}");
            }
            //4. บันทึกเมื่อการประมวลผลไฟล์ล้มเหลว
            //ใช้บันทึกข้อผิดพลาดที่เกี่ยวข้องกับการจัดการไฟล์ เช่น ไฟล์ไม่พบ หรือไม่สามารถอ่านไฟล์ได้
            try
            {
                // Simulate file processing
                throw new Exception("File not found.");
            }
            catch (Exception ex)
            {
                log.Error($"{ex} Failed to process file: {fileName}");
            }

            //5. บันทึกข้อผิดพลาดที่เกี่ยวข้องกับการ Validate ข้อมูล
            //ใช้บันทึกข้อผิดพลาดที่เกิดขึ้นจากการ Validate ข้อมูลของผู้ใช้
            string userInput = "EN.01";
            try
            {
                if (string.IsNullOrEmpty(userInput))
                    throw new ArgumentException("User input cannot be empty.");
            }
            catch (Exception ex)
            {
                log.Error($"{ex} Validation error occurred for input: {userInput}");
            }


            #endregion

            log.Info("*********************************");
            log.Info("************* BEGIN *************");
        }
        public static void EffrenewfollowSmsAuto(string policyno, string mobileno)
        {
            log.Info("***************************************");
            log.Info("***** BEGIN EffrenewfollowSmsAuto *****");
            log.Info(AppDomain.CurrentDomain.FriendlyName);
            log.Info(string.Format("parameter policyno : {0}, mobileno : {1} ", policyno, mobileno));



            log.Info("Step 1 : check the PolicyNo records in the table effrenewfollow");
            var resultCheckPolicyNo = "";
            if (resultCheckPolicyNo.Count() > 0)
            {
                log.Info(string.Format("Records found : {0}", resultCheckPolicyNo.Count()));

                //Query SeqNoMax 
                log.Info("Step 2 : Query SeqNoMax");
                int SeqNoMax = 0;

                var dataEffreNewRow = ""; //function

                //Update record policy old lastversion = 'N'
                log.Info("Step 3 : Update record policy old lastversion = 'N'");
                //da EffrenewfollowRow();

                log.Info(string.Format("Step 4 : Update the PolicyNo {0} record into the table EffRenewFollow.", policyno));

                //update
                string resultUpdate = "";

                log.Info(string.Format("Update the PolicyNo {0} : {1}", policyno, resultUpdate));
            }
            else
            {
                log.Info("No records found.");
                log.Info(string.Format("Step 2 : Insert the PolicyNo {0} record into the table EffRenewFollow.", policyno));

                //insert
                string resultInsert = "";

                log.Info(string.Format("Insert the PolicyNo {0} : {1}", policyno, resultInsert));
            }
            log.Info("*****************************************************");
            log.Info("************* END EffrenewfollowSmsAuto *************");
        }

        public class Animal
        {
            public virtual void MakeSound()
            {
                Console.WriteLine("Animal makes a sound");
            }
        }

        public class Dog : Animal
        {
            public sealed override void MakeSound()  // ห้าม override ในคลาสลูกต่อไป
            {
                Console.WriteLine("Bark");
            }
        }

        static void CheckNumber(int number)
        {
            if (number < 0)
            {
                // โยนข้อผิดพลาดออกมาเพื่อให้จัดการภายนอก
                throw new ArgumentException("Number must be non-negative.");
            }
            Console.WriteLine($"Number is: {number}");
        }
        //private static Customer CustomerService(int param)
        //{
        //    throw new NotImplementedException();
        //}

        static void Worker()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Worker thread doing some work");
                Thread.Sleep(100);
            }
        }

        static void Worker2(object state)
        {
            string message = (string)state;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(message);
                Thread.Sleep(100);
            }
        }

        public static void Factory()
        {
            Barista _Obj = new Barista();

            //สั่งกาแฟ
            Beverage _coffee = _Obj.order("coffee");
            _coffee.brew();

            //สั่งชาเขียว
            Beverage _greentea = _Obj.order("greentea");
            _greentea.brew();

            //สั่งโค้ก
            Beverage _cola = _Obj.order("cola");
            _cola.brew();

            Console.WriteLine("App: Launched with the RoadLogistics.");
            ClientMethod(new RoadLogistics());

            Console.WriteLine("App: Launched with the SeaLogistics.");
            ClientMethod(new SeaLogistics());

        }

        private static void ClientMethod(Logistics creator)
        {
            Console.WriteLine($"Client: I'm not aware of the creator's class, but it still works. {creator.PlanDelivery()}");
        }

        public static void Observer()
        {
            var student = new Student();
            var teacher = new Teacher();

            SchoolMessager publisher = new SchoolMessager();
            publisher.Subscribe(student);
            publisher.Subscribe(teacher);

            Console.WriteLine("โรงเรียนประกาศข้อความออกไป");
            publisher.SendMessage("ขณะนี้ฝุ่น 2.9 ระบาดในโรงเรียนแล้วนะจุ๊");

            Console.WriteLine("นักเรียนไม่ต้องการรับข่าวสารอีกต่อไป");
            publisher.Unsubscribe(student);

            Console.WriteLine("โรงเรียนประกาศข้อความออกไป");
            publisher.SendMessage("ขอให้คุณครูทุกคนจับเด็กเอาไว้ก่อน อย่าพึ่งปล่อยให้มันหนีไป");

        }

        public static void Builder()
        {
            Console.WriteLine("1.Build a wooden house");
            var woodenHouseBuilder = new WoodenHouseBuilder();
            var director1 = new HouseDirector(woodenHouseBuilder);
            director1.BuildHouse();
            woodenHouseBuilder.GetHouse().DescribeYourself();

            Console.WriteLine("2.Build a brick house with swimming pool");
            var brickHouseBuilder = new BrickHouseBuilder();
            var director2 = new HouseDirector(brickHouseBuilder);
            director2.BuildHouseWithSwimmingPool();
            brickHouseBuilder.GetHouse().DescribeYourself();
        }

        public static void Singleton()
        {
            Database.Instance.Query("select * from myTable");
        }

        public static void Adapter()
        {
            var adapter = new YoutubeAdapter();
            var acc = adapter.GetAccountInfo();
            Console.WriteLine($"Id: {acc.Id}, Name: {acc.Name}, Age: {acc.Age}");
        }

        public static void Facade()
        {
            Stream src = null;
            var facade = new VideoFacade();
            var url = facade.UploadVideoAndGetUrl(src);
            Console.WriteLine(url);
        }


    }

}
