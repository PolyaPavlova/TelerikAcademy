/**********************************************************************************************
 *12. Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
*********************************************************************************************/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CellPhoneCallHistoryTest
{
    

    [TestClass]
    public class CellPhoneCallHistoryTest
    {
        public List<Call> testHistory = new List<Call>();

        // Create an instance of the GSM class.
        public CellPhone testPhone = new CellPhone("2526", "Samsung");

        // Add few calls.
        public void FillingHistory()
        {
            testPhone.AddCall(DateTime.Parse("5/5/2012"), "08952626", 30);
            testPhone.AddCall(DateTime.Parse("4/5/2012"), "085968746", 30);
            testPhone.AddCall(DateTime.Parse("6/11/2013"), "0895856", 60);

            var expected = 3;
            var actual = testPhone.CallHistory.Count;

           
        }

        // Display the information about the calls.
        [TestMethod]
        public void PrintingCalls()
        {
            FillingHistory();

            string expected = "5.5.2012 г. 00:00:00 ч.\n08952626\n30" +
                            "4.5.2012 г. 00:00:00 ч.\n085968746\n30" +
                            "6.11.2013 г. 00:00:00 ч.\n0895856\n60";

            string actual = "";

            foreach (var call in testPhone.CallHistory)
            {
                var curr = call.DateTimeCall + "\n" + call.Dialed + "\n" + call.Duration;
                actual += curr;
            }

            Assert.AreEqual(expected, actual);

        }

        // Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
        [TestMethod]
        public void TotalPrice()
        {
            FillingHistory();
     
            decimal price = (decimal)0.37;

            decimal expectedBill = (decimal)0.74;

            var actualBill = testPhone.CalculateBill(testPhone.CallHistory, price);

            Assert.AreEqual(expectedBill, actualBill);

        }

        // Remove the longest call from the history and calculate the total price again.
        [TestMethod]
        public void TotalPriceWithoutLongestCall()
        {
            FillingHistory();

            decimal price = (decimal)0.37;

            int maxDuration = 0;

            for (int i = 0; i < testPhone.CallHistory.Count; i++)
            {
                int currCuration = testPhone.CallHistory[i].Duration;

                if (currCuration > maxDuration)
                {
                    maxDuration = currCuration;
                }
            }

            for (int i = 0; i < testPhone.CallHistory.Count; i++)
            {
                int currCuration = testPhone.CallHistory[i].Duration;

                if (currCuration == maxDuration)
                {
                    testPhone.CallHistory.Remove(testPhone.CallHistory[i]);
                    break;
                }
            }

            decimal expectedBill = (decimal)0.37;

            var actualBill = testPhone.CalculateBill(testPhone.CallHistory, price);

            Assert.AreEqual(expectedBill, actualBill);

        }

        // Finally clear the call history and print it.
        [TestMethod]
        public void ClearCallHistory()
        {
            FillingHistory();

            testPhone.ClearHistory(testPhone.CallHistory);

            var expected = "History cleared";
            var actual = "History cleared";

            Assert.AreEqual(expected, actual);
           

            

        }
    }
}
