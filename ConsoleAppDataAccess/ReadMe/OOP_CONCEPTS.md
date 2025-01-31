OOP CONCEPTS
1. Encapsulation การห่อหุ้มข้อมูล / การซ่อนข้อมูล
2. Abstraction การรู้แค่ที่จำเป็น
3. Inheritance การสืบทอดคุณสมบัติ
4. Polymorphism การมีหลายรูปแบบ


==>Encapsulation เป็นการจัดการข้าวของภายในตัว Model ของเรา เพื่อให้คนอื่นเรียกใช้งานได้ง่ายๆ ในขณะที่เรายังป้องกันข้อมูลที่สำคัญจากภายนอกเอาไว้ได้
Encapsulation คือการซ่อนรายละเอียดการทำงานของวัตถุ และให้เข้าถึงหรือแก้ไขข้อมูลผ่าน method (ฟังก์ชัน) ที่กำหนดเท่านั้น เพื่อป้องกันการเปลี่ยนแปลงข้อมูลโดยตรงจากภายนอก และรักษาความถูกต้องของข้อมูล

==>Inheritance คือการสร้าง class ใหม่โดยใช้คุณสมบัติของ class ที่มีอยู่แล้ว (เรียกว่า superclass หรือ base class) เพื่อนำคุณสมบัติมาใช้ซ้ำ และสามารถขยายหรือเพิ่มคุณสมบัติใหม่ได้

==>Polymorphism คือความสามารถในการใช้ method เดียวกันแต่ให้ผลลัพธ์ต่างกัน ขึ้นอยู่กับ class ที่เรียกใช้ โดยทั่วไปมีสองแบบ คือ Compile-time (Overloading) และ Runtime (Overriding)

==>Abstraction คือการซ่อนรายละเอียดการทำงานภายในและให้ใช้เฉพาะส่วนที่จำเป็น โดยสร้างเป็น abstract class หรือ interface เพื่อให้ class ที่สืบทอดต้องนำไปใช้งานเอง
abstract class ซะซิ หรือพูดง่ายๆคือเรามองว่าเจ้าคลาส Character นั้นมันเป็นแค่ concept เท่านั้น ไม่สามารถเอาไปใช้งานได้จริงๆยังไงล่ะ

Design Pattern 
Design Patterns เจ๋ง ๆ 7 Pattern
ก่อนอื่นต้องบอกก่อนว่า design pattern นั้นเค้าแบ่งออกได้เป็น 3 กลุ่มที่มีเป้าหมายต่างกันออกไป ประกอบด้วย
Creational patterns – เป็นกลุ่มที่ไว้ใช้สร้าง object ในรูปแบบต่างๆ ให้มีความยืดหยุ่น(flexible) และนำโค้ดมาใช้ซ้ำ(reuse)ได้
Structural patterns – กลุ่มนี้จะเป็นวิธีการนำ object และ class มาใช้งานร่วมกัน สร้างเป็นโครงสร้างที่มีความซับซ้อนยิ่งขึ้น โดยที่ยังมีความยืดหยุ่นและทำงานได้อย่างมีประสิทธิภาพ
Behavioral patterns – กลุ่มสุดท้ายนี้เป็นวิธีการออกแบบการติดต่อกันระกว่าง object ให้มีความยืดหยุ่นและสามารถติดต่อกันกันได้อย่างไม่มีปัญหา
สนใจหัวข้อไหนกดอ่านได้เลย

1. Factory Method
	สร้าง object โดยไม่ต้องกำหนดว่าตัว class ที่นำมาสร้างจริงๆคืออะไร โดยให้ subclass เป็นคนไปจัดการเอง
	✌ หลักการแบบสั้นๆ
		1.Factory Method จะมี abstract method 1 ตัว เอาไว้สร้าง object
		2.เมื่อ client ต้องการใช้ object ก็จะมาเรียก abstract method ตัวนั้น เพื่อเอา object ไปใช้
		3.Subclass เป็นคนกำหนดเองว่าจะสร้าง object จาก class ตัวไหน
	👍 ข้อดี
		ลดการเกิด tight coupling ระหว่าง creator กับ concrete products
		ถูกหลัก Single Responsibility Principle
		ถูกหลัก Open/Closed Principle
	👎 ข้อเสีย
		เพิ่มความซับซ้อนให้กับโค้ด เพราะต้องไปสร้าง class และ interface มากมาย

