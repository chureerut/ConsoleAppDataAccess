"ระดับพื้นฐาน"
1.โปรแกรมที่ต้องลง
2.โครงสร้างของโค้ด
3.ชนิดของข้อมูล
4.การสร้างตัวแปร
5.คำสั่งพื้นฐาน
6.การแปลงข้อมูล
7.การเปรียบเทียบค่า
8.การตัดสินใจด้วย IF statements
9.การตัดสินใจด้วย Switch statements
10.การทำงานซ้ำๆด้วย While
11.การทำงานซ้ำๆด้วย Do While
12.การทำงานซ้ำๆด้วย For
13.การแก้โจทย์จากรูป
14.มารู้จักกับ Array กัน

"ระดับกลาง"
1.Value type vs Reference type
-Value type  ชนิดข้อมูลพื้นฐานที่เรานิยมใช้กันเช่น int, double, bool อะไรพวกนี้อยู่ในกลุ่มของ value type
-Reference type ชนิดข้อมูลส่วนใหญ่ที่อยู่ในกลุ่มนี้จะเป็นพวก class ต่างๆและรวมถึง string ด้วย ซึ่งลักษณะเฉพาะตัวของกลุ่มนี้คือ ตัวแปรแต่ละตัวมันจะไม่เก็บข้อมูลไว้ แต่มันใช้การชี้ไปยังข้อมูลแทน 
2. Class & Field
	-object เช่น Student s1 = new Student();
	-Access Modifiers
		
		1. public เปิดให้ทุกคนเข้าใช้งานได้
		2. private ให้เฉพาะคนในคลาสมันเองใช้งานได้เท่านั้น
		3. protected ให้เฉพาะคลาสมันเอง และ คลาสลูกเท่านั้น
		4. internal ภายใน assembly เดียวกันเท่านั้นถึงใช้งานได้
		5. protected internal ภายใน assembly เดียวกัน หรือ คลาสลูกที่ต่าง assembly เท่านั้น
		6. private protected ภายใน assembly เดียวกัน หรือคลาสลูกเท่านั้น
3. Constructor มีหน้าที่กำหนดข้อมูลพื้นฐานให้กับตัวแปรต่างๆของคลาสนั้นๆ โดยมันจะมีชื่อเดียวกับคลาสของเราเป๊ะๆเลย ตามโค้ดด้านล่าง (บรรทัดที่ 3~5 นั่นแหละเจ้า constructor)
	public class Student
	{
   		public Student()
   		{
   		}
	}
	แล้วถ้าเราอยากกำหนดค่าพื้นฐานให้มันล่ะ? ก็ทำตามตัวอย่างด้านล่างได้เบย
	public class Student
	{
   		public int Name;
   		public Student()
   		{
      			Name = "Unknow";
   		}
	}
4. Method ใน Class
	- Method overloading คือการสร้าง method ที่มีชื่อเดียวกันและอยู่ภายในคลาสเดียวกัน โดยมันจะมีกฎที่ให้เราทำแบบนั้นได้คือ
	  method พวกนั้นจะต้องมี parameter ที่ไม่เหมือนกัน หรือ มี return type ต่างกัน

5. Property  => คือ Method พิเศษตัวนึงที่ช่วยให้เราเข้าถึงตัวแปรได้ง่ายๆ ผ่าน accessor ที่ชื่อว่า get กับ set
		-Get คือตัวช่วยให้เราสามารถเข้าไปเรียกดูข้อมูลได้
		-Set คือตัวช่วยให้เราสามารถเข้าไปเขียนข้อมูลได้
	Auto-Implemented Property => property ที่เราไม่ต้องไปกำหนดว่ามันจะทำงานกับตัวแปรตัวไหนเลย ซึ่ง C# จะเป็นคนจัดการให้
		public class MyClass
		{
   			public string Name { get; set; }
		}
	Property คัดกรองข้อมูลให้กับตัวแปร => เราสามารถเขียนโค้ดเพื่อจัดการกับเวลาที่มีคน แก้ไขข้อมูล หรือ เรียกดูข้อมูล ผ่าน property

	Access Modifier กับ Proper =>เราสามารถกำหนด access modifier ให้กับพวก accessors ได้นะครับ เช่นผมอยากให้ ทุกคนเรียกดูตัวแปร Name ได้ แต่ให้คลาสมันเองเท่านั้นที่แก้ไขได้ ผมก็จะได้
		public class MyClass
		{
   			public string Name { get; private set; }
		}
	Accessors ของ Property =>พวก accessors จริงๆจะมีทั้ง 2 ตัว หรือจะมีแค่ตัวใดตัวนึงก็ได้นะ
		public class MyClass
		{
   			public string Name { get; set; }
   			public int Age { get; }
   			public string Address { set; }
		}

