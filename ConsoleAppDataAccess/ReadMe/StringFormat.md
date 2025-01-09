1.string.Empty:
คืนค่าสตริงว่าง ("") ใช้แทนการสร้างสตริงว่างด้วยเครื่องหมายคำพูด ("")
string emptyString = string.Empty; // สตริงว่าง
Console.WriteLine(emptyString == ""); // True

2.string.Join():
เชื่อมต่อองค์ประกอบในอาร์เรย์หรือคอลเลกชันเข้าด้วยกันโดยใช้ตัวคั่นที่กำหนด เช่น ช่องว่างหรือเครื่องหมายจุลภาค
string[] words = { "Hello", "world" };
string joinedString = string.Join(" ", words); // "Hello world"

3.string.Concat():
นำสตริงหลายตัวมาต่อกันเพื่อให้ได้สตริงใหม่
string part1 = "Hello";
string part2 = "World";
string result = string.Concat(part1, " ", part2); // "Hello World"

4.string.Format():
ใช้สร้างสตริงจากรูปแบบที่กำหนด โดยสามารถแทรกค่าแปรผันต่าง ๆ ลงไปได้
string name = "John";
string formattedString = string.Format("Hello, {0}!", name); // "Hello, John!"

5.string.IsNullOrEmpty():
ตรวจสอบว่าสตริงที่กำหนดเป็น null หรือเป็นค่าว่างหรือไม่
string str = null;
bool isNullOrEmpty = string.IsNullOrEmpty(str); // True

6.string.IsNullOrWhiteSpace():
ตรวจสอบว่าสตริงเป็น null ค่าว่าง หรือประกอบด้วยช่องว่าง (space) เท่านั้นหรือไม่
string str = "  ";
bool isNullOrWhiteSpace = string.IsNullOrWhiteSpace(str); // True

7.string.Compare():
เปรียบเทียบสตริงสองตัว หากเท่ากันจะคืนค่า 0 หากสตริงแรกเล็กกว่าให้ค่าติดลบ และหากมากกว่าจะคืนค่าบวก
int result = string.Compare("apple", "banana"); // Returns -1 (because "apple" < "banana")

8.string.Copy():
สร้างสำเนาของสตริง ใช้เมื่อต้องการสำเนาที่ไม่อ้างอิงถึงตัวเดิม
string original = "Hello";
string copy = string.Copy(original);
Console.WriteLine(copy); // "Hello"

9.string.Equals():
ตรวจสอบว่าสตริงสองตัวเท่ากันหรือไม่
string str1 = "hello";
string str2 = "hello";
bool isEqual = str1.Equals(str2); // True

10.string.Normalize():
คืนค่าสตริงที่ถูกจัดรูปแบบใหม่ตามมาตรฐาน Unicode (ใช้ในงานที่ต้องการรูปแบบ Unicode ที่คงที่)
string unicodeStr = "Café";
string normalizedStr = unicodeStr.Normalize(); // "Café" (Normalized to Unicode form C)

11.string.Remove():
ลบส่วนหนึ่งของสตริง โดยเริ่มจากตำแหน่งที่ระบุและลบไปจนจบสตริง
string original = "Hello World!";
string removed = original.Remove(5); // "Hello"

12.string.Contains():
ตรวจสอบว่าสตริงที่กำหนดมีสตริงที่เรากำหนดอยู่ภายในหรือไม่
string sentence = "This is a test.";
bool containsTest = sentence.Contains("test"); // True

13.string.EndsWith():
ตรวจสอบว่าสตริงลงท้ายด้วยสตริงที่กำหนดหรือไม่
string filename = "report.txt";
bool endsWithTxt = filename.EndsWith(".txt"); // True

14.string.IndexOf():
คืนค่าตำแหน่งแรกของสตริงย่อยที่พบในสตริงใหญ่ หากไม่พบจะคืนค่า -1
string sentence = "Hello World!";
int index = sentence.IndexOf("World"); // 6

15.string.Insert():
แทรกสตริงเข้าไปในสตริงหลักที่ตำแหน่งที่ระบุ
string original = "Hello World";
string inserted = original.Insert(5, ","); // "Hello, World"

16.string.LastIndexOf():
คืนค่าตำแหน่งสุดท้ายของสตริงย่อยในสตริงใหญ่
string sentence = "Hello World!";
int lastIndex = sentence.LastIndexOf("l"); // 9

17.string.PadLeft():
เพิ่มตัวอักษรทางด้านซ้ายของสตริงเพื่อให้สตริงมีความยาวที่กำหนด
string number = "42";
string padded = number.PadLeft(5, '0'); // "00042"

