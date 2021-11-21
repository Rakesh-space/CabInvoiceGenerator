using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceSummary
    {
        private int numberOfRides;
        private double totalFare;
        private double averageFare;

        public InvoiceSummary(int numberOfRides, double totalFare)  //here Enhanced Invoice
        {
            this.numberOfRides = numberOfRides; //here no of ride
            this.totalFare = totalFare;       //here tatal fare
            this.averageFare = totalFare / numberOfRides;  //here calculate avarge
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is InvoiceSummary))
            {
                return false;
            }
            InvoiceSummary summary = (InvoiceSummary)obj;
            return this.numberOfRides == summary.numberOfRides && this.totalFare == summary.totalFare && this.averageFare == summary.averageFare;

        }
    }
}