6. Inheritance 
	โดยคลาสที่เป็นต้นแบบเราเรียกมันว่า Base Class หรือคลาสแม่ในภาษาไทย ส่วนคลาสที่สืบทอดความสามารถมาเราเรียกมันว่า Derived Class (บางตำราเรียกมันว่า Sub Class)
7. Polymorphism
	สิ่งที่สามารถทำได้เมื่อทำ inheritance แล้ว
	1.การเปลี่ยนรูปของคลาส
	2.virtual & override keyword
		เราสามารถใช้คำสั่ง virtual ให้กับ method ของ Base Class ได้ เพื่อบอกว่าถ้า Derived Class ตัวไหนอยากเปลี่ยนการทำงานไปจาก Base Class ก็สามารถเปลี่ยนได้ โดย
	3.base keyword
		เป็นการบอกว่าให้เรียกใช้งานความสามารถนั้นๆจาก Base Class
	4.sealed keyword
		เป็นการระบุว่า ณ จุดนั้นๆ ไม่อนุญาติให้คลาสอื่นๆมาสืบทอดหรือเปลี่ยนแปลงมันได้อีกต่อไปแล้ว (เป็นหมันนั่นเอง)
8. Abstract Class
	แม่แบบของคลาส หรือ Template class นั่นเอง มีแค่โครงสร้างต่างๆไว้ให้ ส่วนคลาสลูกมีหน้าที่ไปกำหนดเอาเองว่าของด้านในจริงๆจะเป็นยังไง แต่ในขณะเดียวกันมันก็มี method ที่สมบูรณ์ในนั้นได้ด้วยนะ

	Abstract class
	1.เราไม่สามารถสร้าง object จาก abstract class ได้นะ
	2.คลาสที่สืบทอด (inheritance) จาก abstract class ไปจะต้องทำการ implement abstract methods ทุกตัวทันทีด้วย
	3.ถ้า abstract class ทำการ inheritance จาก abstract ด้วยกัน จะยังไม่ทำการ implement abstract method ก็ได้นะจุ๊

	ตัวอย่างการสร้าง Abstract class โดยให้คลาสลูกเป็นคนกำหนดว่าการคำนวณพื้นที่ของรูปแบบแต่ละอย่างเป็นยังไง

	public abstract class Shape
	{
		public abstract double GetArea();
	}

	public class Circle : Shape
	{
		public double Radius { get; set; }
   
		public override double GetArea()
		{
			return 3.141 * Radius * Radius;
		}
	}

	public class Triangle : Shape
	{
		public double Width { get; set; }
		public double Height { get; set; } 
   
		public override double GetArea()
		{
			return 0.5 * Width * Height;
		}
	}
