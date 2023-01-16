using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCalculator
{
    class Journey 
    {
        // These are the class variables needed
        string carRegistration;
        string startLocation;
        string endLocation;
        int engineSize;
        int mileage;
        bool isCompanyCar;
        double petrolRate;
        double petrolClaim;
        double privateHigherRate = 0.30; // These set the higher and lower rate for private cars
        double privateLowerRate = 0.05;
        double privateAllowance = 0; // this is 0 to makes sure that company cars don't get extra allowance
        double totalClaim;

        // This method references the variables using a constructor
        public Journey(string carRegistration, string startLocation, string endLocation, int engineSize, int mileage, bool isCompanyCar)
        {
            this.carRegistration = carRegistration;
            this.startLocation = startLocation;
            this.endLocation = endLocation;
            this.engineSize = engineSize;
            this.mileage = mileage;
            this.isCompanyCar = isCompanyCar;
        }

        //This method calls all of the methods need to calculate the claim
        public void CalculateClaim()
        {
            SetPetrolRate();
            CalcPetrolClaim();
            CalcPrivateAllowance();
            CalcTotalClaim();
        }

        // This method works out the petrol rate depandant on the engine size 
        private void SetPetrolRate()
        {
            if (engineSize < 1500)
                petrolRate = 0.75;
            else if (engineSize > 1500 && engineSize < 2000)
                petrolRate = 0.10;
            else if (engineSize > 2000 && engineSize < 2500)
                petrolRate = 0.125;
            else if (engineSize > 2500)
                petrolRate = 0.15;
            else
                petrolRate = 0; // If there is an error the petrol rate is 0
        }

        // This works out the petrol claim for the journey
        private void CalcPetrolClaim()
        {
            petrolClaim = mileage * petrolRate;
        }

        //This works out the private car allowance
        private void CalcPrivateAllowance()
        {
            // If the car is not a company car this works out the extra allowance depending on the miles 
            if (!isCompanyCar)
            {
                if (mileage > 25)
                    privateAllowance = privateHigherRate;
                else if (mileage < 25)
                    privateAllowance = privateLowerRate;
            }
        }

        // This uses the other values to calculate the total claim
        private void CalcTotalClaim()
        {

            //This works out the total claim
            totalClaim = petrolClaim + privateAllowance;
        }

        //This method prints the claims slip
        public void printClaimSlip()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("WorcsWheelz Travel Claim Calculator");
            Console.WriteLine("Your regstration is: {0}", carRegistration);
            Console.WriteLine("You drove from: {0} to {1}", startLocation, endLocation);
            Console.WriteLine("The engine size is: {0}", engineSize);
            Console.WriteLine("You traveled {0} miles", mileage);
            Console.WriteLine("Your Petrol Claim is: £{0}", petrolClaim);
            Console.WriteLine("Your private car allowanced: £{0}", privateAllowance);
            Console.WriteLine("Your total claim: £{0}", totalClaim);
        }
    }
}
