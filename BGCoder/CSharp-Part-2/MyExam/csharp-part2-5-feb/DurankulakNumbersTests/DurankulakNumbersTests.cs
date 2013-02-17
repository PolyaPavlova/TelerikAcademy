using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DurankulakNumbers;
using System.Numerics;

namespace DurankulakNumbersTests
{
    [TestClass]
    public class DurankulakNumbersTests
    {
        [TestMethod]
        public void MyTest()
        {
            string input = "fAAaB";

            var expected = 4402971;
            var actual = DurankulakNumbersClass.ConvertToDecimal(input);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void FirstExample()
        {
            string input = "U";

            var expected = 20;
            var actual = DurankulakNumbersClass.ConvertToDecimal(input);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void SecondExample()
        {
            string input = "bM";

            var expected = 64;
            var actual = DurankulakNumbersClass.ConvertToDecimal(input);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void ThirdExample()
        {
            string input = "BaG";

            var expected = 200;
            var actual = DurankulakNumbersClass.ConvertToDecimal(input);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void FourthExample()
        {
            string input = "CfI";

            var expected = 500;
            var actual = DurankulakNumbersClass.ConvertToDecimal(input);
            Assert.AreEqual(expected, actual);

        }
    }
}
