using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        private static void testing(int actual, int expected) 
        {
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(10,22)]
        [TestCase(20,57)]
        [TestCase(30,91)]
        [TestCase(50,175)]
        public static void test1(int value, int expected) 
        { 
            testing(DoubleLinear.Program.DblLinear(value), expected);
        }  
    }
}