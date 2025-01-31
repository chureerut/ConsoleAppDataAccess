using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var result = Add(5, 6);
            Assert.AreEqual(11, result);
        }
        [TestMethod]
        public void TestMethod2()
        {
            var result = Add(50, 60);
            Assert.AreEqual(110, result);
        }         
        
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