18.string.PadRight():
เพิ่มตัวอักษรทางด้านขวาของสตริงเพื่อให้สตริงมีความยาวที่กำหนด
string name = "John";
string paddedRight = name.PadRight(10, '-'); // "John------"

19.string.Replace():
แทนที่ข้อความย่อยในสตริงด้วยข้อความใหม่
string sentence = "Hello World!";
string replaced = sentence.Replace("World", "C#"); // "Hello C#!"

20.string.Split():
แยกสตริงออกเป็นอาร์เรย์ของสตริง โดยใช้ตัวแบ่งที่กำหนด เช่น ช่องว่างหรือจุลภาค
string sentence = "apple,banana,cherry";
string[] fruits = sentence.Split(','); // ["apple", "banana", "cherry"]

21.string.StartsWith():
ตรวจสอบว่าสตริงเริ่มต้นด้วยข้อความที่กำหนดหรือไม่
string sentence = "Hello World!";
bool startsWithHello = sentence.StartsWith("Hello"); // True

22.string.Substring():
ตัดสตริงจากตำแหน่งที่กำหนดจนถึงความยาวที่ระบุ
string sentence = "Hello World!";
string sub = sentence.Substring(6, 5); // "World"

23.string.ToCharArray():
แปลงสตริงเป็นอาร์เรย์ของตัวอักษร (char)
string str = "Hello";
char[] chars = str.ToCharArray(); // ['H', 'e', 'l', 'l', 'o']

24.string.ToLower():
แปลงตัวอักษรทั้งหมดในสตริงเป็นตัวพิมพ์เล็ก
string str = "HELLO";
string lowerStr = str.ToLower(); // "hello"

25.string.ToUpper():
แปลงตัวอักษรทั้งหมดในสตริงเป็นตัวพิมพ์ใหญ่
string str = "hello";
string upperStr = str.ToUpper(); // "HELLO"

26.string.Trim():
ลบช่องว่างที่อยู่ด้านหน้าและด้านหลังของสตริง
string str = "  Hello World!  ";
string trimmed = str.Trim(); // "Hello World!"

27.string.TrimEnd():
ลบช่องว่างที่อยู่ท้ายสตริง
string str = "  Hello World!  ";
string trimmedEnd = str.TrimEnd(); // "  Hello World!"

28.string.TrimStart():
ลบช่องว่างที่อยู่หน้าสตริง
string str = "  Hello World!  ";
string trimmedStart = str.TrimStart(); // "Hello World!  "

คำสั่งในคลาส Path:

29.Path.Combine():
รวมส่วนต่าง ๆ ของพาธ (Path) เข้าด้วยกันเป็นพาธเดียวที่ถูกต้องตามรูปแบบของระบบปฏิบัติการ
string path = Path.Combine("C:", "Users", "John", "Documents"); // "C:\Users\John\Documents"

30.Path.GetFileName():
คืนชื่อไฟล์จากพาธเต็ม
string filePath = @"C:\Users\John\Documents\report.txt";
string fileName = Path.GetFileName(filePath); // "report.txt"

31.Path.GetPathRoot():
คืนส่วนของพาธที่เป็นไดเรกทอรีราก เช่น "C:\"
string filePath = @"C:\Users\John\Documents\report.txt";
string root = Path.GetPathRoot(filePath); // "C:\"

32.Path.GetExtension():
คืนค่านามสกุลไฟล์จากพาธ
string filePath = @"report.txt";
string extension = Path.GetExtension(filePath); // ".txt"

33.Path.GetDirectoryName():
คืนชื่อไดเรกทอรีจากพาธที่ระบุ
string filePath = @"C:\Users\John\Documents\report.txt";
string directory = Path.GetDirectoryName(filePath); // "C:\Users\John\Documents"

34.Path.GetFullPath():
คืนค่าพาธเต็มจากพาธสัมพัทธ์
string relativePath = @"..\Documents\report.txt";
string fullPath = Path.GetFullPath(relativePath); // "C:\Users\John\Documents\report.txt" (based on current directory)

35.Path.HasExtension():
ตรวจสอบว่าพาธมีนามสกุลไฟล์หรือไม่
string filePath = @"report.txt";
bool hasExtension = Path.HasExtension(filePath); // True

36.Path.IsPathRooted():
ตรวจสอบว่าพาธเป็นพาธที่เริ่มต้นจากราก (root) หรือไม่ (เช่น พาธที่เริ่มต้นด้วย "C:\")
string filePath = @"C:\report.txt";
bool isRooted = Path.IsPathRooted(filePath); // True

37. set เวลา
var culture = CultureInfo.CreateSpecificCulture("en-US");
Thread.CurrentThread.CurrentCulture = culture;