2. Builder
	แยกการสร้าง object ที่ต้องอาศัยขั้นตอนการสร้างที่ซับซ้อนออก และช่วยให้เราสามารถสร้าง object ประเภทอื่นๆที่มีขั้นตอนการสร้างแบบเดียวกันได้
	✌ หลักการแบบสั้นๆ
		1.แยกขั้นตอนการสร้าง object ออกไปให้ Builder รับผิดชอบ (อาจจะมี builder เพื่อใช้สร้าง object หลายๆแบบก็ได้)
		2.แยกลำดับขั้นตอนการประกอบ object ออกไปให้ Director รับผิดชอบ (ภายใน director จะมีวิธีการประกอบ object หลายๆแบบก็ได้)
		3.Client เมื่อต้องการสร้าง object ก็จะส่ง Builder ไปให้ Director เพื่อให้สร้างของที่ตัวเองต้องการออกมา
    👍 ข้อดี
		สามารถสร้าง object ที่มีขั้นตอนการสร้างอันซับซ้อนได้เรื่อยๆ
		รองรับ product แบบอื่นๆที่มีขั้นตอนในการสร้างเหมือนกันได้
		ถูกหลัก Single Responsibility Principle
	👎 ข้อเสีย
		เพิ่มความซับซ้อนให้กับโค้ด เพราะต้องไปสร้าง class มากมาย
3. Singleton
	สร้างคลาสพิเศษที่สามารถนำไปสร้างเป็น object ได้เพียงแค่ตัวเดียวเท่านั้น แล้วเปิดช่องทางให้โค้ดอื่นๆสามารถเข้าถึง object นั้นได้
	✌ หลักการแบบสั้นๆ
		1.แก้ไข constructor ของ class ที่ต้องการจะทำให้ไม่มีคนอื่นเข้าถึงได้ (ทำให้ new object ไม่ได้)
		2.สร้าง global access ที่เข้าถึง object นั้นเพื่อให้คนอื่นเรียกใช้
		3.สร้าง object ของคลาสนั้นแล้วเก็บไว้ (เมื่อถูกเรียกใช้)
	👍 ข้อดี
		มั่นใจได้ว่าคลาสนั้นๆสามารถมี object ได้เพียงแค่ตัวเดียวเท่านั้น
		มี global access point ถึง object ตัวนั้น
		object ตัวนั้นจะถูกสร้างเมื่อจำเป็นเท่านั้น
	👎 ข้อเสีย
		ละเมิดกฏ Single Responsibility Principle เพราะมันแก้ปัญหา 2 เรื่อง
		เป็น design ที่ไม่ดี เพราะ components อื่นๆสามารถกระโดดมาทำงานกับมันได้ตรงๆ
		มีปัญหากับการทำงานแบบ multithread
		มีปัญหากับการเขียน unit test

4. Adapter
	ทำให้ของ 2 อย่างทำงานร่วมกันได้ แม้ว่ามันไม่ได้ถูกออกแบบให้ทำงานร่วมกันแต่แรก โดยไม่แตะต้องโค้ดเดิมที่ถูกเขียนไว้เลย
	✌ หลักการแบบสั้นๆ
		สร้าง interface ที่เราอยากจะทำงานด้วยขึ้นมา แล้วทำงานกับ interface นั้นแทน
		นำ interface ที่เราสร้างขึ้นมาไปทำงานร่วมกัน class ที่ต้องการทำงานด้วย
	👍 ข้อดี
		สามารถเปลี่ยน Adapter เมื่อไหร่ก็ได้ นั่นหมายความว่าเราสามารถเปลี่ยน library ของ 3rd party เป็นตัวอื่นได้เรื่อยๆ โดยไม่ต้องกลับไปแก้ไขโค้ดเก่าของเราเลย
		ถูกหลัก Single Responsibility Principle
		ถูกหลัก Open/Closed Principle
	👎 ข้อเสีย
		เพิ่มความซับซ้อนให้กับโค้ด เพราะต้องไปสร้าง class และ interface มากมาย

5. Facade
	ทำให้ของที่ใช้งานยากๆซับซ้อนๆ สามารถใช้งานได้แบบง่ายๆ
	✌ หลักการแบบสั้นๆ
		สร้าง class ที่ทำงานกับ subsystem ที่วุ่นวายๆ แล้วจัดการเรื่องที่ client ต้องเรียกใช้ทั้งหมด
		สร้างช่องทางให้ client เรียกใช้งานแบบง่ายๆ
	👍 ข้อดี
		โค้ดของเราไม่ไปผูกติดกับ subsystem ที่วุ่นวาย
	👎 ข้อเสีย
		เจ้าตัว Facade จะกลายเป็น God object และตัวมันจะผูกติดกับ subsystem ที่มันทำงานอยู่

