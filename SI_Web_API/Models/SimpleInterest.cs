using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SI_Web_API.Models
{
    // Represent Simple Interest
    public class SimpleInterest
    {
        public int Id { get; set; }

        // Represent Principal Amount
        public float Principal { get; set; }

        // Represent Interest Rate per Year
        public float Rate { get; set; }

        // Represnt Time Period in Years
        public int Year { get; set; }

        // Represent Simple Intereset based upon Principal , Rate and Year.
        public float Interest { get; set; }
    }
}
