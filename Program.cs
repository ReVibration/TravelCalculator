using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // DECLARATION OF VARIABLES
            string carRegistration;
            string startLocation;
            string endLocation;
            int engineSize;
            int mileage;
            bool isCompanyCar;
            string userAnswerCompanyCar;
            bool Continue = true; // Setting this to true to ensure that the program at least runs once 
            string userContinue;
            TravelCalculator travelCalculator;
            List<Journey> journeys = new List<Journey>(); // Using a list for the journeys as the length doesnt need to be declared beforehand

            while (Continue)
            {
                //USER INPUT SECTION
                Console.WriteLine("Enter car registration:"); // This asks for the car registration
                carRegistration = Console.ReadLine();

                Console.WriteLine("Enter journey start location:"); // This asks for the start location
                startLocation = Console.ReadLine();

                Console.WriteLine("Enter journey end location:"); // This asks for the end location
                endLocation = Console.ReadLine();

                Console.WriteLine("Enter engine szie in CC (eg 1500):"); // This asks for the engine size 
                engineSize = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Mileage:"); // This asks for the mileage
                mileage = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Company car or Private car - C / P:"); // This asks whether its a company or private car
                userAnswerCompanyCar = Console.ReadLine();

                if (userAnswerCompanyCar == "c") // This section converts the answer to company car into a true or false dependant on the users answer
                    isCompanyCar = true;
                else if (userAnswerCompanyCar == "p")
                    isCompanyCar = false;
                else
                {
                    isCompanyCar = true;
                    Console.WriteLine("Please try again"); // If the user enters not c or p the program throws an error
                }

                Journey currentJourney = new Journey(carRegistration, startLocation, endLocation, engineSize, mileage, isCompanyCar); // This creates a new journey object with the variables provided from the user input
                journeys.Add(currentJourney); // This adds the journey to the list

                Console.WriteLine("Add another journey? y/n"); // This asks the user whether to add another journey
                userContinue = Console.ReadLine();

                if (userContinue == "y") // This filters and valides the input to the question above
                    Continue = true;
                else
                    Continue = false;

            }
                foreach(Journey currentJourney in journeys) // This loops through the list using current journey as the index
            {
                travelCalculator = new TravelCalculator(currentJourney); // This actually creates the travel calculator object for each journey
                travelCalculator.GenerateClaimSlips(); // then it generates the slips
            }
    
        }
    }
}
