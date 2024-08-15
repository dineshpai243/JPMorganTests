using NUnit.Framework;
using JPMorganTests;
using NUnit.Framework;

namespace JPMorganUnitTests
{
    [TestFixture]
    public class NumberUtilTests
    {
        

        [Test]
        public void CheckForCorrectIndex()
        {
            int number = 156; // 10011100
            int result = NumberUtils.GetPositionOfMaxOnes(number);
            Assert.AreEqual(4, result);
        }

        [Test]
        public void CheckForZero()
        {

            int number = 0; 
            int result = NumberUtils.GetPositionOfMaxOnes(number);
            Assert.AreEqual(0, result);
        }



        [TestCase(217, 1)]
        [TestCase(8, 1)]
        [TestCase(88, 3)]
        [TestCase(255, 1)]
        [TestCase(1692567, 5)] // 110011101001110010111
        public void CheckForValidNumbers(int number, int expectedRes)
        {

            int result = NumberUtils.GetPositionOfMaxOnes(number);
            Assert.AreEqual(expectedRes, result);
        }


        

        [Test]
        public void CheckNegativeNumber()
        {
            int number = -5;
            int result = NumberUtils.GetPositionOfMaxOnes(number);
            Assert.AreEqual(0, result);
        }
    }
}
