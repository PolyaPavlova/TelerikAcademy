using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _3DUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestToString()
        {
            Point3D firstPoint = new Point3D(3, 4, 5);

            var expected = "X: 3 Y: 4 Z: 5";
            var actual = firstPoint.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BasePointTest()
        {
            Point3D basePoint = Point3D.BasePoint;

            var expected = "X: 0 Y: 0 Z: 0";
            var actual = basePoint.ToString();

            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod]
        public void Distance()
        {
            Point3D first = new Point3D(2, 3, 4);
            Point3D second = new Point3D(5, 6, 7);

            double expected = 5.19615242270663;
            double actual = _3DSpace.Distance.CalculateDistance(first, second);

            Assert.AreEqual(expected, actual, delta: 1e-10);
        }
        
    }
}
