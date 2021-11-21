using Microsoft.VisualStudio.TestTools.UnitTesting;
using CabInvoiceGeneratorProject;
using CabInvoiceGenerator;

namespace CabInvoiceTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            [TestMethod]
            void GivenDistanceAndTimeShouldReturnTotalFare()
            {
                double expected = 25;
                double distance = 2.0;
                int time = 5;

                InvoiceGenerator invoice = new InvoiceGenerator(RideType.NORMAL);

                double fare = invoice.calculateFare(distance, time);

                Assert.AreEqual(expected, fare);
            }

        }
    }
}