9. Interface แบบอย่างหรือมาตรฐานของคลาส โดยมันจะบังคับว่าคลาสที่ implement interface จะต้องมีทุกอย่างที่ interface นั้นๆมีด้วย	
	1.ไม่ได้เอาไว้สร้าง object แต่สามารถเก็บ object ของ class ที่ implement interface นั้นๆได้
	2.ของที่อยู่ใน interface จะไม่สามารถมี body หรือ implementation ได้ (ยกเว้น C# version 8.0 ขึ้นไป)

10. Namespace
	เป็นแค่วิธีการแบ่งแยกกลุ่มของโค้ดของเรา โดยเราจะใช้แบ่งหมวดการทำงานของโค้ดแต่ละเรื่องว่ามันใช้สำหรับทำอะไร เช่นจากตัวอย่างด้านล่างผมแยกโค้ดออกเป็น 2 กลุ่มคือ 1.ของที่เป็น data model กับ 2.ของที่ใช้ต่อฐานข้อมูล
	- using keyword
		เวลาที่เราจะเรียกใช้ namespace อะไร เราจะต้องใช้คำสั่ง using keyword ไว้ด้านบนสุดของไฟล์ เพื่อบอกว่าโค้ดที่เรากำลังเขียนอยู่นี้มันสามารถใช้ namespace อะไรได้บ้าง
		using System;
		using ProjectName.Models;

		namespace DemoConsoleApp
		{
    		class Program
    		{
        		static void Main(string[] args)
        		{
            			Teacher t01 = new Teacher();
        		}
    		}
		}
	-Aliases
		ในบางครั้งเราไม่อยากนำ namespace เข้ามาใช้ทั้งหมด เราก็สามารถสร้าง aliases ให้กับ namespace ที่จะใช้ได้ด้วยนะ ตามโค้ดด้านล่างเลย ผมใช้ aliases ที่บรรทัดที่ 1 และเรียกใช้งานมันบรรทัดที่ 9
	using sys = System;

	namespace DemoConsoleApp
		{
    			class Program
    			{
        			static void Main(string[] args)
        			{
            				sys.Console.WriteLine("Hello World!");
        			}
    			}
		}
11. Enum คือ เซ็ตของข้อมูลที่เราสร้างขึ้น โดยเบื้องหลังมันจะเก็บข้อมูลในรูปแบบของตัวเลข และเราสามารถกำหนดค่าให้มันได้ว่ามันจะมีค่าเป็นเลขอะไร แต่ถ้าเราไม่กำหนดค่ามันจะไล่เลขให้อัตโนมัติจากบนลงล่าง เริ่มจาก 0
	public enum DaysOfWeek
	{
    		Sunday = 0,
    		Monday = 1,
    		Tuesday = 2,
    		Wednesday = 3,
    		Thursday = 4,
    		Friday = 5,
    		Saturday = 6,
	}
	การแปลง string เป็น Enum
		var today = Enum.Parse<DayOfWeek>("Sunday");
12.Exception handler
	-การดักจับ exception แบบระบุ
	-Finally keyword	
	-throw keyword
	-การส่งต่อ Exception โดยมี message
	-Custom Exception
13.ลงลึกกับ string
	- รูปแบบของ string ที่แท้จริง =>ตัว string จริงๆมันจะคล้ายๆกับ array แต่มันจะเป็น array ของ char เช่นคำว่า "Hello" มันก็จะเหมือนกับมันเก็บข้อมูลแยกเป็นทีละตัว H, e, l, l, o ตามลำดับ 
	- Immutability =>ตัว string ที่ถูกสร้างขึ้นมาทุกตัวจะมีความเป็น immutable เสมอ หรือแปลง่ายๆว่า มันแก้ไขเปลี่ยนแปลงอะไรอีกไม่ได้ ถ้าสร้างมันขึ้นมาแล้ว
	- Regular & Verbatim =>string เวลาใช้งานมันสามารถใช้อักขระพิเศษทำงานด้วยเพื่อให้เกิดการทำงานแบบพิเศษๆได้ เช่น ขึ้นบรรทัดใหม่ด้วย \n หรือเป็นการเว้นยาวๆด้วย \t
	- Environment class เช่น Environment.NewLine // ใช้ตัวนี้แทน "\n" นะจ๊ะ
	-  Format strings
		Placeholder - การเว้นพื้นที่เพื่อระบุว่าพื้นที่นั้นๆจะใช้ค่าอะไรมาใส่
		Interpolation - เหมือนกับ placeholder เลย เพียงแค่กำหนดไปเลยว่าจุดนั้นๆใช้ตัวแปรอะไร
	-  Method ต่างๆของ string
		Substring - ตัด string ออกจากกัน โดยต้องระบุตำแหน่งที่จะตัดและจำนวนตัวอักษร
		IndexOf - เป็นการค้นหาว่าคำที่ระบุอยู่ในตำแหน่งที่เท่าไหร่
		Replace - แก้ไขในข้อความที่กำหนดให้เป็นค่าใหม่
14.StringBuilder เพื่อนคู่ string
	StringBuilder sb = new StringBuilder();
	sb.Append("Hello ");
	sb.Append("World!");
	Console.WriteLine(sb.ToString());

"ระดับสูง"
1. Generic
2. Delegates
3. Action & Func
4. Lambda expression
5. LINQ
6. Async & Await
7. Threading
8. Stream