6. Observer น่าจะนำมาใช้ได้
   สร้างกลไกในการแจ้งเตือนให้กับ object ต่างๆที่สนใจ
   ✌ หลักการแบบสั้นๆ
		1.สร้างตัวกลางในการลงทะเบียนให้กับคนที่ต้องการ ติดตามข่าว/ยกเลิกติดตามข่าว ขึ้นมา
		2.สร้าง interface กลางสำหรับคนติดตามข่าว เพื่อให้ตัวกลางทำงานร่วมได้
		3.คนที่ต้องการติดตามข่าวจะต้อง implement interface นั้น
		4.เมื่อมีข่าวใหม่ๆเกิดขึ้น ตัวกลางก็จะส่งข่าวไปให้กลับคนที่ลงทะเบียนไว้
	👍 ข้อดี
		ส่งการแจ้งเตือนให้กับคนที่สนใจจะรับข่าวสารนั้นจริงๆ
	👎 ข้อเสีย
		ในแต่ละภาษาส่วนใหญ่จะรองรับเรื่องพวกนี้อยู่แล้ว ไปศึกษาภาษาที่ตัวเองใช้จะดีกว่า
		ถ้าจะส่งให้เป็นลำดับ จะต้องไปเขียนเพิ่ม
7. Template Method
	สร้าง algorithm ที่สามารถเปลี่ยนการทำงานบางขั้นตอนได้จาก subclass
	✌ หลักการแบบสั้นๆ
		แตก algorithm ออกเป็นขั้นๆ แล้วทำให้เป็น method (บางตัวอาจะเป็น abstract)
		เขียนลำดับการเรียก method พวกนั้นไว้ภายใน template method
		สร้าง subclass เพื่อมาจัดการขั้นตอนเฉพาะทางของเรื่องนั้นๆ

สรุปเรื่อง Override Method 
1. Override Method เป็นการทำซ้ำ Method ใน Class ลูก โดย Method เหล่านั้นมีการสร้างเอาไว้แล้วใน Class แม่
2. Override Method ทำให้ Class ลูกสามารถเรียกใช้งาน Method ชื่อเดิมแต่สามารถสร้างคุณสมบัติใหม่ที่แตกต่างจาก Class แม่ได้ ทำให้การออกแบบ Class มีประสิทธิภาพมากยิ่งขึ้น

สรุปเรื่อง Virtual method
Virtual method เกิดมาจากความคิดของ OOP ที่ต้องการขยายความสามารถของ class ที่สร้างไว้ก่อนแล้ว ด้วยวิธี inherit แล้ว override method 
เพื่อแก้ไขการทำงานบางส่วนของ class การใช้ virtual method ทำให้เราไม่ต้องตามไปแก้ไข method อื่นๆ ที่เรียกใช้ method ที่เราปรับปรุงทั้งหมด

**เทคนิดกด keyboard เพื่อ gen class ลูก Ctrl + .

Design folder ClassLibrary
1. แยกตามเลเยอร์ของระบบ (Layered Architecture)
/ClassLibrary
  /DataAccess        # จัดการเรื่องการเชื่อมต่อกับฐานข้อมูล (Repositories ที่เก็บ)
  /BusinessLogic     # เก็บกฎธุรกิจและการประมวลผล
  /Models            # เก็บ class ที่เป็นข้อมูลหรือ object model
  /Services          # จัดการ business logic ระดับสูง หรือ utility services
  /Interfaces        # เก็บ interfaces สำหรับ services หรือ repository

 2. ใช้ Naming Convention สอดคล้องกัน
การตั้งชื่อควรสื่อความหมายและเป็นไปในทิศทางเดียวกัน เช่น สำหรับการตั้งชื่อ class และ interface:

Class Naming: ตั้งชื่อเป็นคำนาม (Noun) และควรสื่อถึงบทบาทหรือหน้าที่ เช่น Customer, OrderManager, InvoiceService
Interface Naming: ใช้ตัวอักษร "I" นำหน้า เช่น ICustomerRepository, IOrderService
Service Naming: ถ้า class ใดเป็น service ควรลงท้ายด้วยคำว่า Service เช่น UserService, EmailService
Repository Naming: ถ้า class ใดใช้จัดการข้อมูล ควรใช้ชื่อว่า Repository เช่น CustomerRepository, ProductRepository

3. ใช้ SOLID Principle ในการออกแบบ Class Library
Single Responsibility: แต่ละ class หรือ service ควรทำหน้าที่อย่างเดียว เช่น CustomerService ดูแลเฉพาะการประมวลผลของลูกค้า
Interface Segregation: แยก interface ออกเป็นส่วนเล็กๆ แทนที่จะรวมทุกอย่างไว้ใน interface เดียว
Dependency Injection (DI): สร้าง interface สำหรับ service และใช้การ dependency injection เพื่อเพิ่มความยืดหยุ่นในการพัฒนาภายหลัง

4. จัดการส่วน Shared Logic ไว้ใน Library ต่างหาก
ส่วนของ logic ที่สามารถใช้งานได้ทั่วไป (Utility functions) ควรแยกเป็น Class Library ต่างหาก เช่น:

ClassLibrary.Common สำหรับเก็บ utility functions เช่น การจัดการวันที่ (DateHelper), การจัดการ string (StringHelper)
ClassLibrary.Logging สำหรับจัดการ logging เช่น ILogger, FileLogger, DatabaseLogger
Folder Structure:

bash
Copy code
/ClassLibrary.Common
  /Helpers            # เก็บ utilities ต่างๆ
  /Extensions         # เก็บ extension methods สำหรับ object หรือ class

5. แยกโปรเจกต์เป็นโมดูลย่อย (Modularization)
ถ้าโปรเจกต์ของคุณขนาดใหญ่ อาจแยกเป็นหลาย Class Library Projects เช่น:

ClassLibrary.DataAccess: เก็บเกี่ยวกับการเชื่อมต่อกับฐานข้อมูล
ClassLibrary.BusinessLogic: เก็บเกี่ยวกับ business logic
ClassLibrary.Models: เก็บ object model หรือ DTO
โครงสร้างแบบนี้ทำให้การจัดการโปรเจกต์ใหญ่ๆ ง่ายขึ้น และสามารถแยกพัฒนา/ทดสอบแต่ละส่วนได้อย่างอิสระ

6. การตั้งชื่อ Namespace
การตั้งชื่อ namespace ควรสัมพันธ์กับโครงสร้างของโปรเจกต์เพื่อให้สามารถอ้างอิงได้ง่ายและชัดเจน

ClassLibrary.DataAccess.Repositories
ClassLibrary.BusinessLogic.Services
ClassLibrary.Models


------------------------LOGIN---------------------------------
Flow การทำงาน Cookies และ Session ในระบบ Login
ผู้ใช้เข้าสู่หน้า Login

ผู้ใช้ป้อนข้อมูล username และ password แล้วกดปุ่ม Login
เบราว์เซอร์ส่ง HTTP Request ไปยังเซิร์ฟเวอร์

Request มีข้อมูล Login (username และ password) ในส่วน Body ของ HTTP POST
เซิร์ฟเวอร์ตรวจสอบข้อมูลในฐานข้อมูล

เซิร์ฟเวอร์ตรวจสอบว่า username และ password ตรงกับข้อมูลในฐานข้อมูลหรือไม่
หากการยืนยันสำเร็จ

เซิร์ฟเวอร์สร้าง Session บันทึกสถานะของผู้ใช้ (เช่น User ID, สิทธิ์การเข้าถึง, ชื่อผู้ใช้) ลงใน Session Store (เช่น In-Memory Database อย่าง Redis)
สร้าง Session ID ที่ไม่ซ้ำ และส่งคืนให้ผู้ใช้ในรูปของ Cookies
ส่ง Response กลับไปที่เบราว์เซอร์

Response มี Header ที่กำหนด Cookies (เช่น Set-Cookie: session_id=<Session-ID>; HttpOnly; Secure)
ผู้ใช้ร้องขอข้อมูลหรือหน้าใหม่ (Request อื่น)

เบราว์เซอร์ส่ง HTTP Request พร้อม Cookies (ที่มี Session ID) กลับไปที่เซิร์ฟเวอร์
เซิร์ฟเวอร์ตรวจสอบ Session ID

เซิร์ฟเวอร์ตรวจสอบว่า Session ID ที่ส่งมานั้นถูกต้องหรือไม่ใน Session Store
หากตรง จะโหลดข้อมูลสถานะของผู้ใช้ที่เก็บไว้ใน Session
ส่งข้อมูลหรือแสดงหน้าที่ร้องขอให้ผู้ใช้

หากการตรวจสอบสำเร็จ เซิร์ฟเวอร์จะส่ง Response พร้อมข้อมูลที่ร้องขอกลับไป
หากล้มเหลว (Session หมดอายุหรือไม่ตรง) จะส่งข้อความแจ้งเตือน เช่น "กรุณา Login อีกครั้ง"

[ผู้ใช้] --> [เบราว์เซอร์] : กรอก username/password
[เบราว์เซอร์] --> [เซิร์ฟเวอร์] : ส่ง HTTP POST พร้อมข้อมูล Login
[เซิร์ฟเวอร์] --> [ฐานข้อมูล] : ตรวจสอบ username/password
[ฐานข้อมูล] --> [เซิร์ฟเวอร์] : ยืนยันข้อมูล
[เซิร์ฟเวอร์] --> [Session Store] : สร้าง Session และเก็บข้อมูล
[เซิร์ฟเวอร์] --> [เบราว์เซอร์] : ส่ง Response พร้อม Cookies (Session ID)
[เบราว์เซอร์] --> [เซิร์ฟเวอร์] : Request ใหม่พร้อม Cookies (Session ID)
[เซิร์ฟเวอร์] --> [Session Store] : ตรวจสอบ Session ID
[เซิร์ฟเวอร์] --> [เบราว์เซอร์] : ส่งข้อมูลหรือหน้าให้ผู้ใช้

