using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CellPhoneTest
{
    [TestClass]
    public class CellPhoneTest
    {
        [TestMethod]
        public void ToStringCellPhone()
        {
            CellPhone[] phones = {
                    new CellPhone("5700", "Nokia"),
                    new CellPhone("5200", "Samsung")
             };

            var expected = "Model: 5700\nManufacturer: Nokia\nModel: 5200\nManufacturer: Samsung\n";

            var actual = "";

            for (int i = 0; i < phones.Length; i++)
			{
			    actual += phones[i];
			}

            Assert.AreEqual(expected, actual);
        }
    }
}
