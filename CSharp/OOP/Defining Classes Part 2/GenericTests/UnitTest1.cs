using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericListNamespace;

namespace GenericTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddingElementInt()
        {
            GenericList<int> myList = new GenericList<int>(3); // {0,0,0}

            myList.AddElement(2); // {2,0,0}
            myList.AddElement(0); // {2,0,0}
            myList.AddElement(7); // {2,0,7};

            var expected = "207";
            var actual = "" +myList[0] + myList[1] + myList[2];

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddingElementString()
        {
            GenericList<string> myList = new GenericList<string>(3);

            myList.AddElement("alpha");
            myList.AddElement("beta");

            var expected = "alphabeta";
            var actual = "" + myList[0] + myList[1] + myList[2];

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AccessByIndex()
        {
            GenericList<string> myList = new GenericList<string>(3);

            myList.AddElement("alpha");
            myList.AddElement("beta");
            myList.AddElement("gama");

            var expected = "beta";
            var actual = myList[1];

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException),"Index is out of range")]
        public void AccessByIndexException()
        {
            GenericList<string> myList = new GenericList<string>(3);

            myList.AddElement("alpha");
            myList.AddElement("beta");
            myList.AddElement("gama");

            var actual = myList[3];

        }

        [TestMethod]
        public void RemoveElementByIndex()
        {
            GenericList<string> myList = new GenericList<string>(3);

            myList.AddElement("alpha");
            myList.AddElement("beta");
            myList.AddElement("gama");

            myList.RemoveElement(0);

            var expected = "betagama";
            var actual = "";

            for (int i = 0; i < myList.Len; i++)
            {
                actual += myList[i];
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertAtLastPosition()
        {
            GenericList<string> myList = new GenericList<string>(3);

            myList.AddElement("alpha");
            myList.AddElement("beta");
            myList.AddElement("gama");

            myList.InsertElement(2, "delta");

            var expected = 6;
            var actual = myList.Len;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClearTest()
        {
            GenericList<string> myList = new GenericList<string>(3);

            myList.AddElement("alpha");
            myList.AddElement("beta");
            myList.AddElement("gama");

            myList.Clear();

            var expected = 0;
            var actual = myList.Len;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AccessByValue()
        {
            GenericList<string> myList = new GenericList<string>(3);

            myList.AddElement("alpha");
            myList.AddElement("beta");
            myList.AddElement("gama");


            var expected = 2;
            var actual = myList.GetPosition("gama");

            Assert.AreEqual(expected, actual);
        }

    }


}
