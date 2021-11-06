using NUnit.Framework;
using System;

namespace TestCalculator
{
    public class UnitTest1
    {
        HelloWorld.Calculator newCalculator = new HelloWorld.Calculator();

        [TestCase(4,5)]
        [TestCase (999,44)]
        public void TestMultiplication(int a, int b)
        {
            var expectedResult = a * b;
            var result = newCalculator.Multiplication(a, b);
            Assert.That(expectedResult,Is.EqualTo(result));
        }

        [TestCase(4, 5)]
        [TestCase(30, 20)]
        public void TestDivision (int a, int b)
        {
            int expectedResult = a / b;
            var result = newCalculator.Division (a, b);
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [TestCase(30, 0)]
        public void TestDivisionByZero(int a, int b)
        {
            var stringWriter = new System.IO.StringWriter();
            Console.SetOut(stringWriter);
            string s = "The second number could not be 0.";
            int expectedResult = -9999;
            var result = newCalculator.Division(a, b);
            Assert.That(expectedResult, Is.EqualTo(result));
            s = s.Replace(".", "\n");
            Assert.AreEqual(s, stringWriter.ToString());
        }
    }
}
