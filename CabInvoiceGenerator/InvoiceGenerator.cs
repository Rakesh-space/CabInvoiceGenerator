using CabInvoiceGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGeneratorProject
{
    public class InvoiceGenerator
    {
        RideType rideType;

        private readonly double MINIMUM_COST_PER_KM;
        private readonly int COST_PER_TIME;
        private readonly double MINIMUM_FARE;

        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            try
            {
                if (this.rideType.Equals(RideType.NORMAL)) //for NORMAL cabs ride
                {
                    this.MINIMUM_COST_PER_KM = 10;
                    this.COST_PER_TIME = 1;
                    this.MINIMUM_FARE = 5;
                }
                if (this.rideType.Equals(RideType.PREMIUM)) //for PREMIUM cabs ride
                {
                    this.MINIMUM_COST_PER_KM = 15;
                    this.COST_PER_TIME = 2;
                    this.MINIMUM_FARE = 20;
                }
            }
            catch (CabInvoiceException)  //here custome exception " INVALID_RIDETYPE "
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDETYPE, "invalid ride type");
            }

        }

        public double calculateFare(double distance, int time) //here calculate fare
        {
            double totalFare = 0;
            try
            {
                totalFare = distance + MINIMUM_COST_PER_KM + time * COST_PER_TIME; //use this formula for total FARE


            }
            catch (CabInvoiceException)
            {
                if (distance <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "invalid distance");

                }
                if (distance <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "invalid time");

                }
            }
            return Math.Max(totalFare, MINIMUM_FARE);
        }

        public double CalculateFare(Ride[] rides)
        {
           // Ride[] rides = new Ride[10];  //for cabInvoice of size of 10 cabs
            double totalFare = 0;
            try
            {
                foreach (Ride ride in rides)
                {
                    totalFare += this.calculateFare(ride.distance, ride.time);
                }
            }
            catch (CabInvoiceException)
            {
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "no rides found");

                }
            }
            return totalFare;
        }

    }
}