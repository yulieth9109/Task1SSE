using NUnit.Framework;

namespace TestCalculator
{
    public class UnitTest3
    {
        HelloWorld.HashValue newHashValue = new HelloWorld.HashValue();


        [TestCase("VSR", 124)]
        [TestCase("aklm", 40)]
        [TestCase("", -1)]
        public void testHashValue(string text,int expectedResult)
        {
            Assert.That(expectedResult,Is.EqualTo( newHashValue.CalculateHashValue(text)));
        }
    }
}
