using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCalculator
{
    class TravelCalculator
    {
        Journey currentJourney; // This creates a journey object for this class
        public TravelCalculator(Journey currentJourney)        {

            this.currentJourney = currentJourney; // This defines that journey object using the constructor
        }


        public void GenerateClaimSlips() // This generates the slip from the journey object and also prints it
        {
            currentJourney.CalculateClaim();
            currentJourney.printClaimSlip();
        }
    }
}
