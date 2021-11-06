using NUnit.Framework;
using System.Text;
using System.IO;
using System;
using Moq;

namespace TestCalculator
{
    public class UnitTest2
    {
        HelloWorld.CalculatorExtension newCalculator = new HelloWorld.CalculatorExtension();
        string docPath = Environment.CurrentDirectory + "/Result.txt";

        [TestCase(4, 5)]
        [TestCase(678944, 5)]
        [TestCase(12, 365)]
        [TestCase(0, 365)]
        public void TestMultiplication(int a, int b)
        {

            int expectedResult = a * b;
            newCalculator.Multiplication(a, b);
            newCalculator.PrintResult();
            Assert.That(expectedResult.ToString, Is.EqualTo(ReadFile()));
        }


        [TestCase(4, 5)]
        [TestCase(678944, 5)]
        [TestCase(12, 365)]
        [TestCase(0, 365)]
        public void TestDivision(int a, int b)
        {
            int expectedResult = a / b;
            newCalculator.Division(a, b);
            newCalculator.PrintResult();
            Assert.That(expectedResult.ToString, Is.EqualTo(ReadFile()));
        }

        [TestCase(4,0)]
        [TestCase(80, 0)]
        public void TestDivisionByZero(int a, int b)
        {
            int expectedResult = -9999;
            newCalculator.Division(a, b);
            newCalculator.PrintResult();
            Assert.That(expectedResult.ToString, Is.EqualTo(ReadFile()));
        }

        [TestCase(4, 67)]
        public void TestDeleteFileFailure(int a, int b) {

            var mockFileSystem = new Mock<IFileSystem>();
            mockFileSystem.Setup(x => x.FileExists(Environment.CurrentDirectory + "/Result.txt")).Returns(true);
            mockFileSystem.Setup(x => x.FileDelete(Environment.CurrentDirectory + "/Result.txt")).Throws<System.Exception>();
            var newCalculator2 = new HelloWorld.CalculatorExtension(mockFileSystem.Object);
            newCalculator2.Multiplication(a, b);
            newCalculator2.PrintResult();
            Assert.IsTrue(newCalculator2.correctExceptionThrown);
        }

        [TestCase(85, 67)]
        public void TestWriteFailure(int a, int b)
        {
            int result1 = a / b;
            var mockFileSystem = new Mock<IFileSystem>();
            mockFileSystem.Setup(x => x.FileWriteAllText(Environment.CurrentDirectory + "/Result.txt", result1.ToString(), Encoding.UTF8)).Throws<System.Exception>();
            var newCalculator2 = new HelloWorld.CalculatorExtension(mockFileSystem.Object);
            newCalculator2.Division(a, b);
            newCalculator2.PrintResult();
            Assert.IsTrue(newCalculator2.correctExceptionThrown);
        }

        private string ReadFile()
        {

            string readText = File.ReadAllText(docPath);
            return readText;

        }

    }

}
